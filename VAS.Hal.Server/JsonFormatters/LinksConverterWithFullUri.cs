using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using WebApi.Hal;

namespace VAS.Hal.Server.JsonFormatters
{
    // This class was copied verbatim in order to provide full URIs
    // including the sheme and authority. If changing version of WebApu.Hal
    // this should be changed also.

    // Decompiled with JetBrains decompiler
    // Type: WebApi.Hal.JsonConverters.LinksConverter
    // Assembly: WebApi.Hal, Version=2.5.1.0, Culture=neutral, PublicKeyToken=null
    // MVID: 8B918E90-A9E7-4A82-9A64-4C763F2146E3

    public class LinksConverterWithFullUri : JsonConverter
    {
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ILookup<string, Link> lookup = new HashSet<Link>((IEnumerable<Link>)value, Link.EqualityComparer).ToLookup(l => l.Rel);
            if (lookup.Count == 0)
                return;
            writer.WriteStartObject();
            foreach (IGrouping<string, Link> grouping in lookup)
            {
                int num = grouping.Count();
                writer.WritePropertyName(grouping.Key);
                if (num > 1 || grouping.Key == "curies")
                    writer.WriteStartArray();
                foreach (Link link in grouping)
                    WriteLink(writer, link);
                if (num > 1 || grouping.Key == "curies")
                    writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        private void WriteLink(JsonWriter writer, Link link)
        {
            writer.WriteStartObject();
            foreach (PropertyInfo propertyInfo in link.GetType().GetProperties())
            {
                switch (propertyInfo.Name.ToLowerInvariant())
                {
                    case "href":
                        writer.WritePropertyName("href");
                        writer.WriteValue(ResolveUri(link.Href));
                        goto case "rel";
                    case "rel":
                        break;
                    case "istemplated":
                        if (link.IsTemplated)
                        {
                            writer.WritePropertyName("templated");
                            writer.WriteValue(true);
                        }
                        goto case "rel";
                    default:
                        if (propertyInfo.PropertyType == typeof(string))
                        {
                            string str = propertyInfo.GetValue(link) as string;
                            if (!string.IsNullOrEmpty(str))
                            {
                                writer.WritePropertyName(propertyInfo.Name.ToLowerInvariant());
                                writer.WriteValue(str);
                            }
                            break;
                        }
                        goto case "rel";
                }
            }
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IList<Link>).IsAssignableFrom(objectType);
        }

        // Changed method in order to support full URI
        public virtual string ResolveUri(string href)
        {
            if (!string.IsNullOrEmpty(href) && VirtualPathUtility.IsAppRelative(href))
            {
                if (HttpContext.Current == null)
                {
                    return href.Replace("~/", "/");
                }
                    
                return string.Format(
                    "{0}://{1}{2}", 
                    HttpContext.Current.Request.Url.Scheme, 
                    HttpContext.Current.Request.Url.Authority, 
                    VirtualPathUtility.ToAbsolute(href));
            }
            return href;
        }
    }
}