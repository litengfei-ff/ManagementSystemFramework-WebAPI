using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LTF.Models.DomainModel
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<UserRoleMap> NavUserRoleMapCollection { get; set; }

        [JsonIgnore]
        public ICollection<RoleMenuMap> NavRoleMenuMapCollection { get; set; }

    }


}
