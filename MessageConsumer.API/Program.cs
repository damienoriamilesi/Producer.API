using ConsumerApi;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("order-created-event", e =>
    {
        e.Consumer<OrderCreatedConsumer>();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    
await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Press enter to exit");
    
    await Task.Run(Console.ReadLine);
}
finally
{
    await busControl.StopAsync();
}

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
