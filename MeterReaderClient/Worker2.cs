using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using MeterReaderWeb.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MeterReaderClient
{
    public class Worker2 : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly ReadingFactory _readingFactory;
        private MeterReadingService.MeterReadingServiceClient _client = null;

        public Worker2(ILogger<Worker> logger, IConfiguration configuration, ReadingFactory readingFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _readingFactory = readingFactory;
        }

        protected MeterReadingService.MeterReadingServiceClient Client
        {
            get
            {
                if (_client == null)
                {
                    var url = _configuration.GetValue<string>("Service:Url");
                    var channel = GrpcChannel.ForAddress(url);
                    _client = new MeterReadingService.MeterReadingServiceClient(channel);
                }
                return _client;
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var customerId = _configuration.GetValue<int>("Service:CustomerId");

                var stream = Client.SendDiagnostics();
                for (int i = 0; i < 5; i++)
                {
                    await stream.RequestStream.WriteAsync(await _readingFactory.Generate(customerId));
                }
                await stream.RequestStream.CompleteAsync();

                await Task.Delay(_configuration.GetValue<int>("Service:DelayInterval"), stoppingToken);
            }
        }
    }
}
