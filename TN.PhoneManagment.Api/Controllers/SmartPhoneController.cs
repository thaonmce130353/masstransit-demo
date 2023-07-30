using MassTransit;
using Microsoft.AspNetCore.Mvc;
using TN.PhoneManagment.Api.Models;
using TN.PhoneManagment.Contact.DTOs;
using TN.PhoneManagment.Contact.Events;
using TN.PhoneManagment.Contact.Interfaces;

namespace TN.PhoneManagment.Api.Controllers
{
    [Route("api/SmartPhone")]
    public class SmartPhoneController: Controller
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly MyDbContext _context;

        public SmartPhoneController(IPublishEndpoint publishEndpoint, MyDbContext context)
        {
            _publishEndpoint = publishEndpoint;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SmartPhoneDTO IPhone)
        {
            var iphoneMapped = new SmartPhone
            {
                Name = IPhone.Name,
                Description = IPhone.Description,
                LastModifiedDate = DateTime.Now,
                Price = IPhone.Price
            };
            await _context.phones.AddAsync(iphoneMapped);
            await _context.SaveChangesAsync();

            return Ok(iphoneMapped.CorrelationId);
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var smartPhone =  _context.phones.FirstOrDefault(ip => ip.CorrelationId.Equals(id));

            if (smartPhone == null)
            {
                return Ok(null);
            }

            var result = new SmartPhoneDTO
            {
                Id = smartPhone.CorrelationId,
                Name = smartPhone.Name,
                Description = smartPhone.Description,
                Price = smartPhone.Price,
            };

            return Ok(result);
        }

        [HttpPost]
        [Route(nameof(SubmitOrder))]
        public async Task<IActionResult> SubmitOrder([FromBody] OrderDTO orderDTO)
        {
            var message = new SubmitOrder
            {
                OrderId = Guid.NewGuid(),
                Status = orderDTO.Status,
                totalPrice = orderDTO.totalPrice,
                SmartPhoneIds = orderDTO.SmartPhoneIds
            };
            await _publishEndpoint.Publish<ISubmitOrder>(message);

            return Ok(true);
        }

        [HttpPost]
        [Route(nameof(UpdateStatus))]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatusDTO request)
        {
            var message = new UpdateStatus
            {
                LastUpdatedDate = DateTime.UtcNow,
                OrderId = request.OrderId,
                Status = request.Status,
            };
            await _publishEndpoint.Publish<IUpdateStatus>(message);

            return Ok(true);
        }
    }
}
