
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoundationFramework.Models.DomainModel
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int DelFlag { get; set; }
    }

}



