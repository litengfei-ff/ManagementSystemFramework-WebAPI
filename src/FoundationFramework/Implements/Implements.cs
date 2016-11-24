
using FoundationFramework.Interfaces;
using FoundationFramework.Models;
using FoundationFramework.Models.DomainModel;

namespace FoundationFramework.Implements
{
	/// <summary>
	/// 使用模板自动生成
    /// 所有实体 继承基类 实现CRUD接口  
    /// </summary>
 
	public partial class DepartmentLogic : BaseLogic<Department>, IDepartmentLogic
    {
        public DepartmentLogic(ApplicationDbContext ctx) : base(ctx) { }
    }
 
	public partial class LogLogic : BaseLogic<Log>, ILogLogic
    {
        public LogLogic(ApplicationDbContext ctx) : base(ctx) { }
    }
 
	public partial class UserInfoLogic : BaseLogic<UserInfo>, IUserInfoLogic
    {
        public UserInfoLogic(ApplicationDbContext ctx) : base(ctx) { }
    }
}
