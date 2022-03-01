namespace SolaERP.Server.ModelService
{
    public class WeatherForecastService
    {
        public WeatherForecastService()
        {
            WeatherForecastList = Enumerable.Range(1, 6).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Count())]
            })
            .ToList();
        }

        List<string> summaries = new List<string>() { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        
        public List<WeatherForecast> WeatherForecastList { get; set; }

    }
}
