using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace ServiceBusSender
{
    class Program
    {

        static string connectionString = "Endpoint=sb://<>.servicebus.windows.net/;SharedAccessKeyName=<>;SharedAccessKey=<>;";
        static string queueName = "<>";

        static async Task Main(string[] args)
        {
            while (true)
            {
                ServiceBusClient client = new ServiceBusClient(connectionString);

                // create a sender for the queue 
                Azure.Messaging.ServiceBus.ServiceBusSender sender = client.CreateSender(queueName);


                Console.WriteLine("Please enter the message to send");

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(Console.ReadLine());

                // send the message
                await sender.SendMessageAsync(message);

                await client.DisposeAsync();
            }
        }
    }
}
