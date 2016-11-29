using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTF.Models.DomainModel
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<UserRoleMap> NavUserRoleMapCollection { get; set; }
        public ICollection<RoleMenuMap> NavRoleMenuMapCollection { get; set; }

    }


}
