using TN.PhoneManagment.Contact.Enum;
using TN.PhoneManagment.Contact.Interfaces;

namespace TN.PhoneManagment.Contact.Events
{
    public class OrderDelivered : IOrderDelivered
    {
        public Guid OrderId { get; set; }
        public Status Status { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
