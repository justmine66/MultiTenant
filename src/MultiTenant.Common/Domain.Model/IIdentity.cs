namespace MultiTenant.Common.Domain.Model
{
    /// <summary>
    /// 表示一个标识接口
    /// </summary>
    /// <typeparam name="TType">类型</typeparam>
    public interface IIdentity<TType>
    {
        TType Id { get; }
    }
}
