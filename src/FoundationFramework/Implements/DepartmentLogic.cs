using System.Collections.Generic;
using System.Linq;
using LTF.Models.Enums;
using LTF.Models.ViewModel;
using Newtonsoft.Json;

namespace LTF.Implements
{
    public partial class DepartmentLogic
    {
        /// <summary>
        /// 获取部门列表的JSON数据
        /// </summary>
        /// <returns></returns>
        public string GetDeptJson()
        {
            var deptList = this.GetAll(p => p.DelFlag == (int)DelFlagEnum.Normal, p => p.Level, false)
                .Select(p => new Dept
                {
                    Id = p.Id,
                    ParentId = p.ParentId,
                    DepartmentName = p.DepartmentName,
                    Level = p.Level,
                    Child = null
                }).ToList();

            var newDeptList = new List<Dept>();
            foreach (var dept in deptList)
            {
                if (dept.Id == 1)
                {
                    newDeptList.Add(dept);
                    continue;
                }
                // 找到父节点
                var pNode = deptList.FirstOrDefault(p => p.Id == dept.ParentId);
                // 放到父节点上
                if (pNode.Child == null)
                {
                    pNode.Child = new List<Dept>();
                }
                pNode.Child.Add(dept);
            }

            return JsonConvert.SerializeObject(newDeptList);
        }
    }

   
}
