using System.Threading.Tasks;
using Core.Entity;

namespace Core.Interfaces
{
    public interface IPaymentService
    {
         Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
    }
}