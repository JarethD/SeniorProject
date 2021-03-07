using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using RabbitMQ;
using RabbitMQ.Client;

namespace Messagin
{
    public class Send
    {
        void SendMessage(string newmessage)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                string message = newmessage; // Console.ReadLine();

                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
                while (message != "exit")
                {
                    //string message = "This is a test";
                    //string message = Console.ReadLine();
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                    //Console.WriteLine(" [x] Sent {0}", message);
                    message = Console.ReadLine();
                }
            }
            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();
        }
    }
}
