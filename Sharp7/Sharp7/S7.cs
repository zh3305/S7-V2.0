// Decompiled with JetBrains decompiler
// Type: Sharp7.S7
// Assembly: Sharp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 02CEF60A-46C4-41DA-9A48-13BCB115154D
// Assembly location: D:\Desktop\Sharp7\S7小助手V2.0\bin\Debug\Sharp7.dll

using System;
using System.Collections.Generic;
using System.Text;

namespace Sharp7
{
  public static class S7
  {
    private static long bias = 621355968000000000;

    private static int BCDtoByte(byte B) => ((int) B >> 4) * 10 + ((int) B & 15);

    private static byte ByteToBCD(int value) => (byte) (value / 10 << 4 | value % 10);

    public static int DataSizeByte(this int wordLength)
    {
      switch (wordLength)
      {
        case 1:
          return 1;
        case 2:
          return 1;
        case 3:
          return 1;
        case 4:
          return 2;
        case 5:
          return 2;
        case 6:
          return 4;
        case 7:
          return 4;
        case 8:
          return 4;
        case 28:
          return 2;
        case 29:
          return 2;
        default:
          return 0;
      }
    }

    public static bool GetBitAt(this byte[] buffer, int pos, int bit)
    {
      byte[] numArray = new byte[8]
      {
        (byte) 1,
        (byte) 2,
        (byte) 4,
        (byte) 8,
        (byte) 16,
        (byte) 32,
        (byte) 64,
        (byte) 128
      };
      if (bit < 0)
        bit = 0;
      if (bit > 7)
        bit = 7;
      return ((uint) buffer[pos] & (uint) numArray[bit]) > 0U;
    }

    [Obsolete("Use SetBitAt as extension method")]
    public static void SetBitAt(ref byte[] buffer, int pos, int bit, bool value) => buffer.SetBitAt(pos, bit, value);

    public static void SetBitAt(this byte[] buffer, int pos, int bit, bool value)
    {
      byte[] numArray = new byte[8]
      {
        (byte) 1,
        (byte) 2,
        (byte) 4,
        (byte) 8,
        (byte) 16,
        (byte) 32,
        (byte) 64,
        (byte) 128
      };
      if (bit < 0)
        bit = 0;
      if (bit > 7)
        bit = 7;
      if (value)
        buffer[pos] = (byte) ((uint) buffer[pos] | (uint) numArray[bit]);
      else
        buffer[pos] = (byte) ((uint) buffer[pos] & (uint) ~numArray[bit]);
    }

    public static int GetSIntAt(this byte[] buffer, int pos)
    {
      int num = (int) buffer[pos];
      return num < 128 ? num : num - 256;
    }

    public static void SetSIntAt(this byte[] buffer, int pos, int value)
    {
      if (value < (int) sbyte.MinValue)
        value = (int) sbyte.MinValue;
      if (value > (int) sbyte.MaxValue)
        value = (int) sbyte.MaxValue;
      buffer[pos] = (byte) value;
    }

    public static int GetIntAt(this byte[] buffer, int pos) => (int) buffer[pos] << 8 | (int) buffer[pos + 1];

    public static void SetIntAt(this byte[] buffer, int pos, short value)
    {
      buffer[pos] = (byte) ((uint) value >> 8);
      buffer[pos + 1] = (byte) ((uint) value & (uint) byte.MaxValue);
    }

    public static int GetDIntAt(this byte[] buffer, int pos) => ((((int) buffer[pos] << 8) + (int) buffer[pos + 1] << 8) + (int) buffer[pos + 2] << 8) + (int) buffer[pos + 3];

    public static void SetDIntAt(this byte[] buffer, int pos, int value)
    {
      buffer[pos + 3] = (byte) (value & (int) byte.MaxValue);
      buffer[pos + 2] = (byte) (value >> 8 & (int) byte.MaxValue);
      buffer[pos + 1] = (byte) (value >> 16 & (int) byte.MaxValue);
      buffer[pos] = (byte) (value >> 24 & (int) byte.MaxValue);
    }

