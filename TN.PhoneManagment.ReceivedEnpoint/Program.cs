using MassTransit;
using Microsoft.EntityFrameworkCore;
using TN.PhoneManagment.Api;
using TN.PhoneManagment.Api.Models;
using TN.PhoneManagment.ReceivedEndpoint.StateMachine;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddSagaStateMachine<OrderStateMachine, Order>().EntityFrameworkRepository(r =>
    {
        r.ExistingDbContext<MyDbContext>();
    });

    var stateMachine = new OrderStateMachine();


    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.Host(new Uri("rabbitmq://beaver.rmq.cloudamqp.com/lnwyopqz"), h =>
        {
            h.Username("lnwyopqz");
            h.Password("9TPLIN5yoMRvgfbrwdnbVUGjyq5Ri05A");
        });

        cfg.ReceiveEndpoint("smartphone_endpoint", delegate (IRabbitMqReceiveEndpointConfigurator endpoint)
        {
            endpoint.UseMessageRetry(r => r.Interval(2, 100));
            endpoint.UseInMemoryOutbox();
            endpoint.UseRateLimit(1000, TimeSpan.FromSeconds(5.0));
        });
    }));
});

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
