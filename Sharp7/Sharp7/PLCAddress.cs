// Decompiled with JetBrains decompiler
// Type: Sharp7.PLCAddress
// Assembly: Sharp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 02CEF60A-46C4-41DA-9A48-13BCB115154D
// Assembly location: D:\Desktop\Sharp7\S7小助手V2.0\bin\Debug\Sharp7.dll

using System;

namespace Sharp7
{
  internal class PLCAddress
  {
    private S7Area s7Area;
    private int dbNumber = 0;
    private int start = 0;
    private int size = 0;
    private S7Type s7Type;
    private byte[] butter;
    private S7WordLength s7WordLength;

    public S7Area S7Area
    {
      get => this.s7Area;
      set => this.s7Area = value;
    }

    public int DBNumber
    {
      get => this.dbNumber;
      set => this.dbNumber = value;
    }

    public int Start
    {
      get => this.start;
      set => this.start = value;
    }

    public int Size
    {
      get => this.size;
      set => this.size = value;
    }

    public S7Type S7Type
    {
      get => this.s7Type;
      set => this.s7Type = value;
    }

    public S7WordLength S7WordLength
    {
      get => this.s7WordLength;
      set => this.s7WordLength = value;
    }

    public byte[] Butter
    {
      get => this.butter;
      set => this.butter = value;
    }

    public PLCAddress(string address, S7Type type) => PLCAddress.Parse(address, type, out this.s7Type, out this.dbNumber, out this.s7Area, out this.s7WordLength, out this.start, out this.size, out this.butter);

