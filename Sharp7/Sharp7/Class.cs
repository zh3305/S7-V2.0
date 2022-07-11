// Decompiled with JetBrains decompiler
// Type: Sharp7.Class
// Assembly: Sharp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 02CEF60A-46C4-41DA-9A48-13BCB115154D
// Assembly location: D:\Desktop\Sharp7\S7小助手V2.0\bin\Debug\Sharp7.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


#nullable enable
namespace Sharp7
{
  public static class Class
  {
    public static double GetClassSize(
    #nullable disable
    object instance, double numBytes = 0.0, bool isInnerProperty = false)
    {
      foreach (PropertyInfo accessableProperty in Class.GetAccessableProperties(instance.GetType()))
      {
        if (accessableProperty.PropertyType.IsArray)
        {
          Type elementType = accessableProperty.PropertyType.GetElementType();
          Array array = (Array) accessableProperty.GetValue(instance, (object[]) null);
          if (array.Length <= 0)
            throw new Exception("Cannot determine size of class, because an array is defined which has no fixed size greater than zero.");
          Class.IncrementToEven(ref numBytes);
          for (int index = 0; index < array.Length; ++index)
            numBytes = Class.GetIncreasedNumberOfBytes(numBytes, elementType);
        }
        else
          numBytes = Class.GetIncreasedNumberOfBytes(numBytes, accessableProperty.PropertyType);
      }
      if (!isInnerProperty)
      {
        numBytes = Math.Ceiling(numBytes);
        if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
          ++numBytes;
      }
      return numBytes;
    }

    private static IEnumerable<PropertyInfo> GetAccessableProperties(
      Type classType)
    {
      return ((IEnumerable<PropertyInfo>) classType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (p => p.GetSetMethod() != (MethodInfo) null));
    }

    private static void IncrementToEven(ref double numBytes)
    {
      numBytes = Math.Ceiling(numBytes);
      if (numBytes % 2.0 <= 0.0)
        return;
      ++numBytes;
    }

    private static double GetIncreasedNumberOfBytes(double numBytes, Type type)
    {
      switch (type.Name)
      {
        case "Boolean":
          numBytes += 0.125;
          break;
        case "Byte":
        case "SByte":
          numBytes = Math.Ceiling(numBytes);
          ++numBytes;
          break;
        case "DateTime":
        case "Double":
        case "Int64":
        case "UInt64":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          numBytes += 8.0;
          break;
        case "Int16":
        case "UInt16":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          numBytes += 2.0;
          break;
        case "Int32":
        case "UInt32":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          numBytes += 4.0;
          break;
        case "Single":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          numBytes += 4.0;
          break;
        case "String":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          numBytes += 256.0;
          break;
        default:
          numBytes = Class.GetClassSize(Activator.CreateInstance(type), numBytes, true);
          break;
      }
      return numBytes;
    }

    public static double FromBytes(
      object sourceClass,
      byte[] bytes,
      double numBytes = 0.0,
      bool isInnerClass = false)
    {
      if (bytes == null)
        return numBytes;
      foreach (PropertyInfo accessableProperty in Class.GetAccessableProperties(sourceClass.GetType()))
      {
        if (accessableProperty.PropertyType.IsArray)
        {
          Array array = (Array) accessableProperty.GetValue(sourceClass, (object[]) null);
          Class.IncrementToEven(ref numBytes);
          Type elementType = accessableProperty.PropertyType.GetElementType();
          for (int index = 0; index < array.Length && numBytes < (double) bytes.Length; ++index)
            array.SetValue(Class.GetPropertyValue(elementType, bytes, ref numBytes), index);
        }
        else
          accessableProperty.SetValue(sourceClass, Class.GetPropertyValue(accessableProperty.PropertyType, bytes, ref numBytes), (object[]) null);
      }
      return numBytes;
    }

    private static 
    #nullable enable
    object? GetPropertyValue(
    #nullable disable
    Type propertyType, byte[] bytes, ref double numBytes)
    {
      object propertyValue;
      switch (propertyType.Name)
      {
        case "Boolean":
          int index = (int) Math.Floor(numBytes);
          int y = (int) ((numBytes - (double) index) / 0.125);
          propertyValue = ((uint) bytes[index] & (uint) (int) Math.Pow(2.0, (double) y)) <= 0U ? (object) false : (object) true;
          numBytes += 0.125;
          break;
        case "Byte":
          numBytes = Math.Ceiling(numBytes);
          propertyValue = (object) bytes.GetByteAt((int) numBytes);
          ++numBytes;
          break;
        case "DateTime":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          propertyValue = (object) bytes.GetDateTimeAt((int) numBytes);
          numBytes += 8.0;
          break;
        case "Double":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          propertyValue = (object) bytes.GetLRealAt((int) numBytes);
          numBytes += 8.0;
          break;
        case "Int16":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          propertyValue = (object) (short) bytes.GetIntAt((int) numBytes);
          numBytes += 2.0;
          break;
        case "Int32":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          propertyValue = (object) bytes.GetDIntAt((int) numBytes);
          numBytes += 4.0;
          break;
        case "Int64":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          propertyValue = (object) bytes.GetLIntAt((int) numBytes);
          numBytes += 8.0;
          break;
        case "SByte":
          numBytes = Math.Ceiling(numBytes);
          propertyValue = (object) (sbyte) bytes.GetSIntAt((int) numBytes);
          ++numBytes;
          break;
        case "Single":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          propertyValue = (object) bytes.GetRealAt((int) numBytes);
          numBytes += 4.0;
          break;
        case "String":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          propertyValue = (object) bytes.GetString((int) numBytes);
          numBytes += 256.0;
          break;
        case "UInt16":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          propertyValue = (object) bytes.GetWordAt((int) numBytes);
          numBytes += 2.0;
          break;
        case "UInt32":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          propertyValue = (object) bytes.GetDWordAt((int) numBytes);
          numBytes += 4.0;
          break;
        case "UInt64":
          numBytes = Math.Ceiling(numBytes);
          if (numBytes / 2.0 - Math.Floor(numBytes / 2.0) > 0.0)
            ++numBytes;
          propertyValue = (object) bytes.GetULIntAt((int) numBytes);
          numBytes += 8.0;
          break;
        default:
          object instance = Activator.CreateInstance(propertyType);
          numBytes = Class.FromBytes(instance, bytes, numBytes);
          propertyValue = instance;
          break;
      }
      return propertyValue;
    }
  }
}
