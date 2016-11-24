
using FoundationFramework.Models.DomainModel;

namespace FoundationFramework.Interfaces
{
	/// <summary>
	/// 使用模板自动生成
    /// 所有实体 继承基类 定义CRUD接口  
    /// </summary>
 
 public partial interface IDepartmentLogic : IBaseLogic<Department> { }

 
 public partial interface ILogLogic : IBaseLogic<Log> { }

 
 public partial interface IUserInfoLogic : IBaseLogic<UserInfo> { }

}
 