    public static long GetLIntAt(this byte[] buffer, int pos) => ((((((((long) buffer[pos] << 8) + (long) buffer[pos + 1] << 8) + (long) buffer[pos + 2] << 8) + (long) buffer[pos + 3] << 8) + (long) buffer[pos + 4] << 8) + (long) buffer[pos + 5] << 8) + (long) buffer[pos + 6] << 8) + (long) buffer[pos + 7];

    public static void SetLIntAt(this byte[] buffer, int pos, long value)
    {
      buffer[pos + 7] = (byte) ((ulong) value & (ulong) byte.MaxValue);
      buffer[pos + 6] = (byte) ((ulong) (value >> 8) & (ulong) byte.MaxValue);
      buffer[pos + 5] = (byte) ((ulong) (value >> 16) & (ulong) byte.MaxValue);
      buffer[pos + 4] = (byte) ((ulong) (value >> 24) & (ulong) byte.MaxValue);
      buffer[pos + 3] = (byte) ((ulong) (value >> 32) & (ulong) byte.MaxValue);
      buffer[pos + 2] = (byte) ((ulong) (value >> 40) & (ulong) byte.MaxValue);
      buffer[pos + 1] = (byte) ((ulong) (value >> 48) & (ulong) byte.MaxValue);
      buffer[pos] = (byte) ((ulong) (value >> 56) & (ulong) byte.MaxValue);
    }

    public static byte GetUSIntAt(this byte[] buffer, int pos) => buffer[pos];

    public static void SetUSIntAt(this byte[] buffer, int pos, byte value) => buffer[pos] = value;

    public static ushort GetUIntAt(this byte[] buffer, int pos) => (ushort) ((uint) buffer[pos] << 8 | (uint) buffer[pos + 1]);

    public static void SetUIntAt(this byte[] buffer, int pos, ushort value)
    {
      buffer[pos] = (byte) ((uint) value >> 8);
      buffer[pos + 1] = (byte) ((uint) value & (uint) byte.MaxValue);
    }

    public static uint GetUDIntAt(this byte[] buffer, int pos) => (((uint) buffer[pos] << 8 | (uint) buffer[pos + 1]) << 8 | (uint) buffer[pos + 2]) << 8 | (uint) buffer[pos + 3];

    public static void SetUDIntAt(this byte[] buffer, int pos, uint value)
    {
      buffer[pos + 3] = (byte) (value & (uint) byte.MaxValue);
      buffer[pos + 2] = (byte) (value >> 8 & (uint) byte.MaxValue);
      buffer[pos + 1] = (byte) (value >> 16 & (uint) byte.MaxValue);
      buffer[pos] = (byte) (value >> 24 & (uint) byte.MaxValue);
    }

    public static ulong GetULIntAt(this byte[] buffer, int pos) => (((((((ulong) buffer[pos] << 8 | (ulong) buffer[pos + 1]) << 8 | (ulong) buffer[pos + 2]) << 8 | (ulong) buffer[pos + 3]) << 8 | (ulong) buffer[pos + 4]) << 8 | (ulong) buffer[pos + 5]) << 8 | (ulong) buffer[pos + 6]) << 8 | (ulong) buffer[pos + 7];

    public static void SetULintAt(this byte[] buffer, int pos, ulong value)
    {
      buffer[pos + 7] = (byte) (value & (ulong) byte.MaxValue);
      buffer[pos + 6] = (byte) (value >> 8 & (ulong) byte.MaxValue);
      buffer[pos + 5] = (byte) (value >> 16 & (ulong) byte.MaxValue);
      buffer[pos + 4] = (byte) (value >> 24 & (ulong) byte.MaxValue);
      buffer[pos + 3] = (byte) (value >> 32 & (ulong) byte.MaxValue);
      buffer[pos + 2] = (byte) (value >> 40 & (ulong) byte.MaxValue);
      buffer[pos + 1] = (byte) (value >> 48 & (ulong) byte.MaxValue);
      buffer[pos] = (byte) (value >> 56 & (ulong) byte.MaxValue);
    }


