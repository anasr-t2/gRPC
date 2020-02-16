using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MeterReaderLib;
using MeterReaderWeb.Data;
using MeterReaderWeb.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterReaderWeb.Services
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MeterService : MeterReadingService.MeterReadingServiceBase
    {
        private readonly ILogger _logger;
        private readonly IReadingRepository _readingRepository;
        private readonly JwtTokenValidationService _jwtTokenValidationService;

        public MeterService(
            ILogger<MeterService> logger, 
            IReadingRepository readingRepository,
            JwtTokenValidationService jwtTokenValidationService)
        {
            _logger = logger;
            _readingRepository = readingRepository;
            _jwtTokenValidationService = jwtTokenValidationService;
        }

        //public override Task<GeneratedGreeting> GenerateGreeting(GenerateGreetingRequest request, ServerCallContext context)
        //{

        //    var result = new GeneratedGreeting { Greeting = $"hello {request.Name}, we hope you will enjoy our system" };

        //    return Task.FromResult<GeneratedGreeting>(result);
        //}

        //public override async Task<StatusMessage> AddGreetingToDb(AddGreetingRequest request, ServerCallContext context)
        //{
        //    var result = new StatusMessage();
        //    try
        //    {
        //        _readingRepository.AddEntity<Greeting>(new Greeting
        //        {
        //            Name = request.Name,
        //            GreetingContent = request.Greeting,
        //            CreatedAt = request.ReadingTime.ToDateTime()
        //        });

        //        if(await _readingRepository.SaveAllAsync())
        //        {
        //            result.Message = request.Greeting + " saved successfully";
        //            result.Saved = true;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        result.Message = ex.Message;
        //    }

        //    return result;
        //}


        public override async Task<Empty> SendDiagnostics(IAsyncStreamReader<ReadingMessage> requestStream, ServerCallContext context)
        {
            var task = Task.Run(async () => {
                await foreach (var readingMessage in requestStream.ReadAllAsync())
                {
                    _logger.LogInformation(readingMessage.ToString());
                }
            });
            await task;
            return new Empty();
        }

        public override async Task<StatusMessage> AddReading(Readingpacket request, ServerCallContext context)
        {
            var result = new StatusMessage
            {
                ReadingStatus = ReadingStatus.Failure
            };

            if (request.ReadingStatus == ReadingStatus.Success)
            {
                try
                {
                    foreach (var reading in request.Readings)
                    {
                        var meterReading = new MeterReading
                        {
                            CustomerId = reading.CustomerId,
                            ReadingDate = reading.ReadingTime.ToDateTime(),
                            Value = reading.ReadingValue
                        };
                        _readingRepository.AddEntity(meterReading);
                    }

                    if (await _readingRepository.SaveAllAsync())
                    {
                        result.ReadingStatus = ReadingStatus.Success;
                    }
                }
                catch (Exception ex)
                {
                    result.Message = "An error happened while importing readings";
                    _logger.LogError($"An error happened while importing readings: {ex}");
                }
            }

            return result;
        }

        [AllowAnonymous]
        public override async Task<TokenResponse> CreateToken(TokenRequest request, ServerCallContext context)
        {
            var response = await _jwtTokenValidationService.GenerateTokenModelAsync(new MeterReaderLib.Models.CredentialModel
            {
                UserName = request.Username,
                Passcode = request.Password
            });

            if (response.Success)
            {
                return new TokenResponse
                {
                    Token = response.Token,
                    Expiration = Timestamp.FromDateTime(response.Expiration),
                    Success = true
                };
            }
            else
            {
                return new TokenResponse
                {
                    Success = false
                };
            }
        }
    }
}
