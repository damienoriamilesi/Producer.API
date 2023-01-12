using MassTransit;
using Newtonsoft.Json;
using Shared.Messages;
using Shared.Messages.v1;

namespace ConsumerApi; 

public class OrderCreatedConsumer : IConsumer<IOrderCreated>
{
    public async Task Consume(ConsumeContext<IOrderCreated> context)
    {
        await Task.Run(() =>
        {
            var jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"OrderCreated message: {jsonMessage}");
        });
    }
}