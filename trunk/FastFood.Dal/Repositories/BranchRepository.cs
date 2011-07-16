using FastFood.Dal.EntityModels;
using FastFood.Dal.Infrastructure;

namespace FastFood.Dal.Repositories
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {

    }

    public class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
    }
}