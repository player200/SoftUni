using System;
using System.Collections.Generic;
using System.Linq;
public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    private int numberOfToppings;
    public Pizza(string name,int numberOfToppings)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
        this.NumberOfToppings = numberOfToppings;
    }
    public Dough Dough
    {
        set { this.dough = value; }
    }
    public int NumberOfToppings
    {
        get { return numberOfToppings; }
        set
        {
            if (value<1||value>10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            numberOfToppings = value;
        }
    }
    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length>15 || value.Length<1)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }
    public void AddTopping(Topping topping)
    {
        this.toppings.Add(topping);
    }
    public double GetCalories()
    {
        return this.dough.GetCalories() + this.toppings.Sum(x=>x.GetCalories());
    }
}
