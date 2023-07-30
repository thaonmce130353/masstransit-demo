using TN.PhoneManagment.Contact.Enum;

namespace TN.PhoneManagment.Contact.Interfaces
{
    public interface ISubmitOrder
    {
        public Guid OrderId { get; set; }
        public Status Status{ get; set; }
        public double totalPrice { get; }
        public Guid SmartPhoneId { get; set; }
    }
}
