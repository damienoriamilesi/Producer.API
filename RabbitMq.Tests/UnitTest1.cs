using RabbitMQ.Client;

namespace RabbitMq.Tests
{
    public class RabbitMqConnectionTest
    {
        [Fact]
        public void Test1()
        {
            var factory = new ConnectionFactory
            {
                HostName = "trabbitmq",
                UserName = "devl",
                Password = "devldevl"
            };
            var connection = factory.CreateConnection();

        }
    }
}