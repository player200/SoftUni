using System;
[AttributeUsage(AttributeTargets.Class)]
public class CustomAttribute : Attribute
{
    public CustomAttribute(string author, int revision, string description, params string[] reviewer)
    {
        this.Author = author;
        this.Revision = revision;
        this.Descript = description;
        this.Reviewer = reviewer;
    }
    public string Author { get; }
    public int Revision { get; }
    public string Descript { get; }
    public string[] Reviewer { get; }
}