using System;
using System.Collections.Generic;

namespace PluginFramework.Host
{
    /// <summary>
    /// Initializes an array of 100 random numbers in the range [0,1) and outputs the result
    /// of the various plugin operations on these numbers.  The plugins are not loaded directly
    /// into the default application domain: For isolation purposes, each plugin is loaded into
    /// a separate application domain.
    /// </summary>
    class HostMain
    {
        static void Main(string[] args)
        {
            string[] pluginAssemblies = { "PluginFramework.ArithmeticPlugin.dll", "PluginFramework.StatisticsPlugin.dll" };

            List<OperationWrapper> operations = new List<OperationWrapper>();
            foreach (string assembly in pluginAssemblies)
            {
                foreach (string type in TypeInvestigator.GetExportedTypesFromAssembly(assembly))
                {
                    operations.Add(new OperationWrapper(assembly, type));
                }
            }

            Random rand = new Random();
            double[] input = new double[100];
            for (int i = 0; i < input.Length; ++i)
                input[i] = rand.NextDouble();

            operations.ForEach(op => Console.WriteLine(op.Name + ": " + op.Operation(input)));
        }
    }
}
