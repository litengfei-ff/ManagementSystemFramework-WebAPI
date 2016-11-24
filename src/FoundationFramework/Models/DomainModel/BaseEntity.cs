
using System.ComponentModel.DataAnnotations;

namespace FoundationFramework.Models.DomainModel
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int DelFlag { get; set; }
    }

}



