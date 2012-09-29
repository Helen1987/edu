using System.Text.RegularExpressions;

namespace RegexWrapper
{
    public class WrappedRegex
    {
        public bool Match(string regex, string text)
        {
            Regex expr = new Regex(regex);
            return expr.IsMatch(text);
        }
    }
}
