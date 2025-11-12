using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib.models
{
    internal class WeatherDataOut
    {
        public CWeather Weather { get; set; }
        public CTemperature Temperature { get; set; }
        public Int32 Visibility { get; set; }
        public CWind Wind { get; set; }
        public DateTime VDateTimeDt { get; set; }
        public Int32 VDateTime { get; set; }
        public CSys Sys { get; set; }
        public Int32 TimeZone {  get; set; }
        public String Name { get; set; }

        public WeatherDataOut() { Init(); }
        public WeatherDataOut(WeatherData weatherData)
        {
            Init();
            ConvertCurrObj(weatherData);
        }
        public void Init() { Weather = new CWeather(); Temperature = new CTemperature(); Wind = new CWind(); VDateTimeDt = DateTime.MinValue; Sys = new CSys(); }
        public void Validate() { Sys.Validate(); }

        void ConvertCurrObj(WeatherData weatherData)
        {
            this.Weather.Main = weatherData.Weather.FirstOrDefault()?.Main ?? "";
            this.Weather.Description = weatherData.Weather.FirstOrDefault()?.Description ?? "";
            this.Temperature.Temp = weatherData.Main.Temp;
            this.Temperature.FeelsLike = weatherData.Main.Feels_like;
            this.Visibility = weatherData.Visibility;
            this.Wind.Speed = weatherData.Wind.Speed;
            this.VDateTimeDt = weatherData.Dt; this.VDateTime = weatherData.DtI;
            this.Sys.SunriseDt = weatherData.Sys.Sunrise; this.Sys.Sunrise = weatherData.Sys.SunriseI;
            this.Sys.SunSetDt = weatherData.Sys.Sunset; this.Sys.SunSet = weatherData.Sys.SunsetI;
            this.TimeZone = weatherData.Timezone;
            this.Name = weatherData.Name;

        }
        WeatherDataOut ConvertMyCust(WeatherData weatherData) {
            var retVar = new WeatherDataOut();
            retVar.Weather.Main = weatherData.Weather.FirstOrDefault()?.Main?? "";
            retVar.Weather.Description = weatherData.Weather.FirstOrDefault()?.Description ?? "";
            retVar.Temperature.Temp = weatherData.Main.Temp;
            retVar.Temperature.FeelsLike = weatherData.Main.Feels_like;
            retVar.Visibility = weatherData.Visibility;
            retVar.Wind.Speed = weatherData.Wind.Speed;
            retVar.VDateTimeDt = weatherData.Dt; retVar.VDateTime = weatherData.DtI;
            retVar.Sys.SunriseDt = weatherData.Sys.Sunrise; retVar.Sys.Sunrise = weatherData.Sys.SunriseI;
            retVar.Sys.SunSetDt = weatherData.Sys.Sunset; retVar.Sys.SunSet = weatherData.Sys.SunsetI;
            retVar.TimeZone = weatherData.Timezone;
            retVar.Name = weatherData.Name;
            return retVar;
        }



        public class CWeather
        {
            public string Main { get; set; }
            public string Description { get; set; }
        }
        public class CTemperature
        {
            public decimal Temp { get; set; }
            public decimal FeelsLike { get; set; }

            public CTemperature() { Temp = decimal.MinValue; FeelsLike = decimal.MinValue; }
        }
        public class CWind
        {
            public decimal Speed { get; set; }
            public CWind() { Speed = decimal.MinValue; }
        }

        public class CSys
        {
            public DateTime SunriseDt { get; set; }
            public Int32 Sunrise { get; set; }
            public DateTime SunSetDt { get; set; }
            public Int32 SunSet { get; set; }
            public CSys() { SunriseDt = DateTime.MinValue; SunSetDt = DateTime.MinValue; }
            public void Validate() {
                try
                {
                    Sunrise = Convert.ToInt32(new DateTimeOffset(SunriseDt).ToUnixTimeSeconds());
                }catch(Exception) { }
                try
                {
                    SunSet = Convert.ToInt32(new DateTimeOffset(SunSetDt).ToUnixTimeSeconds());
                }
                catch (Exception) { }
            }
        }
    }
}
