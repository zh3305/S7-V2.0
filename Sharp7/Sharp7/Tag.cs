// Decompiled with JetBrains decompiler
// Type: Sharp7.Tag
// Assembly: Sharp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 02CEF60A-46C4-41DA-9A48-13BCB115154D
// Assembly location: D:\Desktop\Sharp7\S7小助手V2.0\bin\Debug\Sharp7.dll

using System;

namespace Sharp7
{
  public class Tag
  {
    public S7Type s7type { set; get; }

    public Decimal address { set; get; }

    public object value { set; get; }

    public string name { set; get; }

    public Tag(S7Type S7Type, Decimal Address, object Value, string Name)
    {
      this.s7type = S7Type;
      this.address = Address;
      this.value = Value;
      this.name = Name;
    }
  }
}
