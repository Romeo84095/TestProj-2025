using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherLib
{
    internal class ExtMethods
    {
        public class JsonExtensionsMy
        {
            public static System.Text.Json.JsonSerializerOptions GetJsonSerializerOptions() { JsonSerializerOptions jso = new JsonSerializerOptions() { }; jso.Converters.Add(new DateTimeConverterMyCust()); return jso; }

            public class DateTimeConverterMyCust : System.Text.Json.Serialization.JsonConverter<DateTime>
            {
                public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                {
                    return DateTime.Parse(reader.GetString());
                }

                public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
                {
                    writer.WriteStringValue(Settings.GetDateTimeUtc(value));
                }
            }
        }
    }
}
