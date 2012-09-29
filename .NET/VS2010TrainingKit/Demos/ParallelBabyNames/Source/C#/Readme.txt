PLINQ is a technology that allows developers to _easily_ leverage multiple cores. 
The great thing about PLINQ is that if you are using LINQ-to-objects, 
there is a very minimal impact to your code in order for it to use PLINQ. 
All it takes to use PLINQ is adding “.AsParallel()” to your query. 
This will turn the query into a PLINQ query and will use the PLINQ execution engine when executed.

            seqQuery = from n in names
                       where n.Name.Equals(queryInfo.Name, StringComparison.InvariantCultureIgnoreCase) &&
                             n.State == queryInfo.State && 
                             n.Year >= yearStart && n.Year <= yearEnd
                       orderby n.Year ascending
                       select n;

One small change, and your code now takes advantage of all the hardware available to you.

            parQuery = from n in names.AsParallel().WithDegreeOfParallelism(ProcessorsToUse.Value)
                       where n.Name.Equals(queryInfo.Name, StringComparison.InvariantCultureIgnoreCase) &&
                             n.State == queryInfo.State && 
                             n.Year >= yearStart && n.Year <= yearEnd
                       orderby n.Year ascending
                       select n;
