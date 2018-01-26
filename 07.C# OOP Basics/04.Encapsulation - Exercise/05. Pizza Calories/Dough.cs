using System;
public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;
    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    public string FlourType
    {
        get { return flourType; }
        set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }
    public double GetCalories()
    {
        return 2 * this.weight *this.GetTypeMod()*this.GetTechMod();
    }
    private double GetTypeMod()
    {
        if (this.FlourType.ToLower() == "white")
        {
            return 1.5;
        }
        return 1;
    }
    private double GetTechMod()
    {
        if (this.BakingTechnique.ToLower()== "crispy")
        {
            return 0.9;
        }
        else if (this.BakingTechnique.ToLower() == "chewy")
        {
            return 1.1;
        }
        return 1;
    }
}
