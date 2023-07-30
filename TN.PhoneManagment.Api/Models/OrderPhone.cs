namespace TN.PhoneManagment.Api.Models
{
    public class OrderPhone: Entity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid SmartPhoneId { get; set; }
        public SmartPhone SmartPhone { get; set; }
    }
}
