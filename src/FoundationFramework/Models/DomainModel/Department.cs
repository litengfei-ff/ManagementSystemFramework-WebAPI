
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoundationFramework.Models.DomainModel
{
    public partial class Department : BaseEntity
    {
        public ICollection<UserInfo> NavUser { get; set; }

        public int ParentId { get; set; }

        public string DepartmentName { get; set; }

        public int Level { get; set; }

    }
}
