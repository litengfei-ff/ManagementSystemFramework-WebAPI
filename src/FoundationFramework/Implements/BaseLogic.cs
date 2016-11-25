using System;
using System.Linq;
using System.Linq.Expressions;
using FoundationFramework.Models;
using FoundationFramework.Models.DomainModel;
using FoundationFramework.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FoundationFramework.Implements
{
    public class BaseLogic<T> where T : BaseEntity
    {
        // 注入EF上下文
        protected ApplicationDbContext context;
        public BaseLogic(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        // 保存更改
        public int SaveChanges()
        {
            return context.SaveChanges();
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="u">实体</param>
        /// <returns></returns>
        public T Add(T u)
        {
            //int newId = context.Set<T>().Max(p => p.Id) + 1;
            //u.Id = newId;
            context.Add<T>(u);
            return u;
        }

        public T Update(T u)
        {
            context.Entry(u).State = EntityState.Modified;
            return u;
        }

        public T Delete(int id)
        {
            T delObj = this[id];
            context.Remove<T>(delObj);
            return delObj;
        }

        public T DeleteByLogic(int id)
        {
            T delObj = this[id];
            delObj.DelFlag = (int)DelFlagEnum.Deleted;
            context.Entry<T>(delObj).State = EntityState.Modified;
            return delObj;
        }

        public T this[int id] => context.Find<T>(id);

        public T GetFirst<S>(Expression<Func<T, bool>> wherelambda, Expression<Func<T, S>> orderlambda, bool ascOrder = true)
        {
            return GetAll<S>(wherelambda, orderlambda, ascOrder).FirstOrDefault();
        }

        public T GetFirst(Expression<Func<T, bool>> wherelambda)
        {
            return GetAll(wherelambda).FirstOrDefault();
        }

        public IQueryable<T> GetAll<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda, bool ascOrder = true)
        {
            if (ascOrder)
            {
                return context.Set<T>().Where(whereLambda).OrderBy(orderLambda);
            }
            return context.Set<T>().Where(whereLambda).OrderByDescending(orderLambda);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> whereLambda)
        {
            return context.Set<T>().Where(whereLambda);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        public IQueryable<T> GetCurrentPage<S>(int pageSize, int pageIndex, out int totalCount,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda, bool ascOrder = true)
        {
            var filterData = GetAll<S>(whereLambda, orderLambda, ascOrder);
            totalCount = filterData.Count();
            if (ascOrder)
            {
                return filterData.OrderBy(orderLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            }
            return filterData.OrderByDescending(orderLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }
    }
}
