using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterReaderWeb.Data.Entities
{
    public class Greeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GreetingContent { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
