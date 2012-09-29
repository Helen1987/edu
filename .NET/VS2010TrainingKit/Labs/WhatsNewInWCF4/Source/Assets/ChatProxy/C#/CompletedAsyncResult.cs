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

namespace ChatProxy
{
    using System;

    // An AsyncResult that completes as soon as it is instantiated.
    public class CompletedAsyncResult : AsyncResult
    {
        public CompletedAsyncResult(AsyncCallback callback, object state)
            : base(callback, state)
        {
            Complete(true);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Demo code")]
        public static void End(IAsyncResult result)
        {
            AsyncResult.End<CompletedAsyncResult>(result);
        }
    }

    public class CompletedAsyncResult<T> : AsyncResult
    {
        private T data;

        public CompletedAsyncResult(T data, AsyncCallback callback, object state)
            : base(callback, state)
        {
            this.data = data;
            base.Complete(true);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Demo code")]
        public static T End(IAsyncResult result)
        {
            return AsyncResult.End<CompletedAsyncResult<T>>(result).data;
        }
    }
}