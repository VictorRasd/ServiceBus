using Microsoft.Azure.ServiceBus;
using ServiceBusConsumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHostedService<CustomerConsumerService>();
builder.Services.AddSingleton<ISubscriptionClient>(x =>
    new SubscriptionClient(builder.Configuration.GetValue<string>("ServiceBus:ConnectionString")
                          , builder.Configuration.GetValue<string>("ServiceBus:TopicName")
                          , builder.Configuration.GetValue<string>("ServiceBus:SubscriptionName")));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
