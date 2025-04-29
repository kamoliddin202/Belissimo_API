using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.IRepasitory;

namespace DataAccessLayer.Repasitories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext appDbContext,
                        IOrderInterface orderInterface,
                        ICategoryInterface categoryInterface,
                        IOrderItemInterface orderItemInterface,
                        IProductInterface productInterface,
                        IPromocodeInterface promocodeInterface)
        {
            _dbContext = appDbContext;
            OrderInterface = orderInterface;
            CategoryInterface = categoryInterface;
            IOrderItemInterface = orderItemInterface;
            ProductInterface = productInterface;
            PromocodeInterface = promocodeInterface;
        }
        public IOrderInterface OrderInterface { get; }

        public ICategoryInterface CategoryInterface { get; }

        public IOrderItemInterface IOrderItemInterface { get; }

        public IProductInterface ProductInterface { get; }

        public IPromocodeInterface PromocodeInterface { get; }

        public async void Dispose()
        => GC.SuppressFinalize(this);

        public async Task SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
    }
}
