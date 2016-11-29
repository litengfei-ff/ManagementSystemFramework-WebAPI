
using LTF.Interfaces;
using LTF.Models;
using LTF.Models.DomainModel;

namespace LTF.Implements
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
 
	public partial class MenuGroupLogic : BaseLogic<MenuGroup>, IMenuGroupLogic
    {
        public MenuGroupLogic(ApplicationDbContext ctx) : base(ctx) { }
    }
 
	public partial class MenuItemLogic : BaseLogic<MenuItem>, IMenuItemLogic
    {
        public MenuItemLogic(ApplicationDbContext ctx) : base(ctx) { }
    }
 
	public partial class RoleLogic : BaseLogic<Role>, IRoleLogic
    {
        public RoleLogic(ApplicationDbContext ctx) : base(ctx) { }
    }
 
	public partial class RoleMenuMapLogic : BaseLogic<RoleMenuMap>, IRoleMenuMapLogic
    {
        public RoleMenuMapLogic(ApplicationDbContext ctx) : base(ctx) { }
    }
 
	public partial class UserLogic : BaseLogic<User>, IUserLogic
    {
        public UserLogic(ApplicationDbContext ctx) : base(ctx) { }
    }
 
	public partial class UserRoleMapLogic : BaseLogic<UserRoleMap>, IUserRoleMapLogic
    {
        public UserRoleMapLogic(ApplicationDbContext ctx) : base(ctx) { }
    }
}
