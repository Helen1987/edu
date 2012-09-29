using System;
using System.Runtime.Remoting;
using System.Threading;
using RemoteExec.Shared;

namespace RemoteExec.Client
{
    /// <summary>
    /// Connects to the remote execution server and executes the command specified
    /// by the command line arguments.  The command line arguments should be formatted
    /// as follows:
    ///     RemoteExec.Client.exe ServerName ExecutableName [Optional Arguments]
    /// For example, the following command launches Notepad on the local server:
    ///     RemoteExec.Client.exe localhost C:\Windows\notepad.exe
    /// </summary>
    class RemoteExecClient
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: RemoteExec.Client.exe <server_name> <exe_name> [argument1 [argument2...]]");
                return;
            }

            //Demonstrates synchronous execution.  The ExecuteSync command does not return
            //until execution completes.
            IRemoteExec rexec = (IRemoteExec)RemotingServices.Connect(typeof(IRemoteExec), String.Format("tcp://{0}:9090/RemoteExec.rem", args[0]));
            RemoteExecutionResult result = rexec.ExecuteSync(args[1], String.Join(" ", args, 2, args.Length - 2));
            Console.WriteLine("Execution result: " + result);

            //Demonstrates asynchronous execution.  Receives an execution token
            //and polls continuously until execution completes.
            RemoteExecutionToken token = rexec.ExecuteAsync(args[1], String.Join(" ", args, 2, args.Length - 2));
            if (token == RemoteExecutionToken.Invalid)
            {
                Console.WriteLine("An error occurred");
                return;
            }
            while (!rexec.IsComplete(token))
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine("Execution result: " + rexec.GetResult(token));
        }
    }
}
