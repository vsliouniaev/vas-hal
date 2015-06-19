using System.Linq;
using WebApi.Hal;

namespace VAS.Hal.Server.JsonFormatters
{
    /// <summary>
    /// A converter which will return absolute URIs, including the scheme and authority
    /// </summary>
    // Be careful when making changes to the version of the library as the implemetnation
    // of the base class is not well suited to inheriting from.

    // Assembly: WebApi.Hal, Version=2.5.1.0, Culture=neutral, PublicKeyToken=null
    // MVID: 8B918E90-A9E7-4A82-9A64-4C763F2146E3

    internal class JsonHalMediaTypeFormatterWithFullUri : JsonHalMediaTypeFormatter
    {
        public JsonHalMediaTypeFormatterWithFullUri()
        {
            OverrideConfiguredLinksSerializer();
        }

        protected void OverrideConfiguredLinksSerializer()
        {
            var wrongConverter = SerializerSettings.Converters.FirstOrDefault(
                x => x.GetType() == typeof(WebApi.Hal.JsonConverters.LinksConverter));

            SerializerSettings.Converters.Remove(wrongConverter);

            (SerializerSettings).Converters.Add(new LinksConverterWithFullUri());
        }
    }
}
