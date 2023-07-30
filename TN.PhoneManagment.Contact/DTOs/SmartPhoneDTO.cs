namespace TN.PhoneManagment.Contact.DTOs
{
    public class SmartPhoneDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public double Price { get; set; }

        public string Description { get; set; } = "";
    }
}