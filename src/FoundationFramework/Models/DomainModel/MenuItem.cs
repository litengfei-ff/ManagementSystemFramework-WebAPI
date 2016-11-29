using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LTF.Models.DomainModel
{
    public class MenuItem : BaseEntity
    {

        public MenuGroup NavMenuGroup { get; set; }

        public ICollection<RoleMenuMap> NavRoleMenuMapCollection { get; set; }

        public int NavMenuGroupId { get; set; }

        public string Name { get; set; }

        public string ClientRouter { get; set; }

        public string ServerRouter { get; set; }

        public int Sort { get; set; }
    }

}
