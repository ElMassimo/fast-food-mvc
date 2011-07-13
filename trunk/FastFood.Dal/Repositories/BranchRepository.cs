using FastFood.Dal.EntityModels;
using FastFood.Dal.Infrastructure;

namespace FastFood.Dal.Repositories
{
    public interface IBranchRepository : IRepository<Branch>
    {

    }

    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
    }
}