    public static void SetByteAt(this byte[] buffer, int pos, byte value) => buffer[pos] = value;

    public static ushort GetWordAt(this byte[] buffer, int pos) => buffer.GetUIntAt(pos);

    public static void SetWordAt(this byte[] buffer, int pos, ushort value) => buffer.SetUIntAt(pos, value);

    public static uint GetDWordAt(this byte[] buffer, int pos) => buffer.GetUDIntAt(pos);

    public static void SetDWordAt(this byte[] buffer, int pos, uint value) => buffer.SetUDIntAt(pos, value);

    public static ulong GetLWordAt(this byte[] buffer, int pos) => buffer.GetULIntAt(pos);

    public static void SetLWordAt(this byte[] buffer, int pos, ulong value) => buffer.SetULintAt(pos, value);

    public static float GetRealAt(this byte[] buffer, int pos) => BitConverter.ToSingle(BitConverter.GetBytes(buffer.GetUDIntAt(pos)), 0);

    public static void SetRealAt(this byte[] buffer, int pos, float value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      buffer[pos] = bytes[3];
      buffer[pos + 1] = bytes[2];
      buffer[pos + 2] = bytes[1];
      buffer[pos + 3] = bytes[0];
    }

    public static double GetLRealAt(this byte[] buffer, int pos) => BitConverter.ToDouble(BitConverter.GetBytes(buffer.GetULIntAt(pos)), 0);

    public static void SetLRealAt(this byte[] buffer, int pos, double value)
    {
      byte[] bytes = BitConverter.GetBytes(value);
      buffer[pos] = bytes[7];
      buffer[pos + 1] = bytes[6];
      buffer[pos + 2] = bytes[5];
      buffer[pos + 3] = bytes[4];
      buffer[pos + 4] = bytes[3];
      buffer[pos + 5] = bytes[2];
      buffer[pos + 6] = bytes[1];
      buffer[pos + 7] = bytes[0];
    }

    public static DateTime GetDateTimeAt(this byte[] buffer, int pos)
    {
      int num = S7.BCDtoByte(buffer[pos]);
      int year = num >= 90 ? num + 1900 : num + 2000;
      int month = S7.BCDtoByte(buffer[pos + 1]);
      int day = S7.BCDtoByte(buffer[pos + 2]);
      int hour = S7.BCDtoByte(buffer[pos + 3]);
      int minute = S7.BCDtoByte(buffer[pos + 4]);
      int second = S7.BCDtoByte(buffer[pos + 5]);
      int millisecond = S7.BCDtoByte(buffer[pos + 6]) * 10 + S7.BCDtoByte(buffer[pos + 7]) / 10;
      try
      {
        return new DateTime(year, month, day, hour, minute, second, millisecond);
      }
      catch (ArgumentOutOfRangeException ex)
      {
        return new DateTime(0L);
      }
    }

    public static void SetDateTimeAt(this byte[] buffer, int pos, DateTime value)
    {
      int year = value.Year;
      int month = value.Month;
      int day = value.Day;
      int hour = value.Hour;
      int minute = value.Minute;
      int second = value.Second;
      int num1 = (int) (value.DayOfWeek + 1);
      int num2 = value.Millisecond / 10;
      int num3 = value.Millisecond % 10;
      if (year > 1999)
        year -= 2000;
      buffer[pos] = S7.ByteToBCD(year);
      buffer[pos + 1] = S7.ByteToBCD(month);
      buffer[pos + 2] = S7.ByteToBCD(day);
      buffer[pos + 3] = S7.ByteToBCD(hour);
      buffer[pos + 4] = S7.ByteToBCD(minute);
      buffer[pos + 5] = S7.ByteToBCD(second);
      buffer[pos + 6] = S7.ByteToBCD(num2);
      buffer[pos + 7] = S7.ByteToBCD(num3 * 10 + num1);
    }

