using MessagePublisher.Interface;
using MessagePublisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePublisher
{
    public class Play
    {
        private readonly IPublisher _entryService;
        public Play(IPublisher entryService)
        {
            _entryService = entryService;
        }

        public void Processor()
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("Please enter subject for message");
                    var subject = Console.ReadLine();

                    Console.WriteLine("Please enter the message to send");
                    var content = Console.ReadLine();

                    var Date = DateTime.Now.ToString();
                    if (!string.IsNullOrEmpty(content))
                    {
                        _entryService.SendMessage(new MessageEvent { message = content, subject = subject, date = Date });
                        Console.WriteLine("Message successfully sent...");
                    }

                    Console.WriteLine("---------------------------------------------------End of line--------------------------------------------------------");
                    Console.WriteLine(" Press [enter] to exit.");
                    Environment.Exit(0);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
