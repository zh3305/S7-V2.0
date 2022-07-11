// Decompiled with JetBrains decompiler
// Type: Sharp7.S7MultiVar
// Assembly: Sharp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 02CEF60A-46C4-41DA-9A48-13BCB115154D
// Assembly location: D:\Desktop\Sharp7\S7小助手V2.0\bin\Debug\Sharp7.dll

using System;
using System.Runtime.InteropServices;

namespace Sharp7
{
  public class S7MultiVar
  {
    private S7Client FClient;
    private GCHandle[] Handles = new GCHandle[S7Client.MaxVars];
    private int Count;
    private S7Client.S7DataItem[] Items = new S7Client.S7DataItem[S7Client.MaxVars];

    public int[] Results { get; } = new int[S7Client.MaxVars];

    private bool AdjustWordLength(int Area, ref int WordLen, ref int Amount, ref int Start)
    {
      int num = WordLen.DataSizeByte();
      if (num == 0)
        return false;
      if (Area == 28)
        WordLen = 28;
      if (Area == 29)
        WordLen = 29;
      if (WordLen == 1)
        Amount = 1;
      else if (WordLen != 28 && WordLen != 29)
      {
        Amount *= num;
        Start *= 8;
        WordLen = 2;
      }
      return true;
    }

    public S7MultiVar(S7Client Client)
    {
      this.FClient = Client;
      for (int index = 0; index < S7Client.MaxVars; ++index)
        this.Results[index] = 12582912;
    }

    ~S7MultiVar() => this.Clear();

    public bool Add<T>(S7Consts.S7Tag Tag, ref T[] Buffer, int Offset) => this.Add<T>(Tag.Area, Tag.WordLen, Tag.DBNumber, Tag.Start, Tag.Elements, ref Buffer, Offset);

    public bool Add<T>(S7Consts.S7Tag Tag, ref T[] Buffer) => this.Add<T>(Tag.Area, Tag.WordLen, Tag.DBNumber, Tag.Start, Tag.Elements, ref Buffer);

    public bool Add<T>(
      int Area,
      int WordLen,
      int DBNumber,
      int Start,
      int Amount,
      ref T[] Buffer)
    {
      return this.Add<T>(Area, WordLen, DBNumber, Start, Amount, ref Buffer, 0);
    }

    public bool Add<T>(
      int Area,
      int WordLen,
      int DBNumber,
      int Start,
      int Amount,
      ref T[] Buffer,
      int Offset)
    {
      if (this.Count >= S7Client.MaxVars || !this.AdjustWordLength(Area, ref WordLen, ref Amount, ref Start))
        return false;
      this.Items[this.Count].Area = Area;
      this.Items[this.Count].WordLen = WordLen;
      this.Items[this.Count].Result = 12582912;
      this.Items[this.Count].DBNumber = DBNumber;
      this.Items[this.Count].Start = Start;
      this.Items[this.Count].Amount = Amount;
      GCHandle gcHandle = GCHandle.Alloc((object) Buffer, GCHandleType.Pinned);
      this.Items[this.Count].pData = IntPtr.Size != 4 ? (IntPtr) (gcHandle.AddrOfPinnedObject().ToInt64() + (long) (Offset * Marshal.SizeOf(typeof (T)))) : (IntPtr) (gcHandle.AddrOfPinnedObject().ToInt32() + Offset * Marshal.SizeOf(typeof (T)));
      this.Handles[this.Count] = gcHandle;
      ++this.Count;
      return true;
    }

    public int Read()
    {
      int num1;
      try
      {
        if (this.Count > 0)
        {
          int num2 = this.FClient.ReadMultiVars(this.Items, this.Count);
          if (num2 == 0)
          {
            for (int index = 0; index < S7Client.MaxVars; ++index)
              this.Results[index] = this.Items[index].Result;
          }
          num1 = num2;
        }
        else
          num1 = 36700160;
      }
      finally
      {
        this.Clear();
      }
      return num1;
    }

    public int Write()
    {
      int num1;
      try
      {
        if (this.Count > 0)
        {
          int num2 = this.FClient.WriteMultiVars(this.Items, this.Count);
          if (num2 == 0)
          {
            for (int index = 0; index < S7Client.MaxVars; ++index)
              this.Results[index] = this.Items[index].Result;
          }
          num1 = num2;
        }
        else
          num1 = 36700160;
      }
      finally
      {
        this.Clear();
      }
      return num1;
    }

    public void Clear()
    {
      for (int index = 0; index < this.Count; ++index)
      {
        ref GCHandle local = ref this.Handles[index];
        if (true)
          this.Handles[index].Free();
      }
      this.Count = 0;
    }
  }
}
