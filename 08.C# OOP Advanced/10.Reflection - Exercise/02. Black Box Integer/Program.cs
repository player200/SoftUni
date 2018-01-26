using System;
using System.Reflection;
class Program
{
    static void Main()
    {
        string inputLine;
        Type classType = Type.GetType("BlackBoxInt");
        ConstructorInfo ctor = classType
            .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(int) }, null);
        BlackBoxInt box = (BlackBoxInt)ctor
            .Invoke(new object[] { 0 });
        while ((inputLine = Console.ReadLine()) != "END")
        {
            string[] tokens = inputLine.Split('_');
            MethodInfo classMethod = classType
                .GetMethod(tokens[0], BindingFlags.Instance | BindingFlags.NonPublic);
            classMethod.Invoke(box, new object[] { int.Parse(tokens[1]) });
            FieldInfo value = classType
                .GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
            Console.WriteLine(value.GetValue(box));
        }
    }
}