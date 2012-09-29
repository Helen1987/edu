using System;
using System.Linq;
using PluginFramework.PluginInterface;

namespace PluginFramework.ArithmeticPlugin
{
    [Plugin("Sum")]
    public class Sum : PluginBase
    {
        public override double Operation(double[] input)
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            return input.Sum();
        }
    }

    [Plugin("Product")]
    public class Product : PluginBase
    {
        public override double Operation(double[] input)
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            return input.Aggregate(1.0, (acc, x) => acc *= x);
        }
    }
}
