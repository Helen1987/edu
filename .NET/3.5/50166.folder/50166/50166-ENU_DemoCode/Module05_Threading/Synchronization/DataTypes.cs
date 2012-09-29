using System.Threading;

namespace Synchronization
{
    /// <summary>
    /// A simple counter which is used for demonstrating potential
    /// synchronization problems.
    /// </summary>
    class Counter
    {
        private int _value;

        public int Next() { return ++_value; }

        public int Current { get { return _value; } }
    }

    /// <summary>
    /// A counter that is protected with interlocked operations
    /// to make sure its value is atomically incremented.
    /// </summary>
    class InterlockedCounter
    {
        private int _value;

        public int Next()
        {
            return Interlocked.Increment(ref _value);
        }

        public int Current { get { return _value; } }
    }

    /// <summary>
    /// A bank account object that is protected with manual synchronization
    /// using the C# 'lock' statement.
    /// </summary>
    class BankAccount
    {
        public decimal Balance { get; private set; }

        //A private object to use for synchronization.  Note that using the
        //enclosing object ('this') or any other public object for synchronization
        //is dangerous because it is accessible (and can be locked) by code
        //external to the class.  This can introduce potential deadlocks between
        //the class code and its clients.
        private readonly object _syncRoot = new object();

        public void Deposit(decimal amount)
        {
            //Modification of the balance is performed within a lock:
            lock (_syncRoot)
            {
                Balance += amount;
            }
        }

        public void Withdraw(decimal amount)
        {
            //Modification of the balance is performed within a lock:
            lock (_syncRoot)
            {
                Balance -= amount;
            }
        }
    }

    /// <summary>
    /// An equivalent example of a bank account object that manually calls
    /// Monitor.Enter and Monitor.Exit to achieve synchronization.  Note that
    /// all work is enclosed in try...finally clauses so that the monitor is
    /// always released before the method returns.
    /// </summary>
    class BankAccountWithMonitor
    {
        public decimal Balance { get; private set; }

        private readonly object _syncRoot = new object();

        public void Deposit(decimal amount)
        {
            //Absolutely equivalent to using the 'lock' statement
            Monitor.Enter(_syncRoot);
            try
            {
                Balance += amount;
            }
            finally
            {
                Monitor.Exit(_syncRoot);
            }
        }

        public void Withdraw(decimal amount)
        {
            //Absolutely equivalent to using the 'lock' statement
            Monitor.Enter(_syncRoot);
            try
            {
                Balance -= amount;
            }
            finally
            {
                Monitor.Exit(_syncRoot);
            }
        }
    }
}
