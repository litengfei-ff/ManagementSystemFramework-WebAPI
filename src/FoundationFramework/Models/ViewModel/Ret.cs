using LTF.Models.Enums;

namespace LTF.Models.ViewModel
{
    /// <summary>
    /// 返回消息类型
    /// </summary>
    public class Ret
    {
        /// <summary>
        /// 返回代码 0为正常，其他为异常
        /// </summary>
        public ReCodeEnum ReCode { get; set; }

        /// <summary>
        /// 返回说明
        /// </summary>
        public string Msg { get; set; }
    }

    /// <summary>
    /// 返回消息类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Ret<T> : Ret
    {
        /// <summary>
        /// 返回的数据
        /// </summary>
        public T Data { get; set; }

    }

}