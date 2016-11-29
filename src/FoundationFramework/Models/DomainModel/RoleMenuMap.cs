using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTF.Models.DomainModel
{
    public class RoleMenuMap : BaseEntity
    {
        public MenuItem NavMenuItem { get; set; }
        public int NavMenuItemId { get; set; }

        public Role NavRole { get; set; }
        public int NavRoleId { get; set; }
    }
}
