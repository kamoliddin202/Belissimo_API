using DataAccessLayer.IRepasitory;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderInterface OrderInterface { get; }
        ICategoryInterface CategoryInterface { get; }
        IOrderItemInterface IOrderItemInterface { get; }
        IProductInterface ProductInterface { get; }
        IPromocodeInterface PromocodeInterface { get; }
        Task SaveChangesAsync();
    }
}
