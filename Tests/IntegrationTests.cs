﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Fody;
using Xunit;
#pragma warning disable 618

public class IntegrationTests
{
    static Assembly assembly;
    static TestResult testResult;

    static IntegrationTests()
    {
        var weavingTask = new ModuleWeaver();
#if(NET46)
        testResult = weavingTask.ExecuteTestRun("AssemblyToProcess.dll",ignoreCodes:new []{ "0x80131869"});
#else
        testResult = weavingTask.ExecuteTestRun("AssemblyToProcess.dll", runPeVerify: false);
#endif
        assembly = testResult.Assembly;
    }

    [Fact]
    public void GenericPropertyGet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericPropertyGetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetPropertyGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericPropertySet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericPropertySetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetPropertyGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticPropertyGet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticPropertyGetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetPropertyGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticPropertySet()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticPropertySetGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetPropertyGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericField()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceField();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void GenericFieldGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceFieldGeneric();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void GenericStaticField()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticField();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void GenericStaticFieldGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticFieldGeneric();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void GetSystemGeneric()
    {
        var type = assembly.GetType("Extra");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetSystemGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericMethod()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericMethodGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethodGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticMethod()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethod();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericStaticMethodGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethodGeneric();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GenericTypeInfo()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeinfo = instance.GetTypeInfo();
        Assert.NotNull(typeinfo);
    }

    [Fact]
    public void GenericTypeInfoGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeinfo = instance.GetTypeInfoGeneric();
        Assert.NotNull(typeinfo);

        var genericParams = typeinfo.GenericTypeArguments;
        Assert.NotNull(genericParams);
        Assert.NotEmpty(genericParams);
        Assert.Equal(typeof(IDictionary<string, int>), genericParams[0]);
    }

    [Fact]
    public void InstancePropertyGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceGetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void InstancePropertySet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceSetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void StaticPropertyGet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticGetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void StaticPropertySet()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticSetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void PropertyGetWithNamespace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetGetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void PropertySetWithNamespace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetSetProperty();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void InstanceField()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetInstanceField();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void StaticField()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetStaticField();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void FieldClassWithNameSpace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        FieldInfo fieldInfo = instance.GetField();
        Assert.NotNull(fieldInfo);
    }

    [Fact]
    public void InstanceMethod()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void InstanceMethodWithParams()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetMethodWithParams();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void StaticMethod()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetStaticMethod();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void MethodWithNameSpace()
    {
        var type = assembly.GetType("MyNamespace.InstanceClassWithNameSpace");
        var instance = (dynamic) Activator.CreateInstance(type);
        MethodInfo methodInfo = instance.GetInstanceMethod();
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void TypeInfo()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeinfo = instance.GetTypeInfo();
        Assert.NotNull(typeinfo);
    }

    [Fact]
    public void TypeInfoFromInternal()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        Type typeinfo = instance.GetTypeInfoFromInternal();
        Assert.NotNull(typeinfo);
    }

    [Fact]
    public void InstanceConstructor()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfo();
        Assert.NotNull(constructorInfo);
    }

    [Fact]
    public void InstanceConstructorWithParam()
    {
        var type = assembly.GetType("InstanceClass");
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoWithParam();
        Assert.NotNull(constructorInfo);
    }

    [Fact]
    public void GenericConstructor()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfo();
        Assert.NotNull(constructorInfo);
    }

    [Fact]
    public void GenericConstructorGeneric()
    {
        var type = assembly.GetType("GenericClass`1");
        type = type.MakeGenericType(typeof(int));
        var instance = (dynamic) Activator.CreateInstance(type);
        ConstructorInfo constructorInfo = instance.GetConstructorInfoGeneric();
        Assert.NotNull(constructorInfo);
    }
}