using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Entity.OrderAggregate;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<DeliveryMethod> _dmRepo;
        private readonly IGenericRepository<Product> _productRepo;
         private readonly IBasketRepository _basketRepository;
        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<DeliveryMethod> dmRepo, IGenericRepository<Product> productRepo,
       
        IBasketRepository basketRepository)
        {
           _basketRepository = basketRepository;
           _productRepo = productRepo;
           _dmRepo = dmRepo;
           _orderRepo = orderRepo;

        }
    public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
    {
        //get basket from the repo
        var basket = await _basketRepository.GetBasketAsync(basketId);

        //get items from the product rep
        var items = new List<OrderItem>();
        foreach(var item in basket.Items)
        {
            var productItem = await _productRepo.GetByIdAsync(item.Id);
            var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
            var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
            items.Add(orderItem);
        }

        //get deliveryMethod
        var deliveryMethod = await _dmRepo.GetByIdAsync(deliveryMethodId);

        //calcualte subtotal
        var subtotal = items.Sum(item => item.Price * item.Quantity);

        //create order
        var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, (double)subtotal);
        //save to db

        //return order
        return order;
    }

    public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
    {
        throw new System.NotImplementedException();
    }

    public Task<IReadOnlyList<Order>> GetOrderForUserAsync(string buyerEmail)
    {
        throw new System.NotImplementedException();
    }
}
}