using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LTF.Models.DomainModel
{
    public partial class User : BaseEntity
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input Password")]
        public string Pwd { get; set; }

        [Required(ErrorMessage = "Please input JobNumber")]
        public string JobNumber { get; set; }

        public int NavDeptId { get; set; }

        public Department NavDept { get; set; }

        public ICollection<Log> NavLogCollection { get; set; }

        public ICollection<UserRoleMap> NavUserRoleMapCollection { get; set; }

    }
}
