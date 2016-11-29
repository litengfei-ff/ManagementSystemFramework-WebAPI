using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTF.Models.ViewModel
{
    public class Dept
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public int Level { get; set; }

        public string DepartmentName { get; set; }

        public List<Dept> Child { get; set; }
    }
}
