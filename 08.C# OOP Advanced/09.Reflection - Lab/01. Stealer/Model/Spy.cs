using System;
using System.Linq;
using System.Text;
using System.Reflection;
public class Spy
{
    public string StealFieldInfo(string investigatingClass, params string[] investigateFiels)
    {
        Type classType = Type.GetType(investigatingClass);
        FieldInfo[] classFields = classType
            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder sb = new StringBuilder();
        object classInstance = Activator.CreateInstance(classType, new object[] { });
        sb.AppendLine($"Class under investigation: {investigatingClass}");
        foreach (FieldInfo field in classFields.Where(x => investigateFiels.Contains(x.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }
        return sb.ToString().Trim();
    }
    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        StringBuilder sb = new StringBuilder();
        foreach (FieldInfo field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (MethodInfo method in classPublicMethods.Where(x=>x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }
        foreach (MethodInfo method in classNonPublicMethods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }
        return sb.ToString().Trim();
    }
    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] classMethods = classType
            .GetMethods(BindingFlags.Instance|BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");
        foreach (MethodInfo method in classMethods)
        {
            sb.AppendLine($"{method.Name}");
        }
        return sb.ToString().Trim();
    }
    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] classMethods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Public);
        StringBuilder sb = new StringBuilder();
        foreach (MethodInfo method in classMethods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach (MethodInfo method in classMethods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }
        return sb.ToString().Trim();
    }
}