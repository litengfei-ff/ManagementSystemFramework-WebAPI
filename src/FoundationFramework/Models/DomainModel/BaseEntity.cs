using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LTF.Models.DomainModel
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public int DelFlag { get; set; }
    }

}



