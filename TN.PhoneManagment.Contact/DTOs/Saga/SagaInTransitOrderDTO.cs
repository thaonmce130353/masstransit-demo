using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.PhoneManagment.Contact.Enum;
using TN.PhoneManagment.Contact.Interfaces.Saga;

namespace TN.PhoneManagment.Contact.DTOs.Saga
{
    public class SagaInTransitOrderDTO : ISagaInTransitOrder
    {
        public Guid OrderId { get; set; }
        public Status Status { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