    public static void Parse(
      string address,
      S7Type type,
      out S7Type s7Type,
      out int dbNumber,
      out S7Area s7Area,
      out S7WordLength s7WordLength,
      out int start,
      out int size,
      out byte[] butter)
    {
      s7Type = type;
      string upper = address.Substring(0, 1).ToUpper();
      if (!(upper == "D"))
      {
        if (!(upper == "I") && !(upper == "E"))
        {
          if (upper == "Q" || upper == "A" || upper == "O")
          {
            s7Area = S7Area.PA;
            dbNumber = 0;
            start = int.Parse(address.Substring(1).Split('.')[0]);
            switch (s7Type)
            {
              case S7Type.Bit:
                butter = new byte[1];
                size = butter.Length;
                start = int.Parse(address.Substring(1).Split('.')[1]) + start * 8;
                s7WordLength = S7WordLength.Bit;
                break;
              case S7Type.Byte:
                butter = new byte[1];
                size = butter.Length;
                s7WordLength = S7WordLength.Byte;
                break;
              case S7Type.Word:
                butter = new byte[2];
                size = 1;
                s7WordLength = S7WordLength.Word;
                break;
              case S7Type.Int:
                butter = new byte[2];
                size = 1;
                s7WordLength = S7WordLength.Int;
                break;
              case S7Type.DWord:
                butter = new byte[4];
                size = 1;
                s7WordLength = S7WordLength.DWord;
                break;
              case S7Type.DInt:
                butter = new byte[4];
                size = 1;
                s7WordLength = S7WordLength.DInt;
                break;
              case S7Type.Real:
                butter = new byte[4];
                size = 1;
                s7WordLength = S7WordLength.Real;
                break;
              case S7Type.LReal:
                butter = new byte[8];
                size = 8;
                s7WordLength = S7WordLength.Byte;
                break;
              case S7Type.LWord:
                butter = new byte[8];
                size = 8;
                s7WordLength = S7WordLength.Byte;
                break;
              case S7Type.LInt:
                butter = new byte[8];
                size = 8;
                s7WordLength = S7WordLength.Byte;
                break;
              case S7Type.DateTime:
                butter = new byte[8];
                size = 8;
                s7WordLength = S7WordLength.Byte;
                break;
              default:
                butter = new byte[0];
                size = butter.Length;
                s7WordLength = S7WordLength.Bit;
                break;
            }
          }
          else
          {
            s7Area = S7Area.MK;
            dbNumber = 0;
            start = int.Parse(address.Substring(1).Split('.')[0]);
            switch (s7Type)
            {
              case S7Type.Bit:
                butter = new byte[1];
                size = butter.Length;
                start = int.Parse(address.Substring(1).Split('.')[1]) + start * 8;
                s7WordLength = S7WordLength.Bit;
                break;
              case S7Type.Byte:
                butter = new byte[1];
                size = butter.Length;
                s7WordLength = S7WordLength.Byte;
                break;
              case S7Type.Word:
                butter = new byte[2];
                size = 1;
                s7WordLength = S7WordLength.Word;
                break;
              case S7Type.Int:
                butter = new byte[2];
                size = 1;
                s7WordLength = S7WordLength.Int;
                break;
              case S7Type.DWord:
                butter = new byte[4];
                size = 1;
                s7WordLength = S7WordLength.DWord;
                break;
              case S7Type.DInt:
                butter = new byte[4];
                size = 1;
                s7WordLength = S7WordLength.DInt;
                break;
              case S7Type.Real:
                butter = new byte[4];
                size = 1;
                s7WordLength = S7WordLength.Real;
                break;
              case S7Type.LReal:
                butter = new byte[8];
                size = 8;
                s7WordLength = S7WordLength.Byte;
                break;
              case S7Type.LWord:
                butter = new byte[8];
                size = 8;
                s7WordLength = S7WordLength.Byte;
                break;
              case S7Type.LInt:
                butter = new byte[8];
                size = 8;
                s7WordLength = S7WordLength.Byte;
                break;
              case S7Type.DateTime:
                butter = new byte[8];
                size = 8;
                s7WordLength = S7WordLength.Byte;
                break;
              default:
                butter = new byte[0];
                size = butter.Length;
                s7WordLength = S7WordLength.Bit;
                break;
            }
          }
        }
        else
        {
          s7Area = S7Area.PE;
          dbNumber = 0;
          start = int.Parse(address.Substring(1).Split('.')[0]);
          switch (s7Type)
          {
            case S7Type.Bit:
              butter = new byte[1];
              size = butter.Length;
              start = int.Parse(address.Substring(1).Split('.')[1]) + start * 8;
              s7WordLength = S7WordLength.Bit;
              break;
            case S7Type.Byte:
              butter = new byte[1];
              size = butter.Length;
              s7WordLength = S7WordLength.Byte;
              break;
            case S7Type.Word:
              butter = new byte[2];
              size = 1;
              s7WordLength = S7WordLength.Word;
              break;
            case S7Type.Int:
              butter = new byte[2];
              size = 1;
              s7WordLength = S7WordLength.Int;
              break;
            case S7Type.DWord:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.DWord;
              break;
            case S7Type.DInt:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.DInt;
              break;
            case S7Type.Real:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.Real;
              break;
            case S7Type.LReal:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              break;
            case S7Type.LWord:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              break;
            case S7Type.LInt:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              break;
            case S7Type.DateTime:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              break;
            default:
              butter = new byte[0];
              size = butter.Length;
              s7WordLength = S7WordLength.Bit;
              break;
          }
        }
      }
      else
      {
        string[] strArray = address.Split('.');
        if (strArray.Length >= 2)
          ;
        s7Area = S7Area.DB;
        dbNumber = int.Parse(strArray[0].Substring(1));
        start = int.Parse(strArray[1]);
        switch (s7Type)
        {
          case S7Type.Bit:
            butter = new byte[1];
            size = butter.Length;
            start = int.Parse(strArray[2]) + start * 8;
            s7WordLength = S7WordLength.Bit;
            break;
          case S7Type.Byte:
            butter = new byte[1];
            size = butter.Length;
            s7WordLength = S7WordLength.Byte;
            break;
          case S7Type.Word:
            butter = new byte[2];
            size = 1;
            s7WordLength = S7WordLength.Word;
            break;
          case S7Type.Int:
            butter = new byte[2];
            size = 1;
            s7WordLength = S7WordLength.Int;
            break;
          case S7Type.DWord:
            butter = new byte[4];
            size = 1;
            s7WordLength = S7WordLength.DWord;
            break;
          case S7Type.DInt:
            butter = new byte[4];
            size = 1;
            s7WordLength = S7WordLength.DInt;
            break;
          case S7Type.Real:
            butter = new byte[4];
            size = 1;
            s7WordLength = S7WordLength.Real;
            break;
          case S7Type.LReal:
            butter = new byte[8];
            size = 8;
            s7WordLength = S7WordLength.Byte;
            break;
          case S7Type.LWord:
            butter = new byte[8];
            size = 8;
            s7WordLength = S7WordLength.Byte;
            break;
          case S7Type.LInt:
            butter = new byte[8];
            size = 8;
            s7WordLength = S7WordLength.Byte;
            break;
          case S7Type.DateTime:
            butter = new byte[8];
            size = 8;
            s7WordLength = S7WordLength.Byte;
            break;
          default:
            butter = new byte[0];
            size = butter.Length;
            s7WordLength = S7WordLength.Bit;
            break;
        }
      }
    }

    public PLCAddress(S7Area area, int db, Decimal address, S7Type type) => PLCAddress.Parse(address, type, area, db, out this.s7Type, out this.dbNumber, out this.s7Area, out this.s7WordLength, out this.start, out this.size, out this.butter);

