using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoundationFramework.Interfaces;
using FoundationFramework.Models.DomainModel;
using FoundationFramework.Models.Enums;
using FoundationFramework.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FoundationFramework.Controllers
{
    [Route("api/[controller]")]
    public class DeptController : FFController
    {

        public DeptController(ILogLogic iLogLogic, IUserInfoLogic iuserLogic, IDepartmentLogic ideptLogic) : base(iLogLogic, iuserLogic, ideptLogic)
        {
        }

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public Ret<string> Get()
        {
            return new Ret<string>
            {
                ReCode = Models.Enums.ReCodeEnum.Success,
                Msg = "成功获取部门列表",
                Data = deptLogic.GetDeptJson()
            };
        }


        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        public Ret Add(int deptId, string deptName)
        {
            // 验证部门名是否存在
            if (deptLogic.GetFirst(p => p.DepartmentName == deptName && p.DelFlag == (int)DelFlagEnum.Normal, p => p.Id) != null)
            {
                return new Ret() { ReCode = ReCodeEnum.Fail, Msg = "添加失败，部门名称已存在" };
            }

            // 获取上级部门信息
            var partentDept = deptLogic.GetFirst(p => p.Id == deptId, p => p.Id);
            if (partentDept == null)
            {
                return new Ret() { ReCode = ReCodeEnum.Fail, Msg = "添加失败，父级部门不存在" };
            }
            // 添加部门
            var dept = deptLogic.Add(new Department
            {
                DepartmentName = deptName,
                Level = partentDept.Level + 1,
                ParentId = deptId
            });
            deptLogic.SaveChanges();

            return new Ret() { ReCode = ReCodeEnum.Fail, Msg = "添加成功" };
        }


        /// <summary>
        /// 重命名
        /// </summary>
        [HttpPost]
        public Ret Edit(int deptId, string deptName)
        {
            // 验证部门名是否存在
            if (deptLogic.GetFirst(p => p.DepartmentName == deptName && p.DelFlag == (int)DelFlagEnum.Normal, p => p.Id) != null)
            {
                return new Ret() { ReCode = ReCodeEnum.Fail, Msg = "重命名失败，部门名称已存在" };
            }

            // 获取对应的部门
            var deptInfo = deptLogic.GetFirst(p => p.Id == deptId, p => p.Id);
            if (deptInfo == null)
            {
                return new Ret() { ReCode = ReCodeEnum.Fail, Msg = "重命名失败，部门不存在" };
            }
            deptInfo.DepartmentName = deptName;
            deptLogic.SaveChanges();

            return new Ret() { ReCode = ReCodeEnum.Success, Msg = "重命名成功" };
        }

        /// <summary>
        /// 删除 
        /// </summary>
        [HttpPost]
        public Ret Delete(int deptId)
        {
            var deptInfo = deptLogic.GetFirst(p => p.Id == deptId, p => p.Id);
            if (deptInfo == null)
            {
                return new Ret() { ReCode = ReCodeEnum.Fail, Msg = "删除失败，部门不存在" };
            }

            // 是否有子部门
            if (deptLogic.GetFirst(p => p.ParentId == deptId, p => p.Id) != null)
            {
                return new Ret() { ReCode = ReCodeEnum.Fail, Msg = "删除失败，该部门拥有子部门" };
            }

            deptLogic.DeleteByLogic(deptId);
            deptLogic.SaveChanges();

            return new Ret() { ReCode = ReCodeEnum.Success, Msg = "删除成功" };
        }

    }
}
