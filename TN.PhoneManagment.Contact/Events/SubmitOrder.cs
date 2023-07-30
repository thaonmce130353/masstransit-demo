using TN.PhoneManagment.Contact.DTOs;
using TN.PhoneManagment.Contact.Enum;
using TN.PhoneManagment.Contact.Interfaces;

namespace TN.PhoneManagment.Contact.Events
{
    public class SubmitOrder : ISubmitOrder
    {
        public Guid OrderId { get; set; }
        public Status Status { get; set; }
        public double totalPrice { get; set; }
        public List<Guid> SmartPhoneIds { get; set; }
    }
}
