using Marten;
using Wolverine;
using Wolverine.Http;
using Wolverine.Marten;
using Wolverine.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWolverineHttp();

builder.Services.AddMarten(opts =>
{
    var connectionString = "Host=localhost;Database=wolverine_fanout;Username=postgres;Password=postgres";
    opts.Connection(connectionString);
    opts.DatabaseSchemaName = "wolverine_fanout";
})
.IntegrateWithWolverine();

builder.Host.UseWolverine(opts =>
{
    opts.UseRabbitMq("amqp://admin:admin123@localhost:5672/")
        .AutoProvision()
        .UseConventionalRouting();
    
    opts.MultipleHandlerBehavior = MultipleHandlerBehavior.Separated;
});

var app = builder.Build();

app.MapWolverineEndpoints();

app.Run();