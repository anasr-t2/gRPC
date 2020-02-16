using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast;

namespace MeterReaderWeb.Services
{
    public class WeatherService: WeatherForecasts.WeatherForecastsBase
    {
        private readonly ILogger _logger;
        public WeatherService(ILogger<WeatherService> logger)
        {
            _logger = logger;
        }

        public override async Task GetWeatherStream(Empty request, IServerStreamWriter<WeatherData> responseStream, ServerCallContext context)
        {
            var rng = new Random();
            var now = DateTime.UtcNow;

            var i = 0;
            while (!context.CancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
                var forecast = new WeatherData
                {
                    DateTimeStamp = Timestamp.FromDateTime(now.AddDays(i++)),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = "bla bla bla"
                };

                _logger.LogInformation("Sending WeatherData response");
                try
                {
                    await responseStream.WriteAsync(forecast);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
        }
    }
}
