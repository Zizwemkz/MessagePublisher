using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher.Models
{
    public class MessageEvent
    {
        public string message { get; set; }
        public string subject { get; set; }
        public string date { get; set; }
    }
}
