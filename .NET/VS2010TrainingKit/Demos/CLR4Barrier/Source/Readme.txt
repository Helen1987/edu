A Barrier enforces the stopping of execution between a number of threads preventing further execution until all threads have reached the given point.

In DriveToBoston method, look at the following code:
	sync.SignalAndWait(token)

With every call to SignalAndWait(), the number of signals received by the barrier is incremented. Once the number of signals received reaches the number of participants the Barrier was constructed with, all threads are then allowed to continue execution.

-----
Uncomment the following method call to see how the thread execution can be cancelled.
	source.Cancel()