namespace WeatherApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main begin");
            //new Program().Test00();
            new Program().Test01();

            Console.ReadKey();
        }



        void Test01()
        {
            var serv = WeatherLib.WeatherLib.CreateService("49939fd9c137dfdfe3b428667eb6ae3c", false); // Use true value to activate polling mode
            var resp = serv.GetWeatherInfo("Tel-Aviv");
            resp = serv.GetWeatherInfo("Tel-Aviv");
            resp = serv.GetWeatherInfo("London");
            resp = serv.GetWeatherInfo("Moscow");
            resp = serv.GetWeatherInfo("Paris");
            resp = serv.GetWeatherInfo("Tokio");
            resp = serv.GetWeatherInfo("Las Vegas");
            resp = serv.GetWeatherInfo("New York");
            resp = serv.GetWeatherInfo("Los Angeles");
            resp = serv.GetWeatherInfo("Sidney");
            resp = serv.GetWeatherInfo("Baer Sheva");
            resp = serv.GetWeatherInfo("Dallas");
            resp = serv.GetWeatherInfo("Las Vegas");

            var respJson = "";
            respJson = serv.GetWeatherInfoJson("Las Vegas");
        }

        void Test00()
        {
            WeatherLib.WeatherLib.CreateService("key0");
            
            WeatherLib.WeatherLib.GetService("key0");
            WeatherLib.WeatherLib.GetService("key1");

            WeatherLib.WeatherLib.CreateService("key0");
        }
    }
}
