using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.PhoneManagment.Contact.Enum;
using TN.PhoneManagment.Contact.Interfaces;

namespace TN.PhoneManagment.Contact.Events
{
    public class InTransitOrder : IInTransitOrder
    {
        public Guid OrderId { get ; set ; }
        public Status Status { get; set ; }
        public DateTime UpdatedDate { get; set; }
    }
}
