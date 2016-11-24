using System;
using System.Linq;
using System.Linq.Expressions;

namespace FoundationFramework.Interfaces
{
    /// <summary>
    /// 定义基本的CRUD接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseLogic<T>
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="id">唯一标识</param>
        /// <returns></returns>
        T this[int id] { get; }

        /// <summary>
        /// 获取满足条件的第一个结果
        /// </summary>
        /// <typeparam name="S">排序元素</typeparam>
        /// <param name="wherelambda">过滤表达式</param>
        /// <param name="orderlambda">排序表达式</param>
        /// <param name="ascOrder">是否升序排列 </param>
        /// <returns></returns>
        T GetFirst<S>(Expression<Func<T, bool>> wherelambda, Expression<Func<T, S>> orderlambda, bool ascOrder = true);

        /// <summary>
        /// 获取满足条件的所有内容
        /// </summary>
        /// <typeparam name="S">排序元素</typeparam>
        /// <param name="whereLambda">过滤表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <param name="ascOrder">是否升序排列</param>
        /// <returns></returns>
        IQueryable<T> GetAll<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda, bool ascOrder = true);

        /// <summary>
        /// 获取满足条件的分页内容
        /// </summary>
        /// <typeparam name="S">排序元素</typeparam>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="totalCount">总的记录数</param>
        /// <param name="whereLambda">过滤表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <param name="ascOrder">是否升序排列</param>
        /// <returns></returns>
        IQueryable<T> GetCurrentPage<S>(int pageSize, int pageIndex, out int totalCount,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda, bool ascOrder = true);

        /// <summary>
        /// 添加新数据，并返回
        /// </summary>
        T Add(T u);

        /// <summary>
        /// 更新数据，并返回
        /// </summary>
        T Update(T u);

        /// <summary>
        /// 删除数据，并返回
        /// </summary>
        T Delete(int id);

        /// <summary>
        /// 逻辑删除数据，并返回
        /// </summary>
        T DeleteByLogic(int id);
    }
}
