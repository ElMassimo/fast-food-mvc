using FastFood.Dal.EntityModels;
using FastFood.Dal.Infrastructure;

namespace FastFood.Dal.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {

    }

    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
    }
}