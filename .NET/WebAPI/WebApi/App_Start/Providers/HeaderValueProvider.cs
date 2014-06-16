using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.ValueProviders;

namespace WebApi.App_Start.Providers
{
    /// <summary>
    /// we need to extract an action parameter from a header
    /// </summary>
    public class HeaderValueProvider : IValueProvider
    {
        public HttpRequestHeaders Headers { get; set; }

        public HeaderValueProvider(HttpRequestHeaders headers)
        {
            Headers = headers;
        }

        /// <summary>
        /// is called to verify that the header contains the information that we need
        /// </summary>
        /// <param name="prefix">name of the action</param>
        /// <returns></returns>
        public bool ContainsPrefix(string prefix) 
        {
            return Headers.Any(s => s.Key.StartsWith(prefix));
        }

        /// <summary>
        ///  is called to extract the information from the header
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ValueProviderResult GetValue(string key) 
        { 
            KeyValuePair<string, IEnumerable<string>> header = 
                Headers.FirstOrDefault(s => s.Key.StartsWith(key));
            string headerValue = string.Join(",", header.Value);
            return new ValueProviderResult(headerValue, headerValue, CultureInfo.InvariantCulture);
        }
    } 
}