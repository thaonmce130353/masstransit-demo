using TN.PhoneManagment.Contact.Enum;

namespace TN.PhoneManagment.Contact.DTOs
{
    public class OrderDTO
    {
        public Status Status { get; set; }
        public double totalPrice { get; set; }
        public Guid SmartPhoneId { get; set; }
        public Guid Id { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
