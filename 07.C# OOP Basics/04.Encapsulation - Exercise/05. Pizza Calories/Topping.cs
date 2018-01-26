using System;
public class Topping
{
    private string type;
    private double weight;
    public Topping(string type,double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value<1||value>50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public string Type
    {
        get { return type; }
        set
        {
            if (value.ToLower()!= "meat"&& value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }
    public double GetCalories()
    {
        return 2*this.weight*this.TypesMod();
    }
    private double TypesMod()
    {
        if (this.type.ToLower()== "meat")
        {
            return 1.2;
        }
        else if(this.type.ToLower() == "veggies")
        {
            return 0.8;
        }
        else if (this.type.ToLower() == "cheese")
        {
            return 1.1;
        }
        return 0.9;
    }
}
