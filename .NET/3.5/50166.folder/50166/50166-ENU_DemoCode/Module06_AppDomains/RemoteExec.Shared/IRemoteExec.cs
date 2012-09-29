using System;

namespace RemoteExec.Shared
{
    /// <summary>
    /// Represents an execution token that can be used to query
    /// a command's execution state.
    /// </summary>
    [Serializable]
    public struct RemoteExecutionToken
    {
        private static int _nextToken;

        public static RemoteExecutionToken Next()
        {
            return new RemoteExecutionToken { Key = _nextToken++ };
        }

        public static readonly RemoteExecutionToken Invalid = new RemoteExecutionToken { Key = -1 };

        public int Key { get; private set; }

        #region Value type nuts and bolts

        public override bool Equals(object obj)
        {
            RemoteExecutionToken other = (RemoteExecutionToken)obj;
            return Equals(other);
        }

        public bool Equals(RemoteExecutionToken token)
        {
            return Key == token.Key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public static bool operator ==(RemoteExecutionToken first, RemoteExecutionToken second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(RemoteExecutionToken first, RemoteExecutionToken second)
        {
            return !(first == second);
        }

        #endregion
    }

    /// <summary>
    /// Represents the execution result of a remote command.
    /// </summary>
    public enum RemoteExecutionResult
    {
        /// <summary>
        /// The command executed successfully.
        /// </summary>
        Success,
        /// <summary>
        /// The command is still executing.
        /// </summary>
        StillExecuting,
        /// <summary>
        /// The command's execution failed.
        /// </summary>
        Failure
    }

    /// <summary>
    /// The interface to the remote execution server.  Supports synchronous and
    /// asynchronous execution with a polling model (no callback).
    /// </summary>
    public interface IRemoteExec
    {
        /// <summary>
        /// Executes the specified command on the remote server and returns
        /// the result.  This operation is synchronous.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="arguments">The command's command line arguments.</param>
        /// <returns>The execution result.</returns>
        RemoteExecutionResult ExecuteSync(string command, string arguments);
        
        /// <summary>
        /// Executes the specified command on the remote server and returns
        /// an execution token that can be used to query the command's status
        /// and result.  This operation is asynchronous.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="arguments">The command's command line arguments.</param>
        /// <returns>An execution token, or RemoteExecutionToken.Invalid if the
        /// command could not be executed.</returns>
        RemoteExecutionToken ExecuteAsync(string command, string arguments);

        /// <summary>
        /// Checks whether the command represented by the specified execution
        /// token has finished executing.
        /// </summary>
        /// <param name="token">The execution token.</param>
        /// <returns>true iff the command has finished executing.</returns>
        bool IsComplete(RemoteExecutionToken token);

        /// <summary>
        /// Retrieves the asynchronous result of the command represented by
        /// the specified execution token.
        /// </summary>
        /// <param name="token">The execution token.</param>
        /// <returns>The command's execution result.  If the command has not
        /// yet finished executing, RemoteExecutionResult.StillExecuting will
        /// be returned.</returns>
        RemoteExecutionResult GetResult(RemoteExecutionToken token);
    }
}
