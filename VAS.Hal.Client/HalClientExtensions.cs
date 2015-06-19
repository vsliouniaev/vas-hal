using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using HalKit;
using HalKit.Models.Response;

namespace VAS.Hal.Client
{
    public static class HalClientExtensions
    {
        public static Task<T> GetAsync<T>(this HalClient client, Link link, object obj)
        {
            var props = new List<PropertyInfo>(obj.GetType().GetProperties());

            var dictionary = new Dictionary<string, string>();

            foreach (var prop in props)
            {
                var name = prop.Name;
                var val = prop.GetValue(obj, null).ToString();
                dictionary.Add(name, val);
            }

            return client.GetAsync<T>(link, dictionary);
        }
    }
}
