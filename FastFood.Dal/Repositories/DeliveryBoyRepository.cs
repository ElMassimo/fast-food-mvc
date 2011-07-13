using FastFood.Dal.EntityModels;
using FastFood.Dal.Infrastructure;

namespace FastFood.Dal.Repositories
{
    public interface IDeliveryBoyRepository : IRepository<DeliveryBoy>
    {

    }

    public class DeliveryBoyRepository : RepositoryBase<DeliveryBoy>, IDeliveryBoyRepository
    {
    }
}