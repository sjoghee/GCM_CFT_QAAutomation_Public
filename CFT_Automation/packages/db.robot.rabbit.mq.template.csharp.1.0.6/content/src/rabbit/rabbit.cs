using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace rabbit
{
    class Consumer
    {
        ConnectionFactory factory;
        IConnection connection;

        public Consumer(string HostName, string UserName, string Password)
        {
            factory = new ConnectionFactory() { HostName = HostName, UserName = UserName, Password = Password};
            connection = factory.CreateConnection();
        }


        public void RetrieveMessages(string queue, string exchange){
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer =  new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };

            channel.BasicConsume(queue: queue,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}