using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;

namespace Messaging
{
    public class Receive
    {
        static public void ReceiveMessage(string newmessage)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                String message = "\0";

                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
                //while (message != "exit")
                {
                    //Console.WriteLine(" [*] Waiting for messages.");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };
                    newmessage = message;
                    if (message != "exit")
                    {
                        channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);
                    }
                }
                //Console.WriteLine(" Press [enter] to exit.");
                //Console.ReadLine();
            }
        }
    }
}
