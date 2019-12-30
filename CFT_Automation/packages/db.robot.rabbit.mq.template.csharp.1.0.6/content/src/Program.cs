using System;
using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;

namespace robot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Robot starting");

            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            // to access env vars use following construct
            // configuration.GetSection("environment_variable_name").Value
        }
    }
}
