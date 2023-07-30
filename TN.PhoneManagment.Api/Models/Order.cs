using MassTransit;
using TN.PhoneManagment.Api.Helpers;
using TN.PhoneManagment.Contact.Enum;

namespace TN.PhoneManagment.Api.Models
{
    public class Order: Entity
    {
        public int Status { get; set; }
        public string? StatusName { get; set; }
        public double totalPrice { get; set; }

        public List<OrderPhone> OrderPhones { get; set; }

        public void setStatus(Status status)
        {
            this.Status = (int)status;
            this.StatusName = Helper._statusNameDictionary[status];
        }
    }
}
