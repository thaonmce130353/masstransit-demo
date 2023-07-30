using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.PhoneManagment.Contact.Enum;

namespace TN.PhoneManagment.Contact.DTOs
{
    public class UpdateStatusDTO
    {
        public Guid OrderId { get; set; }
        public Status Status { get; set; }
    }
}
