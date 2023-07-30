using MassTransit;
using Microsoft.EntityFrameworkCore;
using TN.PhoneManagment.Api;
using TN.PhoneManagment.Contact.Interfaces;

namespace TN.PhoneManagment.BackendReceivedEnpoint.Consumers
{
    public class UpdateStatusConsumer : IConsumer<IUpdateStatus>
    {
        private readonly ILogger<SubmitOrderConsumer> _logger;
        private readonly MyDbContext _context;

        public UpdateStatusConsumer(ILogger<SubmitOrderConsumer> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Consume(ConsumeContext<IUpdateStatus> context)
        {
            if (context.Message is null)
            {
                _logger.LogInformation("There no data received: {@MSG}", context.Message);
                return;
            }

            _logger.LogInformation("Received Messages: {@MSG}", context.Message);

            var order = _context.orders.FirstOrDefault(o => o.CorrelationId.Equals(context.Message.OrderId));

            if (order == null)
            {
                _logger.LogInformation("The order is not found: {@ID}", context.Message.OrderId);
                return;
            }

            order.LastModifiedDate = context.Message.UpdatedDate;
            order.setStatus(context.Message.Status);

            await _context.SaveChangesAsync();

            _logger.LogInformation("The order status changed - Status: {Status}", order.StatusName);
        }
    }
}
