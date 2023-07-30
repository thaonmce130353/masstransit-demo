using MassTransit;
using Microsoft.EntityFrameworkCore;
using TN.PhoneManagment.Api;
using TN.PhoneManagment.BackendReceivedEnpoint.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(Program).Assembly);
    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.Host(new Uri("rabbitmq://beaver.rmq.cloudamqp.com/lnwyopqz"), h =>
        {
            h.Username("lnwyopqz");
            h.Password("9TPLIN5yoMRvgfbrwdnbVUGjyq5Ri05A");
        });
        cfg.ReceiveEndpoint("smartphone_backend", ep =>
        {
            ep.PrefetchCount = 16;
            ep.UseMessageRetry(r => r.Interval(2, 100));
            ep.ConfigureConsumer<SubmitOrderConsumer>(provider);
            ep.ConfigureConsumer<UpdateStatusConsumer>(provider);
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
