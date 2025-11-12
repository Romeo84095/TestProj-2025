using System.Collections.Generic;
using System.Diagnostics;
using WeatherLib.models;

namespace WeatherLib
{
    public class WeatherLib
    {
        WeatherLib(string apiKey) { this.apiKey = apiKey; pollingMode = false; weatherDataList = new Queue<KeyValuePair<string, models.WeatherDataWrapper>>(); }
        WeatherLib(string apiKey, bool pollingMode) { this.apiKey = apiKey; if (pollingMode) EnablePollingMode(); weatherDataList = new Queue<KeyValuePair<string, models.WeatherDataWrapper>>(); }
        static WeatherLib()
        {
            _instance = null;
            mainList = new Dictionary<string, WeatherLib>();
        }
        public WeatherLib Get { get { return _instance; } }

        private static WeatherLib? _instance;




        public static WeatherLib CreateService(string apiKey, bool pollingMode = false)
        {
            if (mainList.Where(w => w.Key == apiKey).Count() > 0)
            {
                throw new Exception("Service with given key already exists");
                //return null;
            }

            WeatherLib retVar;
            if (!pollingMode)
                retVar = new WeatherLib(apiKey);
            else
                retVar = new WeatherLib(apiKey, pollingMode);

            mainList.Add(apiKey, retVar);

            return retVar;
        }

        public static WeatherLib GetService(string apiKey)
        {
            WeatherLib? retVar = null;
            retVar = mainList.Where(w => w.Key == apiKey).FirstOrDefault().Value;

            return retVar;
        }

        public static void DeleteService(string apiKey)
        {
            mainList.Remove(apiKey);
        }

        public String GetWeatherInfoJson(string city) {
            return System.Text.Json.JsonSerializer.Serialize(new models.WeatherDataOut(GetWeatherInfo(city)), ExtMethods.JsonExtensionsMy.GetJsonSerializerOptions());
        }

        public WeatherData GetWeatherInfo(string city)
        {
            Console.WriteLine($"GetWeatherInfo begin");
            Console.WriteLine($"City: {city}");
            var retVar = new WeatherData();
            if (weatherDataList.Where(w => w.Key == city).FirstOrDefault().Value == null)
            {
                Console.WriteLine($"Adding new record to queue");
                retVar = new WeatherServ().GetWeatherData(apiKey, city);
                weatherDataList.Enqueue(new KeyValuePair<string, WeatherDataWrapper>(city, new WeatherDataWrapper(retVar))); if (weatherDataList.Count > 10) weatherDataList.Dequeue();
                weatherDataList.LastOrDefault().Value.lastQuery = DateTime.UtcNow;
            }
            else
            {
                var lastQuery = weatherDataList.Where(w => w.Key == city).FirstOrDefault().Value?.lastQuery ?? DateTime.MinValue;
                if ((DateTime.UtcNow - lastQuery) > TimeSpan.FromMinutes(10))
                {
                    Console.WriteLine($"Updating existing record in queue");
                    retVar = new WeatherServ().GetWeatherData(apiKey, city);
                    weatherDataList.Where(w => w.Key == city).FirstOrDefault().Value.WeatherData = retVar;
                    weatherDataList.Where(w => w.Key == city).FirstOrDefault().Value.lastQuery = DateTime.UtcNow;
                }
                else
                {
                    Console.WriteLine($"Using existing record in queue");
                    retVar = weatherDataList.Where(w => w.Key == city).FirstOrDefault().Value.WeatherData;
                }
            }

            Console.WriteLine($"GetWeatherInfo end");
            return retVar;
        }

        static Dictionary<string, WeatherLib> mainList;

        string apiKey;

        bool pollingMode;

        Queue<KeyValuePair<string, models.WeatherDataWrapper>> weatherDataList;

        System.Timers.Timer timer;
        void EnablePollingMode()
        {
            timer = new System.Timers.Timer(1000 * 10);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine($"Timer_Elapsed, apiKey: {apiKey}");
            weatherDataList.ToList().ForEach(e =>
            {
                if (e.Value != null)
                {
                    GetWeatherInfo(e.Key);
                }
            });
        }
    }
}
