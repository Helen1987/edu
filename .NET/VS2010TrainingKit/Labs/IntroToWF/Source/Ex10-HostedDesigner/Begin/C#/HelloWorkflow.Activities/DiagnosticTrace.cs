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
using System.Activities.Tracking;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Markup;
using HelloWorkflow.Activities.Designers;

namespace HelloWorkflow.Activities
{
    [Designer(typeof(DiagnosticTraceDesigner))]
    public sealed class DiagnosticTrace : CodeActivity
    {
        const string DefaultRecordName = "Diagnostic Trace";

        public DiagnosticTrace()
        {
            Level = TraceLevel.Off;
            Category = DefaultRecordName;
        }

        /// <summary>
        /// The Text to display in the trace
        /// </summary>
        /// <remarks>
        /// The Text property is an InArgument<string> because we want to 
        /// allow it to evaluate the content of trace data at runtime
        /// The category and level are Design time properties - they cannot
        /// be changed at runtime/>
        /// </remarks>
        [DefaultValue(null)]
        public InArgument<string> Text { get; set; }

        /// <summary>
        /// The category of the trace
        /// </summary>
        /// <remarks>
        /// The category name is also used as the record name for 
        /// the CustomTrackingRecord
        /// </remarks>
        [DependsOn("Text")]
        [DefaultValue(null)]
        public string Category { get; set; }

        /// <summary>
        /// The trace level for this message
        /// </summary>
        [DependsOn("Category")]
        [DefaultValue("Off")]
        public TraceLevel Level { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string text = context.GetValue(this.Text);

            switch (Level)
            {
                case System.Diagnostics.TraceLevel.Error:
                    Trace.TraceError(text);
                    break;
                case System.Diagnostics.TraceLevel.Info:
                    Trace.TraceInformation(text);
                    break;
                case System.Diagnostics.TraceLevel.Verbose:
                    Trace.WriteLine(text, Category);
                    break;
                case System.Diagnostics.TraceLevel.Warning:
                    Trace.TraceWarning(text);
                    break;
            }

            if (Level != System.Diagnostics.TraceLevel.Off)
            {
                var trackRecord = new CustomTrackingRecord(Category, Level);
                trackRecord.Data.Add("Text", text);
                trackRecord.Data.Add("Category", Category);

                context.Track(trackRecord);
            }
        }

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            var textArg = new RuntimeArgument("Text", typeof(string), ArgumentDirection.In, true);
            metadata.AddArgument(textArg);

            if (string.IsNullOrEmpty(Category))
                metadata.AddValidationError("Category must not be empty");
        }
    }
}
