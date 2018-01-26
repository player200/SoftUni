using System;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
public class TypeAttribute : Attribute
{
    private string type;
    public TypeAttribute(string category, string description)
    {
        this.type = "Enumeration";
        this.Category = category;
        this.Description = description;
    }
    public string Type { get { return this.type; } }
    public string Category { get; }
    public string Description { get; }
    public override string ToString()
    {
        return $"Type = {this.Type}, Description = {this.Description}";
    }
}