    public static DateTime GetDateAt(this byte[] buffer, int pos)
    {
      try
      {
        return new DateTime(1990, 1, 1).AddDays((double) buffer.GetIntAt(pos));
      }
      catch (ArgumentOutOfRangeException ex)
      {
        return new DateTime(0L);
      }
    }

    public static void SetDateAt(this byte[] buffer, int pos, DateTime value) => buffer.SetIntAt(pos, (short) (value - new DateTime(1990, 1, 1)).Days);

    [Obsolete("Use GetTODAsDateTimeAt or GetTODAsTimeSpanAt instead")]
    public static DateTime GetTODAt(this byte[] buffer, int pos) => buffer.GetTODAsDateTimeAt(pos);

    public static DateTime GetTODAsDateTimeAt(this byte[] buffer, int pos)
    {
      try
      {
        return new DateTime(0L).AddMilliseconds((double) buffer.GetDIntAt(pos));
      }
      catch (ArgumentOutOfRangeException ex)
      {
        return new DateTime(0L);
      }
    }

    public static void SetTODAt(this byte[] buffer, int pos, DateTime value)
    {
      TimeSpan timeOfDay = value.TimeOfDay;
      buffer.SetDIntAt(pos, (int) Math.Round(timeOfDay.TotalMilliseconds));
    }

    public static TimeSpan GetTODAsTimeSpanAt(this byte[] buffer, int pos)
    {
      try
      {
        return TimeSpan.FromMilliseconds((double) buffer.GetDIntAt(pos));
      }
      catch (ArgumentOutOfRangeException ex)
      {
        return TimeSpan.Zero;
      }
    }

    public static void SetTODAt(this byte[] buffer, int pos, TimeSpan value) => buffer.SetDIntAt(pos, (int) Math.Round(value.TotalMilliseconds));

    [Obsolete("Use GetLTODAsDateTimeAt or GetLTODAsTimeSpanAt instead")]
    public static DateTime GetLTODAt(this byte[] buffer, int pos) => buffer.GetLTODAsDateTimeAt(pos);

    public static DateTime GetLTODAsDateTimeAt(this byte[] buffer, int pos)
    {
      try
      {
        return new DateTime(Math.Abs(buffer.GetLIntAt(pos) / 100L));
      }
      catch (ArgumentOutOfRangeException ex)
      {
        return new DateTime(0L);
      }
    }

    public static void SetLTODAt(this byte[] buffer, int pos, DateTime value)
    {
      TimeSpan timeOfDay = value.TimeOfDay;
      buffer.SetLIntAt(pos, timeOfDay.Ticks * 100L);
    }

    public static TimeSpan GetLTODAsTimeSpanAt(this byte[] buffer, int pos)
    {
      try
      {
        return TimeSpan.FromTicks(Math.Abs(buffer.GetLIntAt(pos) / 100L));
      }
      catch (ArgumentOutOfRangeException ex)
      {
        return TimeSpan.Zero;
      }
    }

    public static void SetLTODAt(this byte[] buffer, int pos, TimeSpan value) => buffer.SetLIntAt(pos, value.Ticks * 100L);

    public static DateTime GetLDTAt(this byte[] buffer, int pos)
    {
      try
      {
        return new DateTime(buffer.GetLIntAt(pos) / 100L + S7.bias);
      }
      catch (ArgumentOutOfRangeException ex)
      {
        return new DateTime(0L);
      }
    }

    public static void SetLDTAt(this byte[] buffer, int pos, DateTime value) => buffer.SetLIntAt(pos, (value.Ticks - S7.bias) * 100L);

    public static DateTime GetDTLAt(this byte[] buffer, int pos)
    {
      int year = (int) buffer[pos] * 256 + (int) buffer[pos + 1];
      int month = (int) buffer[pos + 2];
      int day = (int) buffer[pos + 3];
      int hour = (int) buffer[pos + 5];
      int minute = (int) buffer[pos + 6];
      int second = (int) buffer[pos + 7];
      int millisecond = (int) buffer.GetUDIntAt(pos + 8) / 1000000;
      try
      {
        return new DateTime(year, month, day, hour, minute, second, millisecond);
      }
      catch (ArgumentOutOfRangeException ex)
      {
        return new DateTime(0L);
      }
    }

