using System;

public class Product : IComparable<Product>
{
    public Product(string name,double price,string producer)
    {
        this.Name = name;
        this.Price = price;
        this.Producer = producer;
    }

    public string Name { get; set; }

    public double Price { get; set; }

    public string Producer { get; set; }

    public int CompareTo(Product other)
    {
        int compare = this.Name.CompareTo(other.Name);

        if (compare == 0)
        {
            compare = this.Producer.CompareTo(other.Producer);
            if (compare == 0)
            {
                return this.Price.CompareTo(other.Price);
            }
        }

        return compare;
    }

    public override string ToString()
    {
        return "{" + $"{this.Name};{this.Producer};{this.Price:f2}" + "}";
    }
}