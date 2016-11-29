using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTF.Models.DomainModel
{
    public class UserRoleMap : BaseEntity
    {
        public User NavUser { get; set; }
        public int NavUserId { get; set; }

        public Role NavRole { get; set; }
        public int NavRoleId { get; set; }

    }
}
