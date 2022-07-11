// Decompiled with JetBrains decompiler
// Type: Sharp7.List
// Assembly: Sharp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 02CEF60A-46C4-41DA-9A48-13BCB115154D
// Assembly location: D:\Desktop\Sharp7\S7小助手V2.0\bin\Debug\Sharp7.dll

namespace Sharp7
{
  public class List
  {
    public S7Area s7Area { set; get; }

    public int dbNumber { set; get; }

    public int start { set; get; }

    public int size { set; get; }

    public S7Type s7Type { set; get; }

    public byte[] buff { set; get; }

    public S7WordLength s7WordLength { set; get; }

    public List(
      S7Area S7Area,
      int DbNumber,
      int Start,
      int Size,
      S7Type S7Type,
      byte[] Buffer,
      S7WordLength S7WordLength)
    {
      this.s7Area = S7Area;
      this.dbNumber = DbNumber;
      this.start = Start;
      this.size = Size;
      this.s7Type = S7Type;
      this.buff = Buffer;
      this.s7WordLength = S7WordLength;
    }
  }
}
