using System;
using System.Text;
using System.Reflection;
public class Collector
{
    public string GetAllPriviteFields(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();
        foreach (FieldInfo field in classFields)
        {
            if (field.IsPrivate)
            {
                sb.AppendLine($"private {field.FieldType.Name} {field.Name}");
            }
        }
        return sb.ToString().Trim();
    }
    public string GetAllProtectedFields(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();
        foreach (FieldInfo field in classFields)
        {
            if (field.IsFamily)
            {
                sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
            }
        }
        return sb.ToString().Trim();
    }
    public string GetAllPublicFields(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public);
        StringBuilder sb = new StringBuilder();
        foreach (FieldInfo field in classFields)
        {
            sb.AppendLine($"public {field.FieldType.Name} {field.Name}");
        }
        return sb.ToString().Trim();
    }
    public string GetAllFields(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();
        foreach (FieldInfo field in classFields)
        {
            if (field.IsFamily)
            {
                sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
            }
            else if (field.IsPublic)
            {
                sb.AppendLine($"public {field.FieldType.Name} {field.Name}");
            }
            else if (field.IsPrivate)
            {
                sb.AppendLine($"private {field.FieldType.Name} {field.Name}");
            }
        }
        return sb.ToString().Trim();
    }
}