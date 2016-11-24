

using FoundationFramework.Models.DomainModel;
using FoundationFramework.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FoundationFramework.Interfaces
{
    public partial interface IUserInfoLogic
    {
        UserDetailInfo GetDetailInfo(int userId);
        bool IsExists(string jobNumber, string pwd);

        int? GetUserIdByJobNumber(string jobNumber);

    }
}
