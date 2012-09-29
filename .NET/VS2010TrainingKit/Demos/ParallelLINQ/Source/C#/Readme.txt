PLINQ is a technology that allows developers to _easily_ leverage multiple cores. 
The great thing about PLINQ is that if you are using LINQ-to-objects, 
there is a very minimal impact to your code in order for it to use PLINQ. 
All it takes to use PLINQ is adding “.AsParallel()” to your query. 
This will turn the query into a PLINQ query and will use the PLINQ execution engine when executed.


Remove the AsParallel method in the PLINQ query and you will have a LINQ query which runs sequentially.

            IEnumerable<int> results = from n in numbers.AsParallel()
                                       where IsDivisibleByFive(n)
                                       select n;
            IEnumerable<int> results = from n in numbers
                                       where IsDivisibleByFive(n)
                                       select n;
