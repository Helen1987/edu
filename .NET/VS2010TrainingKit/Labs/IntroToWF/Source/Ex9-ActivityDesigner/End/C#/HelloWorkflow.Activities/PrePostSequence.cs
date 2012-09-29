// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System.Activities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Markup;
using HelloWorkflow.Activities.Designers;

namespace HelloWorkflow.Activities
{
    /// <summary>
    /// An activity that executes child activities in order and supports a pre/post activity
    /// </summary>
    [ContentProperty("Activities")]
    [Designer(typeof(PrePostSequenceDesigner))]
    public sealed class PrePostSequence : NativeActivity
    {
        #region Private Members

        Collection<Activity> activities;
        Collection<Variable> variables;

        Variable<bool> preCompleted = new Variable<bool>() { Name = "PreCompleted" };
        Variable<bool> bodyCompleted = new Variable<bool>() { Name = "BodyCompleted" };
        Variable<int> lastIndexHint = new Variable<int>() { Name = "LastIndexHint" };

        CompletionCallback onChildCompleted;
        CompletionCallback onPreCompleted;

        #endregion

        /// <summary>
        /// Contains the variables scoped to this activity
        /// </summary>
        public Collection<Variable> Variables
        {
            get
            {
                if (variables == null)
                {
                    variables = new Collection<Variable>();
                }
                return variables;
            }
        }

        /// <summary>
        /// The Pre-Sequence activity
        /// </summary>
        /// <remarks>
        /// Use the DependsOn to control the order of serialization in XAML
        /// This will come after the variables
        /// </remarks>
        [DependsOn("Variables")]
        public Activity Pre { get; set; }

        /// <summary>
        /// The Activities in the body of the sequence
        /// </summary>
        /// <remarks>
        /// Use the DependsOn to control the order of serialization in XAML
        /// This will come after Pre activity
        /// </remarks>
        [DependsOn("Pre")]
        public Collection<Activity> Activities
        {
            get
            {
                if (activities == null)
                {
                    activities = new Collection<Activity>();
                }
                return activities;
            }
        }

        /// <summary>
        /// The Post-Sequence Activity
        /// </summary>
        /// <remarks>
        /// Use the DependsOn to control the order of serialization in XAML
        /// This will come after the Activities
        /// </remarks>
        [DependsOn("Activities")]
        public Activity Post { get; set; }

        /// <summary>
        /// The callback for when the Pre activity is completed
        /// </summary>
        CompletionCallback OnPreCompletedCallback
        {
            get
            {
                if (onPreCompleted == null)
                {
                    onPreCompleted = new CompletionCallback(OnPreCompleted);
                }
                return onPreCompleted;
            }
        }

        /// <summary>
        /// The callback for when child activities are completed
        /// </summary>
        /// <remarks>
        /// Creating and caching the callback using this pattern
        /// results in improved performance because the callback
        /// is created only once even though there may be 
        /// many child activities
        /// </remarks>
        CompletionCallback OnChildCompletedCallback
        {
            get
            {
                if (onChildCompleted == null)
                {
                    onChildCompleted = new CompletionCallback(OnChildCompleted);
                }
                return onChildCompleted;
            }
        }

        /// <summary>
        /// Informs the runtime about our activity and the data
        /// </summary>
        /// <param name="metadata">The metadata</param>
        /// <remarks>
        /// The base class implementation
        /// will discover variables and child activities using reflection.  By overriding 
        /// CacheMetadata we avoid this and get improved performance.
        /// </remarks>
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            /// implementation variables are variables that are 
            /// private to our workflow.
            metadata.AddImplementationVariable(lastIndexHint);
            metadata.AddImplementationVariable(preCompleted);
            metadata.AddImplementationVariable(bodyCompleted);

            metadata.SetVariablesCollection(Variables);

            metadata.AddChild(Pre);
            metadata.AddChild(Post);

            // Cannot use metadata.SetActivitiesCollection because of Pre/Post
            foreach (Activity activity in Activities)
            {
                metadata.AddChild(activity);
            }
        }

        /// <summary>
        /// Implementation of the activity
        /// </summary>
        /// <param name="context">The context used to schedule</param>
        protected override void Execute(NativeActivityContext context)
        {
            ScheduleChildActivities(context);
        }

        /// <summary>
        /// Schedules the child activities
        /// </summary>
        /// <param name="context">The context used to schedule</param>
        /// <remarks>
        /// The PrePostSequence can have the following combinations
        /// Pre Only
        /// Post Only
        /// Pre and Post with empty Activities collection
        /// Pre and Post and Activities
        /// </remarks>
        private void ScheduleChildActivities(NativeActivityContext context)
        {
            if (PreActivityExists()
                && PreHasNotCompleted(context))
            {
                // Schedule the Pre activity
                context.ScheduleActivity(Pre, OnPreCompletedCallback);
            }
            else if (ActivitiesCollectionIsNotEmpty()
                && ActivitiesHaveNotCompleted(context))
            {
                // Schedule the first child
                // the OnChildCompletedCallback will schedule
                // the other child activities
                context.ScheduleActivity(Activities.First(),
                    OnChildCompletedCallback);
            }
            else if (PostIsNotEmpty())
            {
                // No CompletionCallback is required for Post because
                // the activity is done when Post is completed
                context.ScheduleActivity(Post);
            }
        }

        /// <summary>
        /// Called when the Pre activity is completed
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        private void OnPreCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            preCompleted.Set(context, true);
            ScheduleChildActivities(context);
        }

        /// <summary>
        /// Called when one of the child activities is completed
        /// </summary>
        /// <param name="context"></param>
        /// <param name="completedInstance"></param>
        private void OnChildCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            // get the index of the completed activity and increment it
            int completedInstanceIndex = lastIndexHint.Get(context);
            int nextChildIndex = completedInstanceIndex + 1;

            // if the sequence is not done, schedule the next child
            if (nextChildIndex < Activities.Count)
            {
                lastIndexHint.Set(context, nextChildIndex);
                Activity nextChild = Activities[nextChildIndex];
                context.ScheduleActivity(nextChild, OnChildCompletedCallback);
            }
            else // Completed body
            {
                bodyCompleted.Set(context, true);
                ScheduleChildActivities(context);
            }
        }

        private bool PostIsNotEmpty()
        {
            return Post != null;
        }

        private bool ActivitiesHaveNotCompleted(NativeActivityContext context)
        {
            return bodyCompleted.Get(context) == false;
        }

        private bool ActivitiesCollectionIsNotEmpty()
        {
            return Activities.Count > 0;
        }

        private bool PreHasNotCompleted(NativeActivityContext context)
        {
            return preCompleted.Get(context) == false;
        }

        private bool PreActivityExists()
        {
            return Pre != null;
        }
    }
}
