using TN.PhoneManagment.Contact.Enum;

namespace TN.PhoneManagment.Contact.Interfaces.Saga
{
    public interface ISagaInTransitOrder
    {
        public Guid OrderId { get; set; }
        public Status Status { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
