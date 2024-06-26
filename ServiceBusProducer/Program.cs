using Microsoft.Azure.ServiceBus;
using ServiceBusProducer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITopicClient>( x => 
    new TopicClient(builder.Configuration.GetValue<string>("ServiceBus:ConnectionString")
                   ,builder.Configuration.GetValue<string>("ServiceBus:TopicName")));
builder.Services.AddSingleton<IMessagePublisher, MessagePublisher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
