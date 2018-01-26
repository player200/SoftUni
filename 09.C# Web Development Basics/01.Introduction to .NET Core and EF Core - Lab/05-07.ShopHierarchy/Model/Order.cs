namespace _05_07.ShopHierarchy.Model
{
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<ItemOrders> Items { get; set; } = new List<ItemOrders>();
    }
}