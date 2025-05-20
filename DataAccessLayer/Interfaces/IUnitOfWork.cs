    using System.Formats.Tar;
    using DataAccessLayer.IRepasitory;
using Microsoft.EntityFrameworkCore.Metadata;

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
