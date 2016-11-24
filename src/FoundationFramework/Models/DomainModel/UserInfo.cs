

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FoundationFramework.Models.DomainModel
{
    public partial class UserInfo : BaseEntity
    {
        public int NavDeptId { get; set; }
        public Department NavDept { get; set; }

        public ICollection<Log> NavLog { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Please input Password")]
        public string Pwd { get; set; }

        [Required(ErrorMessage = "Please input JobNumber")]
        public string JobNumber { get; set; }


    }
}
