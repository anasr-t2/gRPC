using MeterReaderWeb.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeterReaderClient
{
    public class ReadingFactory
    {
        public Task<ReadingMessage> Generate(int customerId)
        {
            var reading = new ReadingMessage
            {
                CustomerId = customerId,
                ReadingValue = new Random().Next(1000),
                ReadingTime = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow)
            };

            return Task.FromResult(reading);
        }
    }
}
