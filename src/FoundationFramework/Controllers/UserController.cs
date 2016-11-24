using FoundationFramework.Interfaces;
using FoundationFramework.Models.DomainModel;
using FoundationFramework.Models.Enums;
using FoundationFramework.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
 

namespace FoundationFramework.Controllers
{
	[Route("api/[controller]")]
    public class UserController : FFController
    {
        public UserController(ILogLogic iLogLogic, IUserInfoLogic iuserLogic, IDepartmentLogic ideptLogic) : base(iLogLogic, iuserLogic, ideptLogic)
        {
        }

        [HttpGet("{id}")]
        public Ret<UserInfo> Get(int id)
        {
            return new Ret<UserInfo>
            {
                ReCode = ReCodeEnum.Success,
                Data = userLogic[id],
            };
        }

        [HttpGet("page/{id}")]
        public Ret<PageData<UserInfo>> GetPage(int id = 1, int pageSize = 5)
        {
            int totalCount;
            var realData = userLogic.GetCurrentPage(pageSize, id, out totalCount, p => p.DelFlag == (int)DelFlagEnum.Normal, p => p.Id);
            var pager = new PagingInfo { CurrentPage = id, ItemsPerPage = pageSize, TotalItems = totalCount };
            return new Ret<PageData<UserInfo>>
            {
                ReCode = ReCodeEnum.Success,
                Data = new PageData<UserInfo>
                {
                    PagingData = realData,
                    PagingInfo = pager
                }
            };
        }

        [HttpPost]
        public Ret Post([FromBody]UserInfo u)
        {
            if (ModelState.IsValid)
            {
                userLogic.Add(u);
                userLogic.SaveChanges();
                return new Ret { ReCode = ReCodeEnum.Success };
            }
            return new Ret { ReCode = ReCodeEnum.Fail, Msg = "数据不合法" };
        }

        [HttpPut]
        public Ret Put([FromBody]UserInfo u)
        {
            if (ModelState.IsValid)
            {
                userLogic.Update(u);
                userLogic.SaveChanges();
                return new Ret { ReCode = ReCodeEnum.Success };
            }
            return new Ret { ReCode = ReCodeEnum.Fail, Msg = "数据不合法" };
        }

        [HttpDelete("del/{id}")]
        public Ret DeleteByLogic(int id)
        {
            var u = userLogic.DeleteByLogic(id);
            userLogic.SaveChanges();
            return new Ret { ReCode = ReCodeEnum.Success };

        }

        [HttpDelete("delete/{id}")]
        public Ret Delete(int id)
        {
            var u = userLogic.Delete(id);
            userLogic.SaveChanges();
            return new Ret { ReCode = ReCodeEnum.Success };
        }
    }
}
