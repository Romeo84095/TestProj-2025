using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherLib.models;

namespace WeatherLib
{
    internal class WeatherServ  // Weather service
    {
        public WeatherServ() { }
        public WeatherData GetWeatherData(string apiKey, string city)
        {
            var err = "";  // If this var is not empty then there are an error occured...
            WeatherData retVar = new WeatherData();
            city = city.ToLower().Replace("\"", "").Replace("\"", "").Replace("\r", "").Replace("\n", "").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");

            using (HttpClient client = new())
            {
                var reqStr = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&lang=en&units=metric";
                var respStr = "";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var resp = client.GetAsync(reqStr).Result;
                //var resp = new HttpResponseMessage(System.Net.HttpStatusCode.OK); resp.Content = new StringContent("{\"coord\":{\"lon\":37.6156,\"lat\":55.7522},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04n\"}],\"base\":\"stations\",\"main\":{\"temp\":8.77,\"feels_like\":7.21,\"temp_min\":8.24,\"temp_max\":9.65,\"pressure\":1023,\"humidity\":62,\"sea_level\":1023,\"grnd_level\":1004},\"visibility\":10000,\"wind\":{\"speed\":2.73,\"deg\":307,\"gust\":7.31},\"clouds\":{\"all\":95},\"dt\":1762278406,\"sys\":{\"type\":2,\"id\":2095214,\"country\":\"RU\",\"sunrise\":1762231310,\"sunset\":1762263860},\"timezone\":10800,\"id\":524901,\"name\":\"Moscow\",\"cod\":200}");
                if (resp != null)
                {
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        respStr = resp.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        err = $"Err: {resp.StatusCode.ToString()}";
                    }
                    err = "Err: Response is [NULL]";
                }

                retVar = DeserializeCustMy(respStr);
            }

            return retVar;
        }

        WeatherData DeserializeCustMy(string str)
        {
            WeatherData retVar = new();
            var err = "";
            try
            {
                retVar = System.Text.Json.JsonSerializer.Deserialize(str, typeof(WeatherData), ExtMethods.JsonExtensionsMy.GetJsonSerializerOptions()) as WeatherData;
                retVar.Validate();
            }
            catch { err = "Err: Error while trying to read json response"; }
            if (retVar == null)
                retVar = new WeatherData();
            return retVar;
        }
    }
}
