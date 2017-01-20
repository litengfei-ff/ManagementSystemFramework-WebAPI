using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace LTF.Models.DomainModel
{
    public partial class Department : BaseEntity
    {
         
        public ICollection<User> NavUserCollection { get; set; }

        public int ParentId { get; set; }

        public string DepartmentName { get; set; }

        public int Level { get; set; }

    }
}
