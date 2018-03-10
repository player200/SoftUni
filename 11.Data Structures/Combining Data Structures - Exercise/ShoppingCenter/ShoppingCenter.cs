using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class ShoppingCenter
{
    private Dictionary<string, List<Product>> byName;
    private Dictionary<string, List<Product>> byProducer;
    private Dictionary<string, List<Product>> byNameProducer;
    private OrderedBag<Product> byPrice;

    public ShoppingCenter()
    {
        this.byName = new Dictionary<string, List<Product>>();
        this.byProducer = new Dictionary<string, List<Product>>();
        this.byNameProducer = new Dictionary<string, List<Product>>();
        this.byPrice = new OrderedBag<Product>((x, y) => x.Price.CompareTo(y.Price));
    }

    public void AddProduct(Product product)
    {
        if (!this.byName.ContainsKey(product.Name))
        {
            this.byName[product.Name] = new List<Product>();
        }
        this.byName[product.Name].Add(product);
        if (!this.byProducer.ContainsKey(product.Producer))
        {
            this.byProducer[product.Producer] = new List<Product>();
        }
        this.byProducer[product.Producer].Add(product);

        string customName = product.Name + product.Producer;
        if (!this.byNameProducer.ContainsKey(customName))
        {
            this.byNameProducer[customName] = new List<Product>();
        }
        this.byNameProducer[customName].Add(product);
        this.byPrice.Add(product);
    }

    public int DeleteProducts(string producer)
    {
        if (!this.byProducer.ContainsKey(producer))
        {
            return 0;
        }

        IEnumerable<Product> finded = this.byProducer[producer];

        int count = 0;
        foreach (var product in finded)
        {
            string name = product.Name;
            string customName = name + producer;
            this.byName[name].Remove(product);
            this.byNameProducer[customName].Remove(product);
            this.byPrice.Remove(product);
            count++;
        }

        this.byProducer.Remove(producer);
        return count;
    }

    public int DeleteProducts(string name, string producer)
    {
        string customName = name + producer;
        if (!this.byNameProducer.ContainsKey(customName))
        {
            return 0;
        }

        IEnumerable<Product> findProducts = this.byNameProducer[customName];

        int count = 0;
        foreach (var product in findProducts)
        {
            this.byName[name].Remove(product);
            this.byProducer.Remove(producer);
            this.byPrice.Remove(product);
            count++;
        }

        this.byNameProducer.Remove(customName);
        return count;
    }

    public IEnumerable<Product> FindProductsByName(string name)
    {
        if (!this.byName.ContainsKey(name))
        {
            return Enumerable.Empty<Product>();
        }

        return this.byName[name].OrderBy(x => x);
    }

    public IEnumerable<Product> FindProductsByProducer(string producer)
    {
        if (!this.byProducer.ContainsKey(producer))
        {
            return Enumerable.Empty<Product>();
        }

        return this.byProducer[producer].OrderBy(x => x);
    }

    public IEnumerable<Product> FindProductsByPriceRange(double startRange, double endRange)
    {
        Product startProduct = new Product("", startRange, "");
        Product endProduct = new Product("", endRange, "");

        return this.byPrice
            .Range(startProduct, true, endProduct, true)
            .OrderBy(x => x);
    }
}