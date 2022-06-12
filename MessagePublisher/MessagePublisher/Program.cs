using System;
using System.Text;
using RabbitMQ.Client;
using MessagePublisher.Models;
using MessagePublisher.PublishEventService;


    var publisher = new Publisher();

    while (true)
    {
        try {

            Console.WriteLine("Please enter subject for message");
            var subject = Console.ReadLine();

            Console.WriteLine("Please enter the message to send");
            var content = Console.ReadLine();

            var Date = DateTime.Now.ToString();
            if (!string.IsNullOrEmpty(content))
            {
                 publisher.SendMessage(new MessageEvent { message = content, subject = subject, date = Date});
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
   

