using System;
using FoundationFramework.Interfaces;
using FoundationFramework.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FoundationFramework.Models.DomainModel;
using FoundationFramework.Models.Enums;

namespace FoundationFramework.Implements
{
    public partial class UserInfoLogic
    {
        /// <summary>
        /// 获取详细信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserDetailInfo GetDetailInfo(int userId)
        {
            var detailData = from a in GetAll(p => p.Id == userId, p => p.Id)
                             select new UserDetailInfo
                             {
                                 Id = a.Id,
                                 Name = a.Name,
                                 JobNumber = a.JobNumber,
                                 DeptName = a.NavDept.DepartmentName,
                             };
            return detailData.FirstOrDefault();
        }

        /// <summary>
        /// 验证用户是否存在  
        /// </summary>
        /// <param name="jobNumber"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool IsExists(string jobNumber, string pwd)
        {
            return GetFirst(p => p.DelFlag == (int)DelFlagEnum.Normal && p.JobNumber == jobNumber && p.Pwd == pwd, p => p.Id) != null;
        }

        public int? GetUserIdByJobNumber(string jobNumber)
        {
            return GetFirst(
                p => p.DelFlag == (int)DelFlagEnum.Normal && p.JobNumber == jobNumber,
                p => p.Id)?.Id;
        }
    }
}