    public static void Parse(
      Decimal address,
      S7Type type,
      S7Area area,
      int db,
      out S7Type s7Type,
      out int dbNumber,
      out S7Area s7Area,
      out S7WordLength s7WordLength,
      out int start,
      out int size,
      out byte[] butter)
    {
      s7Type = type;
      s7Area = area;
      dbNumber = db;
      switch (s7Area)
      {
        case S7Area.PE:
          switch (s7Type)
          {
            case S7Type.Bit:
              butter = new byte[1];
              size = butter.Length;
              start = int.Parse(address.ToString().Split('.')[1]) + int.Parse(address.ToString().Split('.')[0]) * 8;
              s7WordLength = S7WordLength.Bit;
              return;
            case S7Type.Byte:
              butter = new byte[1];
              size = butter.Length;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.Word:
              butter = new byte[2];
              size = 1;
              s7WordLength = S7WordLength.Word;
              start = (int) address;
              return;
            case S7Type.Int:
              butter = new byte[2];
              size = 1;
              s7WordLength = S7WordLength.Int;
              start = (int) address;
              return;
            case S7Type.DWord:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.DWord;
              start = (int) address;
              return;
            case S7Type.DInt:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.DInt;
              start = (int) address;
              return;
            case S7Type.Real:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.Real;
              start = (int) address;
              return;
            case S7Type.LReal:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.LWord:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.LInt:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.DateTime:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            default:
              butter = new byte[0];
              size = butter.Length;
              s7WordLength = S7WordLength.Bit;
              start = (int) address;
              return;
          }
        case S7Area.PA:
          switch (s7Type)
          {
            case S7Type.Bit:
              butter = new byte[1];
              size = butter.Length;
              start = int.Parse(address.ToString().Split('.')[1]) + int.Parse(address.ToString().Split('.')[0]) * 8;
              s7WordLength = S7WordLength.Bit;
              return;
            case S7Type.Byte:
              butter = new byte[1];
              size = butter.Length;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.Word:
              butter = new byte[2];
              size = 1;
              s7WordLength = S7WordLength.Word;
              start = (int) address;
              return;
            case S7Type.Int:
              butter = new byte[2];
              size = 1;
              s7WordLength = S7WordLength.Int;
              start = (int) address;
              return;
            case S7Type.DWord:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.DWord;
              start = (int) address;
              return;
            case S7Type.DInt:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.DInt;
              start = (int) address;
              return;
            case S7Type.Real:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.Real;
              start = (int) address;
              return;
            case S7Type.LReal:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.LWord:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.LInt:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.DateTime:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            default:
              butter = new byte[0];
              size = butter.Length;
              s7WordLength = S7WordLength.Bit;
              start = (int) address;
              return;
          }
        case S7Area.MK:
          switch (s7Type)
          {
            case S7Type.Bit:
              butter = new byte[1];
              size = butter.Length;
              start = int.Parse(address.ToString().Split('.')[1]) + int.Parse(address.ToString().Split('.')[0]) * 8;
              s7WordLength = S7WordLength.Bit;
              return;
            case S7Type.Byte:
              butter = new byte[1];
              size = butter.Length;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.Word:
              butter = new byte[2];
              size = 1;
              s7WordLength = S7WordLength.Word;
              start = (int) address;
              return;
            case S7Type.Int:
              butter = new byte[2];
              size = 1;
              s7WordLength = S7WordLength.Int;
              start = (int) address;
              return;
            case S7Type.DWord:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.DWord;
              start = (int) address;
              return;
            case S7Type.DInt:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.DInt;
              start = (int) address;
              return;
            case S7Type.Real:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.Real;
              start = (int) address;
              return;
            case S7Type.LReal:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.LWord:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.LInt:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.DateTime:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            default:
              butter = new byte[0];
              size = butter.Length;
              s7WordLength = S7WordLength.Bit;
              start = (int) address;
              return;
          }
        default:
          switch (s7Type)
          {
            case S7Type.Bit:
              butter = new byte[1];
              size = butter.Length;
              start = int.Parse(address.ToString().Split('.')[1]) + int.Parse(address.ToString().Split('.')[0]) * 8;
              s7WordLength = S7WordLength.Bit;
              return;
            case S7Type.Byte:
              butter = new byte[1];
              size = butter.Length;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.Word:
              butter = new byte[2];
              size = 1;
              s7WordLength = S7WordLength.Word;
              start = (int) address;
              return;
            case S7Type.Int:
              butter = new byte[2];
              size = 1;
              s7WordLength = S7WordLength.Int;
              start = (int) address;
              return;
            case S7Type.DWord:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.DWord;
              start = (int) address;
              return;
            case S7Type.DInt:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.DInt;
              start = (int) address;
              return;
            case S7Type.Real:
              butter = new byte[4];
              size = 1;
              s7WordLength = S7WordLength.Real;
              start = (int) address;
              return;
            case S7Type.LReal:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.LWord:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.LInt:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            case S7Type.DateTime:
              butter = new byte[8];
              size = 8;
              s7WordLength = S7WordLength.Byte;
              start = (int) address;
              return;
            default:
              butter = new byte[0];
              size = butter.Length;
              s7WordLength = S7WordLength.Bit;
              start = (int) address;
              return;
          }
      }
    }

