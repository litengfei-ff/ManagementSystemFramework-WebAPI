using System.ComponentModel.DataAnnotations;

namespace LTF.Models.DomainModel
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int DelFlag { get; set; }
    }

}



