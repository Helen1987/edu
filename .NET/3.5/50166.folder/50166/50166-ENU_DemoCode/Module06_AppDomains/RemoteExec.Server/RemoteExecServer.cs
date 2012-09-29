using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RemoteExec.Shared;

namespace RemoteExec.Server
{
    /// <summary>
    /// A .NET Remoting server that implements the IRemoteExec interface,
    /// enabling synchronous and asynchronous remote execution of commands.
    /// </summary>
    class RemoteExecServer : MarshalByRefObject, IRemoteExec
    {
        /// <summary>
        /// Registers a remoting channel and begins listening on port 9090
        /// for remote execution requests.
        /// </summary>
        static void Main(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpChannel(9090), false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteExecServer), "RemoteExec.rem", WellKnownObjectMode.Singleton);

            Console.WriteLine("Server is listening, press RETURN to terminate.");
            Console.ReadLine();
        }

        private Dictionary<RemoteExecutionToken, Process> _runningTasks = new Dictionary<RemoteExecutionToken, Process>();
        
        public RemoteExecutionResult ExecuteSync(string command, string arguments)
        {
            try
            {
                Process process = Process.Start(command, arguments);
                process.WaitForExit();
                return RemoteExecutionResult.Success;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e);
                return RemoteExecutionResult.Failure;
            }
        }

        public RemoteExecutionToken ExecuteAsync(string command, string arguments)
        {
            try
            {
                Process process = Process.Start(command, arguments);
                RemoteExecutionToken token = RemoteExecutionToken.Next();
                lock (_runningTasks)
                {
                    _runningTasks.Add(token, process);
                }
                return token;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e);
                return RemoteExecutionToken.Invalid;
            }
        }

        public bool IsComplete(RemoteExecutionToken token)
        {
            lock (_runningTasks)
            {
                return _runningTasks[token].HasExited;
            }
        }

        public RemoteExecutionResult GetResult(RemoteExecutionToken token)
        {
            lock (_runningTasks)
            {
                if (_runningTasks.ContainsKey(token))
                {
                    if (_runningTasks[token].HasExited)
                    {
                        _runningTasks.Remove(token);
                        return RemoteExecutionResult.Success;
                    }
                    return RemoteExecutionResult.StillExecuting;
                }
            }
            return RemoteExecutionResult.Failure;
        }
    }
}