    public static object GetValue(byte[] butter, S7Type s7Type)
    {
      object obj;
      switch (s7Type)
      {
        case S7Type.Bit:
          obj = (object) butter.GetBitAt(0, 0);
          break;
        case S7Type.Byte:
          obj = (object) butter.GetByteAt(0);
          break;
        case S7Type.Word:
          obj = (object) butter.GetWordAt(0);
          break;
        case S7Type.Int:
          obj = (object) (short) butter.GetIntAt(0);
          break;
        case S7Type.DWord:
          obj = (object) butter.GetDWordAt(0);
          break;
        case S7Type.DInt:
          obj = (object) butter.GetDIntAt(0);
          break;
        case S7Type.Real:
          obj = (object) butter.GetRealAt(0);
          break;
        case S7Type.LReal:
          obj = (object) butter.GetLRealAt(0);
          break;
        case S7Type.LWord:
          obj = (object) butter.GetULIntAt(0);
          break;
        case S7Type.LInt:
          obj = (object) butter.GetLIntAt(0);
          break;
        case S7Type.DateTime:
          obj = (object) butter.GetDateTimeAt(0);
          break;
        default:
          obj = (object) 0;
          break;
      }
      return obj;
    }

    public static byte[] Deserialization(S7Type s7Type, object value, out bool stat)
    {
      stat = false;
      byte[] buffer;
      switch (s7Type)
      {
        case S7Type.Bit:
          buffer = new byte[1];
          if (value.ToString().Replace(" ", "").ToUpper() == "TRUE" || value.ToString().Replace(" ", "").ToUpper() == "1")
          {
            buffer[0] = (byte) 1;
            stat = true;
          }
          if (value.ToString().Replace(" ", "").ToUpper() == "FALSE" || value.ToString().Replace(" ", "").ToUpper() == "0")
          {
            buffer[0] = (byte) 0;
            stat = true;
            break;
          }
          break;
        case S7Type.Byte:
          buffer = new byte[1];
          byte result1;
          if (byte.TryParse(value.ToString().Replace(" ", ""), out result1))
          {
            buffer.SetByteAt(0, result1);
            stat = true;
            break;
          }
          break;
        case S7Type.Word:
          buffer = new byte[2];
          ushort result2;
          if (ushort.TryParse(value.ToString().Replace(" ", ""), out result2))
          {
            buffer.SetWordAt(0, result2);
            stat = true;
            break;
          }
          break;
        case S7Type.Int:
          buffer = new byte[2];
          short result3;
          if (short.TryParse(value.ToString().Replace(" ", ""), out result3))
          {
            buffer.SetIntAt(0, result3);
            stat = true;
            break;
          }
          break;
        case S7Type.DWord:
          buffer = new byte[4];
          uint result4;
          if (uint.TryParse(value.ToString().Replace(" ", ""), out result4))
          {
            buffer.SetDWordAt(0, result4);
            stat = true;
            break;
          }
          break;
        case S7Type.DInt:
          buffer = new byte[4];
          int result5;
          if (int.TryParse(value.ToString().Replace(" ", ""), out result5))
          {
            buffer.SetDIntAt(0, result5);
            stat = true;
            break;
          }
          break;
        case S7Type.Real:
          buffer = new byte[4];
          float result6;
          if (float.TryParse(value.ToString().Replace(" ", ""), out result6))
          {
            buffer.SetRealAt(0, result6);
            stat = true;
            break;
          }
          break;
        case S7Type.LReal:
          buffer = new byte[8];
          double result7;
          if (double.TryParse(value.ToString().Replace(" ", ""), out result7))
          {
            buffer.SetLRealAt(0, result7);
            stat = true;
            break;
          }
          break;
        case S7Type.LWord:
          buffer = new byte[8];
          ulong result8;
          if (ulong.TryParse(value.ToString().Replace(" ", ""), out result8))
          {
            buffer.SetLWordAt(0, result8);
            stat = true;
          }
          buffer.SetLWordAt(0, Convert.ToUInt64(value));
          break;
        case S7Type.LInt:
          buffer = new byte[8];
          long result9;
          if (long.TryParse(value.ToString().Replace(" ", ""), out result9))
          {
            buffer.SetLIntAt(0, result9);
            stat = true;
            break;
          }
          break;
        default:
          buffer = new byte[8];
          DateTime result10;
          if (DateTime.TryParse(value.ToString().Replace(" ", ""), out result10))
          {
            buffer.SetDateTimeAt(0, result10);
            stat = true;
            break;
          }
          break;
      }
      return buffer;
    }
  }
}
