namespace _05_07.ShopHierarchy
{
    using _05_07.ShopHierarchy.Model;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            using (var db = new ShopingDbContext())
            {
                PrepareDb(db);
                SalesmanIncert(db);
                //task N-7
                ItemsInsert(db);

                CommandsUser(db);
                //task N-5
                //PrintSalesmanWithCustomers(db);
                //task N-6
                //PrintingCustomersWithOrdersAndReviews(db);
                //task N-7
                //PrintNewOrderAndReviewItemPattern(db);
                //task N-8
                //PrintAllInfoOfDb(db);
                //task N-9
                PrintCustomersCountOfOrders(db);
            }
        }

        private static void PrepareDb(ShopingDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        private static void SalesmanIncert(ShopingDbContext db)
        {
            string[] inputLine = Console.ReadLine()
                .Split(';');

            foreach (var salesman in inputLine)
            {
                db.Add(new Salesman { Name = salesman });
            }
            db.SaveChanges();
        }

        private static void ItemsInsert(ShopingDbContext db)
        {
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] tokens = inputLine.Split(';');
                string name = tokens[0];
                decimal price = decimal.Parse(tokens[1]);

                db.Add(new Item { Name = name, Price = price });
                db.SaveChanges();
            }
        }

        private static void CommandsUser(ShopingDbContext db)
        {
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] tokens = inputLine
                    .Split('-');

                string command = tokens[0];
                string items = tokens[1];
                switch (command)
                {
                    case "register":
                        RegisterCommand(items, db);
                        break;
                    case "order":
                        OrderCommand(items, db);
                        break;
                    case "review":
                        ReviewCommand(items, db);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintSalesmanWithCustomers(ShopingDbContext db)
        {
            var salesmen = db.Salesman
                .Select(s => new
                {
                    s.Name,
                    Customer = s.Customers.Count
                })
                .OrderByDescending(s => s.Customer)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var salesman in salesmen)
            {
                Console.WriteLine($"{salesman.Name} - {salesman.Customer} customers");
            }
        }

        private static void RegisterCommand(string items, ShopingDbContext db)
        {
            string[] attributes = items.Split(';');
            string customerName = attributes[0];
            int salesmanId = int.Parse(attributes[1]);

            db.Add(new Customer { Name = customerName, SalesmentId = salesmanId });
            db.SaveChanges();
        }

        private static void OrderCommand(string items, ShopingDbContext db)
        {
            string[] tokens = items.Split(';');
            int customerId = int.Parse(tokens[0]);

            Order order = new Order { CustomerId = customerId };

            for (int i = 1; i < tokens.Length; i++)
            {
                order.Items.Add(new ItemOrders
                {
                    ItemId = int.Parse(tokens[i])
                });
            }
            db.Add(order);
            db.SaveChanges();
        }

        private static void ReviewCommand(string items, ShopingDbContext db)
        {
            string[] tokens = items.Split(';');
            int customerId = int.Parse(tokens[0]);
            int itemId = int.Parse(tokens[1]);

            db.Add(new Review { CustomerId = customerId, ItemId = itemId });
            db.SaveChanges();
        }

        private static void PrintingCustomersWithOrdersAndReviews(ShopingDbContext db)
        {
            var data = db.Customer
                .Select(c => new
                {
                    c.Name,
                    Orders = c.Orders.Count,
                    Reviews = c.Reviews.Count
                })
                .OrderByDescending(c => c.Orders)
                .ThenByDescending(c => c.Reviews)
                .ToList();

            foreach (var customerData in data)
            {
                Console.WriteLine($"{customerData.Name}");
                Console.WriteLine($"Orders: {customerData.Orders}");
                Console.WriteLine($"Reviews: {customerData.Reviews}");
            }
        }

        private static void PrintNewOrderAndReviewItemPattern(ShopingDbContext db)
        {
            int customerId = int.Parse(Console.ReadLine());

            var customerData = db
                .Customer
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    Order = c.Orders
                    .Select(o => new
                    {
                        o.Id,
                        Item = o.Items.Count
                    }),
                    Review = c.Reviews.Count
                })
                .FirstOrDefault();
            foreach (var order in customerData.Order)
            {
                Console.WriteLine($"order {order.Id}: {order.Item} items");
            }
            Console.WriteLine($"reviews: {customerData.Review}");
        }

        private static void PrintAllInfoOfDb(ShopingDbContext db)
        {
            int customerId = int.Parse(Console.ReadLine());

            var customerData = db
                .Customer
                .Where(c => c.Id == customerId)
                .Select(c => new
                {
                    c.Name,
                    Order = c.Orders.Count,
                    Review = c.Reviews.Count,
                    Salesman = c.Salesman.Name
                })
                .FirstOrDefault();

            Console.WriteLine($"Customer: {customerData.Name}");
            Console.WriteLine($"Orders count: {customerData.Order}");
            Console.WriteLine($"Reviews count: {customerData.Review}");
            Console.WriteLine($"Salesman: {customerData.Salesman}");
        }

        private static void PrintCustomersCountOfOrders(ShopingDbContext db)
        {
            int customerId = int.Parse(Console.ReadLine());

            int orderCount = db
                .Order
                .Where(o=>o.CustomerId == customerId)
                .Where(o=>o.Items.Count>1)
                .Count();

            Console.WriteLine($"Orders: {orderCount}");
        }
    }
}