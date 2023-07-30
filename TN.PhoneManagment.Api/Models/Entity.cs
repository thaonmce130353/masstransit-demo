using System.ComponentModel.DataAnnotations;

namespace TN.PhoneManagment.Api.Models
{
    public class Entity
    {
        [Key]
        public Guid CorrelationId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
