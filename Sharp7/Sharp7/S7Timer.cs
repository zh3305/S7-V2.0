// Decompiled with JetBrains decompiler
// Type: Sharp7.S7Timer
// Assembly: Sharp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 02CEF60A-46C4-41DA-9A48-13BCB115154D
// Assembly location: D:\Desktop\Sharp7\S7小助手V2.0\bin\Debug\Sharp7.dll

using System;
using System.Collections.Generic;

namespace Sharp7
{
  public class S7Timer
  {
    private TimeSpan pt;
    private TimeSpan et;
    private bool input;
    private bool q;

    public S7Timer(byte[] buff, int position)
    {
      if (position + 12 >= buff.Length)
        return;
      this.SetTimer(new List<byte>((IEnumerable<byte>) buff).GetRange(position, 12).ToArray());
    }

    public S7Timer(byte[] buff) => this.SetTimer(buff);

    private void SetTimer(byte[] buff)
    {
      if (buff.Length != 12)
      {
        this.pt = new TimeSpan(0L);
        this.et = new TimeSpan(0L);
      }
      else
      {
        this.pt = new TimeSpan(0, 0, 0, 0, ((((int) buff[0] << 8) + (int) buff[1] << 8) + (int) buff[2] << 8) + (int) buff[3]);
        this.et = new TimeSpan(0, 0, 0, 0, ((((int) buff[4] << 8) + (int) buff[5] << 8) + (int) buff[6] << 8) + (int) buff[7]);
        this.input = ((int) buff[8] & 1) == 1;
        this.q = ((int) buff[8] & 2) == 2;
      }
    }

    public TimeSpan PT => this.pt;

    public TimeSpan ET => this.et;

    public bool IN => this.input;

    public bool Q => this.q;
  }
}
