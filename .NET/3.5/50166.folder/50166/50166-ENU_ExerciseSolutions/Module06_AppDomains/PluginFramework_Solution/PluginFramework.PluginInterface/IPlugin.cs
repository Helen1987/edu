
namespace PluginFramework.PluginInterface
{
    /// <summary>
    /// Represents a plugin that aggregates an array of double-precision numbers
    /// to a single double-precision number.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Gets the plugin's name.
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Performs this plugin's operation on the specified array of double-precision
        /// number and returns the aggregation result.
        /// </summary>
        /// <param name="input">The array of numbers.</param>
        /// <returns>The aggregation result.</returns>
        double Operation(double[] input);
    }
}
