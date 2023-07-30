using MassTransit;
using Newtonsoft.Json;
using TN.PhoneManagment.Api;
using TN.PhoneManagment.Api.Models;
using TN.PhoneManagment.Contact.Enum;
using TN.PhoneManagment.Contact.Events;
using TN.PhoneManagment.Contact.Interfaces;

namespace TN.PhoneManagment.BackendReceivedEnpoint.Consumers
{
    public class SubmitOrderConsumer : IConsumer<ISubmitOrder>
    {
        private readonly ILogger<SubmitOrderConsumer> _logger;
        private readonly MyDbContext _context;

        public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Consume(ConsumeContext<ISubmitOrder> context)
        {
            if (context.Message is null)
            {
                _logger.LogInformation("There no data received: {@MSG}", context.Message);
                return;
            }

            _logger.LogInformation("Received Messages: {@MSG}", context.Message);

            var order = new Order
            {
                totalPrice = context.Message.totalPrice,
                LastModifiedDate = DateTime.Now
            };

            order.setStatus(context.Message.Status);

            await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync();

            var orderPhones = new List<OrderPhone>();
            context.Message.SmartPhoneIds.ForEach(phoneId =>
            {
                orderPhones.Add(new OrderPhone()
                {
                    OrderId = order.CorrelationId,
                    SmartPhoneId = phoneId,
                    CorrelationId = Guid.NewGuid(),
                    LastModifiedDate = DateTime.Now
                });
            });

            _context.orderPhones.AddRange(orderPhones);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Submit Order successful. orderId: @{ID}", order.CorrelationId);

        }
    }
}
