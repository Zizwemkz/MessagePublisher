using System;
using System.Text;
using RabbitMQ.Client;
using MessagePublisher.Models;
using MessagePublisher.Service;
using MessagePublisher.Interface;
using MessagePublisher.Configure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

class Program 
{
    public static void Main(string[] args)
    {
        var container = Startup.ConfigureSerivce();
        var _publisherService = container.GetService<IPublisher>();


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
                    Program obj = new Program();
                    _publisherService.SendMessage(new MessageEvent { message = content, subject = subject, date = Date });
                    Console.WriteLine("================================================= Message successfully sent ========================================");
                }

                Console.WriteLine("----------------------------------------------------- End of line --------------------------------------------------------");
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







