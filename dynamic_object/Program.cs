using System;
using System.Reflection;
using System.Reflection.Emit;

public class DynamicClassBuilder
{
    public static Type CreateClass(string className, Tuple<string, Type>[] properties)
    {
        AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType(className, TypeAttributes.Public);

        foreach (var property in properties)
        {
            string propertyName = property.Item1;
            Type propertyType = property.Item2;

            // Define a private field for the property
            FieldBuilder fieldBuilder = typeBuilder.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

            // Define the property
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);

            // Define the getter method
            MethodBuilder getterMethod = typeBuilder.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            ILGenerator getterIL = getterMethod.GetILGenerator();
            getterIL.Emit(OpCodes.Ldarg_0);
            getterIL.Emit(OpCodes.Ldfld, fieldBuilder);
            getterIL.Emit(OpCodes.Ret);

            // Define the setter method
            MethodBuilder setterMethod = typeBuilder.DefineMethod("set_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new[] { propertyType });
            ILGenerator setterIL = setterMethod.GetILGenerator();
            setterIL.Emit(OpCodes.Ldarg_0);
            setterIL.Emit(OpCodes.Ldarg_1);
            setterIL.Emit(OpCodes.Stfld, fieldBuilder);
            setterIL.Emit(OpCodes.Ret);

            // Set the getter and setter methods for the property
            propertyBuilder.SetGetMethod(getterMethod);
            propertyBuilder.SetSetMethod(setterMethod);
        }

        // Create the type
        Type dynamicType = typeBuilder.CreateType();

        return dynamicType;
    }

    static void Main()
    {
        // Example: Create a class with two properties, int Id and string Name
        var properties = new[]
        {
            Tuple.Create("Id", typeof(int)),
            Tuple.Create("Name", typeof(string))
        };

        Type dynamicType = CreateClass("DynamicPerson", properties);

        // Now you can use dynamicType to create instances and access properties dynamically
        object instance = Activator.CreateInstance(dynamicType);

        dynamicType.GetProperty("Id")?.SetValue(instance, 1);
        dynamicType.GetProperty("Name")?.SetValue(instance, "John Doe");

        Console.WriteLine($"Id: {dynamicType.GetProperty("Id")?.GetValue(instance)}");
        Console.WriteLine($"Name: {dynamicType.GetProperty("Name")?.GetValue(instance)}");
    }
}
