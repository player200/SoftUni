﻿public abstract class Animal
{
    public Animal(string name,string type,double weight) 
    {
        this.Name = name;
        this.Type = type;
        this.Weight = weight;
    }
    protected string Name { get; set; }
    private string Type { get; set; }
    protected double Weight { get; set; }
    protected int FoodEaten { get; set; }

    public abstract string MakeSound();
    public virtual void Eat(Food food)
    {
        this.FoodEaten += food.Quantity;
    }
}