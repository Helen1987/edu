
namespace QueuingWork
{
    /// <summary>
    /// Represents an immutable work item which can either consist of work
    /// or denote an "end-of-work" condition.
    /// </summary>
    /// <typeparam name="T">The type of the item.</typeparam>
    internal class WorkItem<T>
    {
        public WorkItem(T work)
        {
            IsWorkDone = false;
            Work = work;
        }

        /// <summary>
        /// The special "end-of-work" condition work item instance.
        /// </summary>
        public static WorkItem<T> Done = new WorkItem<T>(default(T)) { IsWorkDone = true };

        /// <summary>
        /// True if this is the special "end-of-work" work item.
        /// </summary>
        public bool IsWorkDone { get; private set; }

        public T Work { get; private set; }
    }
}
