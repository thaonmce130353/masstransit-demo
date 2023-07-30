using TN.PhoneManagment.Contact.Enum;

namespace TN.PhoneManagment.Contact.Interfaces
{
    public interface IOrderDelivered
    {
        public Guid OrderId { get; set; }
        public Status Status { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
