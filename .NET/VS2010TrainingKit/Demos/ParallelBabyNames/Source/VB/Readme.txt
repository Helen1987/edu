PLINQ is a technology that allows developers to _easily_ leverage multiple cores. 
The great thing about PLINQ is that if you are using LINQ-to-objects, 
there is a very minimal impact to your code in order for it to use PLINQ. 
All it takes to use PLINQ is adding “.AsParallel()” to your query. 
This will turn the query into a PLINQ query and will use the PLINQ execution engine when executed.

            seqQuery = _
             From n In names _
             Where n.Name.Equals(info.Name, StringComparison.InvariantCultureIgnoreCase) AndAlso n.State = info.State AndAlso n.Year >= yearStart AndAlso n.Year <= yearEnd _
             Order By n.Year Ascending _
             Select n

One small change, and your code now takes advantage of all the hardware available to you.

            parQuery = _
             From n In names.AsParallel().WithDegreeOfParallelism(ProcessorsToUse.Value) _
             Where n.Name.Equals(info.Name, StringComparison.InvariantCultureIgnoreCase) AndAlso n.State = info.State AndAlso n.Year >= yearStart AndAlso n.Year <= yearEnd _
             Order By n.Year Ascending _
             Select n