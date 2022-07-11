// Decompiled with JetBrains decompiler
// Type: Sharp7.Package
// Assembly: Sharp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 02CEF60A-46C4-41DA-9A48-13BCB115154D
// Assembly location: D:\Desktop\Sharp7\S7小助手V2.0\bin\Debug\Sharp7.dll

namespace Sharp7
{
  public class Package
  {
    public int dbnumber { set; get; }

    public S7Area s7area { set; get; }

    public int startaddress { set; get; }

    public int lenght { set; get; }

    public byte[] buff { set; get; }

    public int status { set; get; }

    public Package(
      int DbNumber,
      S7Area S7area,
      int StartAddress,
      int Lenght,
      byte[] Buff,
      int Status = 0)
    {
      this.dbnumber = DbNumber;
      this.s7area = S7area;
      this.startaddress = StartAddress;
      this.lenght = Lenght;
      this.buff = Buff;
      this.status = Status;
    }
  }
}
