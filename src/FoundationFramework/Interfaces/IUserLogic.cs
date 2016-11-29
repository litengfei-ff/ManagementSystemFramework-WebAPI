using LTF.Models.ViewModel;

namespace LTF.Interfaces
{
    public partial interface IUserLogic
    {
        UserDetailInfo GetDetailInfo(int userId);

        bool IsExists(string jobNumber, string pwd);

        int? GetUserIdByJobNumber(string jobNumber);

    }
}
