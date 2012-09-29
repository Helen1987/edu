﻿// ----------------------------------------------------------------------------------
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

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.21006.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRApplicationServices.Activities {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ServiceResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ServiceResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HRApplicationServices.Activities.ServiceResources", typeof(ServiceResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your Application for Employment at Contoso.
        /// </summary>
        public static string ApplicationMailSubject {
            get {
                return ResourceManager.GetString("ApplicationMailSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid or empty education in resume.
        /// </summary>
        public static string ErrorEmptyEducation {
            get {
                return ResourceManager.GetString("ErrorEmptyEducation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We are unable to process your resume at this time - internal system error.
        /// </summary>
        public static string ExceptionMessage {
            get {
                return ResourceManager.GetString("ExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!DOCTYPE html PUBLIC &quot;-//W3C//DTD XHTML 1.0 Transitional//EN&quot; &quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;
        ///&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;
        ///&lt;head&gt;
        ///    &lt;title&gt;&lt;/title&gt;
        ///    &lt;style type=&quot;text/css&quot;&gt;
        ///        .style1
        ///        {{
        ///            width: 200px;
        ///            height: 68px;
        ///        }}
        ///        body
        ///        {{
        ///            font-family: Verdana;
        ///            font-size: large;
        ///        }}
        ///        &lt;/style&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///&lt;img src=&quot;{2}/Images/logo.png&quot; alt=&quot;Contoso Logo&quot; /&gt; [rest of string was truncated]&quot;;.
        /// </summary>
        public static string GenericMailTemplate {
            get {
                return ResourceManager.GetString("GenericMailTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Conguratulations.
        /// </summary>
        public static string HireHeading {
            get {
                return ResourceManager.GetString("HireHeading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Screening Request for Applicant {0}.
        /// </summary>
        public static string HumanScreenSubject {
            get {
                return ResourceManager.GetString("HumanScreenSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thank you {0}, your applicant ID is {1}.  We are now processing resume and references.  You will receive an email with the results..
        /// </summary>
        public static string JobApplicationProcessing {
            get {
                return ResourceManager.GetString("JobApplicationProcessing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thank You.
        /// </summary>
        public static string NoHireHeading {
            get {
                return ResourceManager.GetString("NoHireHeading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dear {0}, after careful review, Contoso has decided that your qualifications did not match any current openings. Thank you for your interest..
        /// </summary>
        public static string NoHireText {
            get {
                return ResourceManager.GetString("NoHireText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dear {0},  Contoso is pleased to extend you an offer. You should receive your $1,000,000 check for your signing bonus shortly..
        /// </summary>
        public static string OfferText {
            get {
                return ResourceManager.GetString("OfferText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!DOCTYPE html PUBLIC &quot;-//W3C//DTD XHTML 1.0 Transitional//EN&quot; &quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;
        ///&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot;&gt;
        ///&lt;head&gt;
        ///    &lt;title&gt;&lt;/title&gt;
        ///    &lt;style type=&quot;text/css&quot;&gt;
        ///        .style1
        ///        {{
        ///            width: 200px;
        ///            height: 68px;
        ///        }}
        ///        body
        ///        {{
        ///            font-family: Verdana;
        ///            font-size: large;
        ///        }}
        ///        &lt;/style&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///&lt;img src=&quot;{2}/Images/logo.png&quot; alt=&quot;Contoso Logo&quot; /&gt; [rest of string was truncated]&quot;;.
        /// </summary>
        public static string ReviewMailTemplate {
            get {
                return ResourceManager.GetString("ReviewMailTemplate", resourceCulture);
            }
        }
    }
}
