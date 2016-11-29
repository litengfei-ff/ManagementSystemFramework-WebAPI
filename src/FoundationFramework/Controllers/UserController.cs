using LTF.Interfaces;
using LTF.Models.DomainModel;
using LTF.Models.Enums;
using LTF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LTF.Controllers
{
    [Route("api/[controller]")]
    public class UserController : MasterController
    {
        public UserController(ILogLogic iLogLogic, IUserLogic iuserLogic, IDepartmentLogic ideptLogic) : base(iLogLogic, iuserLogic, ideptLogic)
        {
        }

        [HttpGet("getDetail")]
        public Ret<UserDetailInfo> GetUserDetail()
        {
            return new Ret<UserDetailInfo>
            {
                ReCode = ReCodeEnum.Success,
                Data = userLogic.GetDetailInfo(userId)
            };
        }

        [HttpGet("{id}")]
        public Ret<User> Get(int id)
        {
            return new Ret<User>
            {
                ReCode = ReCodeEnum.Success,
                Data = userLogic[id],
            };
        }

        [HttpGet("page/{id}")]
        public Ret<PageData<User>> GetPage(int id = 1, int pageSize = 5)
        {
            int totalCount;
            var realData = userLogic.GetCurrentPage(pageSize, id, out totalCount, p => p.DelFlag == (int)DelFlagEnum.Normal, p => p.Id);
            var pager = new PagingInfo { CurrentPage = id, ItemsPerPage = pageSize, TotalItems = totalCount };
            return new Ret<PageData<User>>
            {
                ReCode = ReCodeEnum.Success,
                Data = new PageData<User>
                {
                    PagingData = realData,
                    PagingInfo = pager
                }
            };
        }

        [HttpPost]
        public Ret Post([FromBody]User u)
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
        public Ret Put([FromBody]User u)
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
