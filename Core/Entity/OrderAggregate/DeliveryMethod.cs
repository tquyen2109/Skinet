namespace Core.Entity.OrderAggregate
{
    public class DeliveryMethod : BaseEntity 
    {
        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}