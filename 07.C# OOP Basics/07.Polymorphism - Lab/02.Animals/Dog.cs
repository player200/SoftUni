﻿using System;
public class Dog : Animal
{
    public Dog(string name, string favoriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favoriteFood;
    }
    public override string ExplainMyself()
    {
        return base.ExplainMyself() + Environment.NewLine + "DJAAF";
    }
}