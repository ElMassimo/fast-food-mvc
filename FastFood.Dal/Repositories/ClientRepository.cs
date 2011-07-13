using FastFood.Dal.EntityModels;
using FastFood.Dal.Infrastructure;

namespace FastFood.Dal.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {

    }

    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
    }
}
