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
    using System.Threading;
    
    // A generic base class for IAsyncResult implementations that wraps a ManualResetEvent.
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Demo code")]
    public abstract class AsyncResult : IAsyncResult
    {
        private AsyncCallback callback;
        private bool endCalled;
        private Exception completeException;
        private bool isCompleted;
        private ManualResetEvent manualResetEvent;
        private object state;
        private object thisLock;

        public bool CompletedSynchronously { get; private set; }

        protected AsyncResult(AsyncCallback callback, object state)
        {
            this.callback = callback;
            this.state = state;
            this.thisLock = new object();
        }

        public object AsyncState
        {
            get
            {
                return this.state;
            }
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                if (this.manualResetEvent != null)
                {
                    return this.manualResetEvent;
                }

                lock (this.ThisLock)
                {
                    if (this.manualResetEvent == null)
                    {
                        this.manualResetEvent = new ManualResetEvent(this.isCompleted);
                    }
                }

                return this.manualResetEvent;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return this.isCompleted;
            }
        }

        private object ThisLock
        {
            get
            {
                return this.thisLock;
            }
        }

        // End should be called when the End function for the asynchronous operation is complete.  It
        // ensures the asynchronous operation is complete, and does some common validation.
        protected static TAsyncResult End<TAsyncResult>(IAsyncResult result)
            where TAsyncResult : AsyncResult
        {
            if (result == null)
            {
                throw new ArgumentNullException("result");
            }

            TAsyncResult asyncResult = result as TAsyncResult;

            if (asyncResult == null)
            {
                throw new ArgumentException("Invalid async result.", "result");
            }

            if (asyncResult.endCalled)
            {
                throw new InvalidOperationException("Async object already ended.");
            }

            asyncResult.endCalled = true;

            if (!asyncResult.isCompleted)
            {
                asyncResult.AsyncWaitHandle.WaitOne();
            }

            if (asyncResult.manualResetEvent != null)
            {
                asyncResult.manualResetEvent.Close();
            }

            if (asyncResult.completeException != null)
            {
                throw asyncResult.completeException;
            }

            return asyncResult;
        }

        // Call this version of complete when your asynchronous operation is complete.  This will update the state
        // of the operation and notify the callback.
        protected void Complete(bool completedSynchronously)
        {
            if (this.isCompleted)
            {
                // It's a bug to call Complete twice.
                throw new InvalidOperationException("This async result is already completed.");
            }

            this.CompletedSynchronously = completedSynchronously;

            if (completedSynchronously)
            {
                this.isCompleted = true;
            }
            else
            {
                lock (this.ThisLock)
                {
                    this.isCompleted = true;
                    if (this.manualResetEvent != null)
                    {
                        this.manualResetEvent.Set();
                    }
                }
            }

            // If the callback throws, there is a bug in the callback implementation
            if (this.callback != null)
            {
                this.callback(this);
            }
        }

        // Call this version of complete if you raise an exception during processing.  In addition to notifying
        // the callback, it will capture the exception and store it to be thrown during AsyncResult.End.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Demo code")]
        protected void Complete(bool completedSynchronously, Exception exception)
        {
            this.completeException = exception;
            this.Complete(completedSynchronously);
        }
    }
}