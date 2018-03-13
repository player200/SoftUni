using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Instock : IProductStock
{
    private List<Product> products;
    private Dictionary<string, Product> byTests;
    private Dictionary<int, List<Product>> byQuarity;

    public Instock()
    {
        this.products = new List<Product>();
        this.byTests = new Dictionary<string, Product>();
        this.byQuarity = new Dictionary<int, List<Product>>();
    }

    public int Count => this.byTests.Count;

    public void Add(Product product)
    {
        this.products.Add(product);
        if (!this.byTests.ContainsKey(product.Label))
        {
            this.byTests.Add(product.Label, product);
        }
        if (!this.byQuarity.ContainsKey(product.Quantity))
        {
            this.byQuarity[product.Quantity] = new List<Product>();
        }
        this.byQuarity[product.Quantity].Add(product);
    }

    public void ChangeQuantity(string product, int quantity)
    {
        if (!this.byTests.ContainsKey(product))
        {
            throw new ArgumentException();
        }
        var currentTest = this.byTests[product];

        this.byTests.Remove(product);
        this.byQuarity.Remove(currentTest.Quantity);

        currentTest.Quantity = quantity;

        this.byTests.Add(product, currentTest);
        if (!this.byQuarity.ContainsKey(quantity))
        {
            this.byQuarity[quantity] = new List<Product>();
        }
        this.byQuarity[quantity].Add(currentTest);
        this.products.Add(currentTest);
    }

    public bool Contains(Product product)
    {
        return this.byTests.ContainsKey(product.Label);
    }

    public Product Find(int index)
    {
        if (index >= 0 && this.Count > index)
        {
            return this.products[index];
        }
        throw new IndexOutOfRangeException();
    }

    public IEnumerable<Product> FindAllByPrice(double price)
    {
        return this.byTests.Values
            .Where(x => x.Price == price);
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity)
    {
        if (!this.byQuarity.ContainsKey(quantity))
        {
            return Enumerable.Empty<Product>();
        }

        return this.byQuarity[quantity];
    }

    public IEnumerable<Product> FindAllInRange(double lo, double hi)
    {
        return this.byTests.Values
            .Where(x => x.Price > lo
            && x.Price <= hi)
            .OrderByDescending(x => x.Price);
    }

    public Product FindByLabel(string label)
    {
        if (!this.byTests.ContainsKey(label))
        {
            throw new ArgumentException();
        }

        return this.byTests[label];
    }

    public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
    {
        var result = this.byTests.Values.OrderBy(x => x);

        if (result.Count() < count)
        {
            throw new ArgumentException();
        }

        return result.Take(count);
    }

    public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
    {
        var result = this.byTests.Values
            .OrderByDescending(x => x.Price)
            .Take(count);
        if (result.Count() < count)
        {
            throw new ArgumentException();
        }
        return result;
    }

    public IEnumerator<Product> GetEnumerator()
    {
        foreach (var product in this.byTests.Values)
        {
            yield return product;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}