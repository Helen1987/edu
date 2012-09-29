using System.Collections;
using System.IO;
using System.Threading;

namespace ThreadAndThreadPool
{
    /// <summary>
    /// A logger which asynchronously writes messages to a log file.
    /// </summary>
    class AsyncLogger
    {
        private readonly StreamWriter _writer;

        public AsyncLogger(string file)
        {
            _writer = new StreamWriter(file);
        }

        public void WriteLog(string message)
        {
            _writer.Write(message);
        }

        public void WriteLogAsync(string message)
        {
            //Dispatch the work asynchronously using the thread pool:
            ThreadPool.QueueUserWorkItem(delegate
            {
                WriteLog(message);
            });
        }

        public void Close()
        {
            _writer.Close();
        }
    }

    /// <summary>
    /// Another version of the asynchronous logger which uses an internal
    /// synchronized queue of work items (log messages).  A separate thread
    /// performs the actual writing of messages to the log.
    /// </summary>
    class AsyncLogger2
    {
        private readonly StreamWriter _writer;
        private readonly Thread _thread;
        private readonly Queue _workItems;
        private volatile bool _stop;

        private void WriteThread()
        {
            while (!_stop)
            {
                //In reality, we should wait for something and not poll here
                Thread.Sleep(5);
                if (_workItems.Count > 0)
                {
                    _writer.Write(_workItems.Dequeue());
                }
            }
        }

        public AsyncLogger2(string file)
        {
            //Note that we're using the non-generic Queue here
            //because it has a Synchronized method for automatic
            //synchronization.  We will discuss synchronization in
            //more detail later.

            _writer = new StreamWriter(file);
            _workItems = Queue.Synchronized(new Queue());
            _thread = new Thread(new ThreadStart(WriteThread));
            _thread.Start();
        }

        public void WriteLogAsync(string message)
        {
            _workItems.Enqueue(message);
        }

        public void Close()
        {
            _stop = true;
            _thread.Join();
            _writer.Close();
        }
    }
}
