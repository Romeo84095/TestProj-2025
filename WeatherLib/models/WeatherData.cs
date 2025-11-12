using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherLib.models
{
    public class WeatherDataWrapper
    {
        public WeatherDataWrapper() { WeatherData = new WeatherData(); lastQuery = DateTime.MinValue; }
        public WeatherDataWrapper(WeatherData weatherData) { WeatherData = weatherData; lastQuery = DateTime.MinValue; }
        public WeatherData WeatherData { get; set; }
        public DateTime lastQuery;

    }
        public class WeatherData
    {
        public WeatherData() { }

        public void Validate()
        {
            Dt = DateTimeOffset.FromUnixTimeSeconds(DtI).UtcDateTime;
            if (Sys != null)
            {
                Sys.Sunrise = DateTimeOffset.FromUnixTimeSeconds(Sys.SunriseI).UtcDateTime;
                Sys.Sunset = DateTimeOffset.FromUnixTimeSeconds(Sys.SunsetI).UtcDateTime;
            }
        }

        [JsonPropertyName("base")]
        public String Base { get; set; }


        [JsonPropertyName("clouds")]
        public CClouds Clouds { get; set; }


        [JsonPropertyName("cod")]
        public Int32 Cod { get; set; }


        [JsonPropertyName("coord")]
        public CCoord Coord { get; set; }


        [JsonPropertyName("dt")]
        public Int32 DtI { get; set; }

        public DateTime Dt { get; set; }


        [JsonPropertyName("id")]
        public Int32 Id { get; set; }

        [JsonPropertyName("main")]
        public CMain Main { get; set; }

        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("sys")]
        public CSys Sys { get; set; }


        [JsonPropertyName("timezone")]
        public Int32 Timezone { get; set; }


        [JsonPropertyName("visibility")]
        public Int32 Visibility { get; set; }


        [JsonPropertyName("weather")]
        public List<CWeather> Weather { get; set; }


        [JsonPropertyName("wind")]
        public CWind Wind { get; set; }







        public class CClouds
        {
            [JsonPropertyName("all")]
            public Int32 All { get; set; }
        }

        public class CCoord
        {
            [JsonPropertyName("lat")]
            public Decimal Lat { get; set; }
            [JsonPropertyName("lon")]
            public Decimal Lon { get; set; }
        }
        public class CMain
        {
            [JsonPropertyName("feels_like")]
            public Decimal Feels_like { get; set; }

            [JsonPropertyName("grnd_level")]
            public Int32 Grnd_level { get; set; }

            [JsonPropertyName("humidity")]
            public Int32 Humidity { get; set; }

            [JsonPropertyName("pressure")]
            public Int32 Pressure { get; set; }

            [JsonPropertyName("sea_level")]
            public Int32 Sea_level { get; set; }

            [JsonPropertyName("temp")]
            public Decimal Temp { get; set; }

            [JsonPropertyName("temp_max")]
            public Decimal Temp_max { get; set; }

            [JsonPropertyName("temp_min")]
            public Decimal Temp_min { get; set; }
        }

        public class CSys
        {
            [JsonPropertyName("country")]
            public String Country { get; set; }

            [JsonPropertyName("id")]
            public Int32 Id { get; set; }

            [JsonPropertyName("sunrise")]
            public Int32 SunriseI { get; set; }

            public DateTime Sunrise { get; set; }

            [JsonPropertyName("sunset")]
            public Int32 SunsetI { get; set; }

            public DateTime Sunset { get; set; }

            [JsonPropertyName("type")]
            public Int32 Type { get; set; }
        }

        public class CWeather
        {
            [JsonPropertyName("description")]
            public String Description { get; set; }

            [JsonPropertyName("icon")]
            public String Icon { get; set; }

            [JsonPropertyName("id")]
            public Int32 Id { get; set; }

            [JsonPropertyName("main")]
            public String Main { get; set; }
        }

        public class CWind
        {
            [JsonPropertyName("deg")]
            public Int32 Deg { get; set; }

            [JsonPropertyName("gust")]
            public Decimal Gust { get; set; }

            [JsonPropertyName("speed")]
            public Decimal Speed { get; set; }
        }
    }
}
