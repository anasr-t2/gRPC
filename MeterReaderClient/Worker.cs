using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using MeterReaderWeb.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MeterReaderClient
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly ReadingFactory _readingFactory;
        private MeterReadingService.MeterReadingServiceClient _client = null;
        private string _token;
        private DateTime _expiration = DateTime.MinValue;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, ReadingFactory readingFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _readingFactory = readingFactory;
        }

        protected bool NeedsLogin() => string.IsNullOrWhiteSpace(_token) || _expiration > DateTime.UtcNow;

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

                Readingpacket request = new Readingpacket
                {
                    ReadingStatus = ReadingStatus.Success,
                    Notes = "test test"
                };

                for (int i = 0; i < 5; i++)
                {
                    request.Readings.Add(await _readingFactory.Generate(customerId));
                }

                try
                {
                    if (!NeedsLogin() || await RequestToken())
                    {
                        var headers = new Metadata
                        {
                            { "Authorization", $"Bearer {_token}" }
                        };

                        var statusMessage = await Client.AddReadingAsync(request,headers:headers);

                        if (statusMessage.ReadingStatus == ReadingStatus.Success)
                        {
                            _logger.LogInformation("successfully saved");
                        }
                        else
                        {
                            _logger.LogInformation($"failed to save -- {statusMessage.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
               


                await Task.Delay(_configuration.GetValue<int>("Service:DelayInterval"), stoppingToken);
            }
        }

        private async Task<bool> RequestToken()
        {
            var response = await Client.CreateTokenAsync(new TokenRequest { Username = "anasr@integrant.com", Password = "P@ssw0rd1" });
            if (response.Success)
            {
                _token = response.Token;
                _expiration = response.Expiration.ToDateTime();
            }
            return response.Success;
        }
    }
}
