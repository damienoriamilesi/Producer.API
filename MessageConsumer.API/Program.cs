using ConsumerApi;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
//{
//    cfg.Host("trabbitmq", 5672, "/",
//        h =>
//        {
//            h.Username("devl");
//            h.Password("devldevl");
//        }
//    );
    
//    //cfg.ReceiveEndpoint("order-created-event", e =>
//    cfg.ReceiveEndpoint("order-created-event", e =>
//    {
//        e.Consumer<OrderCreatedConsumer>();
//    });
//});


builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        //cfg.Host(new Uri("rabbitmq://trabbitmq.cdm.smis.ch:5672", UriKind.Absolute), h => {
        //    h.Username("rabbitmana");
        //    h.Password("rmqaa@CDM");

        //    h.UseSsl(s =>
        //    {
        //        s.Protocol = SslProtocols.Tls12;
        //    });
        //});

        cfg.Host("trabbitmq", 5672, "/",
            h =>
            {
                h.Username("devl");
                h.Password("devldevl");
            }
        );
        cfg.ReceiveEndpoint("consumer-receiver", e =>
        {
            e.Consumer<OrderCreatedConsumer>();
        });
    });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    
//await busControl.StartAsync();

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
