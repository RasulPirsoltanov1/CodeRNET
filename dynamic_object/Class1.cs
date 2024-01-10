using System;
using System.Reflection;
using System.Reflection.Emit;

public class TypeBuilderCustom
{
    AssemblyName asemblyName;
    void CreateClass(string propertyName, Type propertyType)
    {
        this.asemblyName = new AssemblyName("Test_Builder");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(this.asemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType(this.asemblyName.FullName
                              , TypeAttributes.Public |
                              TypeAttributes.Class |
                              TypeAttributes.AutoClass |
                              TypeAttributes.AnsiClass |
                              TypeAttributes.BeforeFieldInit |
                              TypeAttributes.AutoLayout
                              , null);
        FieldBuilder fieldBuilder = typeBuilder.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);
        PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);


    }
}
                             