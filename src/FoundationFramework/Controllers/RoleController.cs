using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTF.Interfaces;
using LTF.Models.DomainModel;
using LTF.Models.Enums;
using LTF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LTF.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : MasterController
    {
        public IRoleLogic roleLogic { get; set; }
        public RoleController(IRoleLogic roleLogic, IUserLogic iuserLogic, ILogLogic logLogic) : base(iuserLogic, logLogic)
        {
            this.roleLogic = roleLogic;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public Ret<List<Role>> Get()
        {
            return new Ret<List<Role>>
            {
                ReCode = Models.Enums.ReCodeEnum.Success,
                Msg = "成功获取角色列表",
                Data = roleLogic.GetAll(p => p.DelFlag == (int)DelFlagEnum.Normal).ToList()
            };
        }

        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost("add")]
        public Ret Add([FromBody]Role role)
        {
            var name = role.Name;
            // 验证名称是否存在
            if (roleLogic.GetFirst(p => p.Name == name && p.DelFlag == (int)DelFlagEnum.Normal) != null)
            {
                return new Ret() { ReCode = ReCodeEnum.Fail, Msg = "添加失败，名称已存在" };
            }

            // 添加部门
            var roleInfo = roleLogic.Add(new Role
            {
                Name = name
            });
            roleLogic.SaveChanges();

            logLogic.Info($"添加角色 id:[{roleInfo.Id}],name:[{roleInfo.Name}]", userInfo.Id, HttpContext.Request.Path);
            return new Ret() { ReCode = ReCodeEnum.Success, Msg = "添加成功" };
        }


        /// <summary>
        /// 重命名
        /// </summary>
        [HttpPut("edit")]
        public Ret Edit([FromBody]Role role)
        {
            var name = role.Name;
            var id = role.Id;

            // 验证是否存在
            if (roleLogic.GetFirst(p => p.Name == name && p.DelFlag == (int)DelFlagEnum.Normal) != null)
            {
                return new Ret() { ReCode = ReCodeEnum.Fail, Msg = "重命名失败，名称已存在" };
            }

            // 获取对应的角色
            var roleInfo = roleLogic.GetFirst(p => p.Id == id && p.DelFlag == (int)DelFlagEnum.Normal);
            if (roleInfo == null)
            {
                return new Ret() { ReCode = ReCodeEnum.Fail, Msg = "重命名失败，角色不存在" };
            }
            roleInfo.Name = name;
            roleLogic.SaveChanges();

            logLogic.Info($"重命名角色 id:[{roleInfo.Id}],name:[{roleInfo.Name}]", userInfo.Id, HttpContext.Request.Path);

            return new Ret() { ReCode = ReCodeEnum.Success, Msg = "重命名成功" };
        }

        /// <summary>
        /// 删除，删除多项时以逗号分隔
        /// </summary>
        [HttpDelete("del/{roleIdStr}")]
        public Ret Delete(string roleIdStr)
        {
            var idArr = roleIdStr.Split(',');
            foreach (var id in idArr)
            {
                var roleId = Convert.ToInt32(id);
                var roleInfo = roleLogic.GetFirst(p => p.Id == roleId && p.DelFlag == (int)DelFlagEnum.Normal);
                if (roleInfo == null)
                {
                    return new Ret() { ReCode = ReCodeEnum.Fail, Msg = "删除失败，角色不存在" };
                }
                roleLogic.DeleteByLogic(roleId);
            }

            roleLogic.SaveChanges();

            logLogic.Info($"删除角色 id:[{roleIdStr}]", userInfo.Id, HttpContext.Request.Path);

            return new Ret() { ReCode = ReCodeEnum.Success, Msg = "删除成功" };
        }


    }
}

