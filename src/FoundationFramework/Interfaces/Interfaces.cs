
using LTF.Models.DomainModel;

namespace LTF.Interfaces
{
	/// <summary>
	/// 使用模板自动生成
    /// 所有实体 继承基类 定义CRUD接口  
    /// </summary>
 
 public partial interface IDepartmentLogic : IBaseLogic<Department> { }

 
 public partial interface ILogLogic : IBaseLogic<Log> { }

 
 public partial interface IMenuGroupLogic : IBaseLogic<MenuGroup> { }

 
 public partial interface IMenuItemLogic : IBaseLogic<MenuItem> { }

 
 public partial interface IRoleLogic : IBaseLogic<Role> { }

 
 public partial interface IRoleMenuMapLogic : IBaseLogic<RoleMenuMap> { }

 
 public partial interface IUserLogic : IBaseLogic<User> { }

 
 public partial interface IUserRoleMapLogic : IBaseLogic<UserRoleMap> { }

}
 
