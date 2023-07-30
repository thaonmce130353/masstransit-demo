using MassTransit;
using TN.PhoneManagment.Contact.Enum;

namespace TN.PhoneManagment.Api.Models
{
    public class Order: Entity, SagaStateMachineInstance
    {
        public int Status { get; set; }
        public double totalPrice { get; set; }
        public Guid SmartPhoneId { get; set; }
    }
}
