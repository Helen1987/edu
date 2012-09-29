using System;
using System.Linq;
using PluginFramework.PluginInterface;

namespace PluginFramework.StatisticsPlugin
{
    [Plugin("Median", Complexity.Quadratic)]
    public class Median : PluginBase
    {
        public override double Operation(double[] input)
        {
            //Note: there are algorithms for finding a median in O(n) complexity
            //without completely sorting the input.  However, this is not important
            //for our demonstration purposes.
            Array.Sort(input);

            int len = input.Length;
            if (len % 2 == 0)
                return (input[len / 2 - 1] + input[len / 2]) / 2;
            return input[len / 2];
        }
    }

    [Plugin("Mean")]
    public class Mean : PluginBase
    {
        public override double Operation(double[] input)
        {
            return input.Average();
        }
    }

    [Plugin("Minimum")]
    public class Minimum : PluginBase
    {
        public override double Operation(double[] input)
        {
            return input.Min();
        }
    }

    [Plugin("Maximum")]
    public class Maximum : PluginBase
    {
        public override double Operation(double[] input)
        {
            return input.Max();
        }
    }

    [Plugin("Variance")]
    public class Variance : PluginBase
    {
        public override double Operation(double[] input)
        {
            double sum = 0, sumSquares = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                sum += input[i];
                sumSquares += input[i] * input[i];
            }

            double mean = new Mean().Operation(input);
            return (sumSquares - input.Length * mean * mean) / (input.Length - 1);
        }
    }
}
