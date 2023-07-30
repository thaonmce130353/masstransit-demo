namespace TN.PhoneManagment.Api.Models
{
    public class SmartPhone: Entity
    {
        public string Name { get; set; } = "";

        public double Price { get; set; }

        public string Description { get; set; } = "";
    }
}
