﻿public class Cymric:Cat
{
    public Cymric(string name, double furLength)
    {
        this.Name = name;
        this.FurLength = furLength;
    }
    public double FurLength { get; set; }
    public override string ToString()
    {
        return $"Cymric {this.Name} {this.FurLength:f2}";
    }
}