    public static void SetDTLAt(this byte[] buffer, int pos, DateTime value)
    {
      short year = (short) value.Year;
      byte month = (byte) value.Month;
      byte day = (byte) value.Day;
      byte hour = (byte) value.Hour;
      byte minute = (byte) value.Minute;
      byte second = (byte) value.Second;
      byte num1 = (byte) (value.DayOfWeek + 1);
      int num2 = value.Millisecond * 1000000;
      byte[] bytes = BitConverter.GetBytes(year);
      buffer[pos] = bytes[1];
      buffer[pos + 1] = bytes[0];
      buffer[pos + 2] = month;
      buffer[pos + 3] = day;
      buffer[pos + 4] = num1;
      buffer[pos + 5] = hour;
      buffer[pos + 6] = minute;
      buffer[pos + 7] = second;
      buffer.SetDIntAt(pos + 8, num2);
    }

    public static string GetStringAt(this byte[] buffer, int pos)
    {
      int count = (int) buffer[pos + 1];
      return Encoding.UTF8.GetString(buffer, pos + 2, count);
    }

    public static string GetString(this byte[] buffer, int pos) => Encoding.GetEncoding("GBK").GetString(buffer, pos, 254);

    public static byte[] WriteString(string String)
    {
      byte[] destinationArray = new byte[Encoding.GetEncoding("GBK").GetBytes(String).Length + 2];
      Array.ConstrainedCopy((Array) Encoding.GetEncoding("GBK").GetBytes(String), 0, (Array) destinationArray, 2, destinationArray.Length - 2);
      destinationArray[0] = (byte) 254;
      destinationArray[1] = (byte) (destinationArray.Length - 2);
      return destinationArray;
    }

    public static void SetStringAt(this byte[] buffer, int pos, int MaxLen, string value)
    {
      int length = value.Length;
      buffer[pos] = (byte) MaxLen;
      buffer[pos + 1] = (byte) length;
      Encoding.UTF8.GetBytes(value, 0, length, buffer, pos + 2);
    }

    public static string GetCharsAt(this byte[] buffer, int pos, int Size) => Encoding.UTF8.GetString(buffer, pos, Size);

    public static void SetCharsAt(this byte[] buffer, int pos, string value)
    {
      int charCount = buffer.Length - pos;
      if (charCount > value.Length)
        charCount = value.Length;
      Encoding.UTF8.GetBytes(value, 0, charCount, buffer, pos);
    }

    public static int GetCounter(this ushort value) => S7.BCDtoByte((byte) value) * 100 + S7.BCDtoByte((byte) ((uint) value >> 8));

    public static int GetCounterAt(this ushort[] buffer, int Index) => buffer[Index].GetCounter();

    public static ushort ToCounter(this int value) => (ushort) ((uint) S7.ByteToBCD(value / 100) + ((uint) S7.ByteToBCD(value % 100) << 8));

    public static void SetCounterAt(this ushort[] buffer, int pos, int value) => buffer[pos] = value.ToCounter();

    public static S7Timer GetS7TimerAt(this byte[] buffer, int pos) => new S7Timer(new List<byte>((IEnumerable<byte>) buffer).GetRange(pos, 12).ToArray());

    public static void SetS7TimespanAt(this byte[] buffer, int pos, TimeSpan value) => buffer.SetDIntAt(pos, (int) value.TotalMilliseconds);

    public static TimeSpan GetS7TimespanAt(this byte[] buffer, int pos) => buffer.Length < pos + 4 ? new TimeSpan() : new TimeSpan(0, 0, 0, 0, ((((int) buffer[pos] << 8) + (int) buffer[pos + 1] << 8) + (int) buffer[pos + 2] << 8) + (int) buffer[pos + 3]);
  }
}
