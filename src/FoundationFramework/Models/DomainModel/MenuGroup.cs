using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTF.Models.DomainModel
{

    public class MenuGroup : BaseEntity
    {
        public ICollection<MenuItem> NavMenuItemCollection { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int Sort { get; set; }


    }
}
