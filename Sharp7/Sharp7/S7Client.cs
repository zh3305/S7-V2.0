// Decompiled with JetBrains decompiler
// Type: Sharp7.S7Client
// Assembly: Sharp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 02CEF60A-46C4-41DA-9A48-13BCB115154D
// Assembly location: D:\Desktop\Sharp7\S7小助手V2.0\bin\Debug\Sharp7.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;


// #nullable enable
namespace Sharp7
{
  public class S7Client
  {
    public const int Block_OB = 56;
    public const int Block_DB = 65;
    public const int Block_SDB = 66;
    public const int Block_FC = 67;
    public const int Block_SFC = 68;
    public const int Block_FB = 69;
    public const int Block_SFB = 70;
    public const byte SubBlk_OB = 8;
    public const byte SubBlk_DB = 10;
    public const byte SubBlk_SDB = 11;
    public const byte SubBlk_FC = 12;
    public const byte SubBlk_SFC = 13;
    public const byte SubBlk_FB = 14;
    public const byte SubBlk_SFB = 15;
    public const byte BlockLangAWL = 1;
    public const byte BlockLangKOP = 2;
    public const byte BlockLangFUP = 3;
    public const byte BlockLangSCL = 4;
    public const byte BlockLangDB = 5;
    public const byte BlockLangGRAPH = 6;
    public static readonly int MaxVars = 20;
    private const byte TS_ResBit = 3;
    private const byte TS_ResByte = 4;
    private const byte TS_ResInt = 5;
    private const byte TS_ResReal = 7;
    private const byte TS_ResOctet = 9;
    private const ushort Code7Ok = 0;
    private const ushort Code7AddressOutOfRange = 5;
    private const ushort Code7InvalidTransportSize = 6;
    private const ushort Code7WriteDataSizeMismatch = 7;
    private const ushort Code7ResItemNotAvailable = 10;
    private const ushort Code7ResItemNotAvailable1 = 53769;
    private const ushort Code7InvalidValue = 56321;
    private const ushort Code7NeedPassword = 53825;
    private const ushort Code7InvalidPassword = 54786;
    private const ushort Code7NoPasswordToClear = 54788;
    private const ushort Code7NoPasswordToSet = 54789;
    private const ushort Code7FunNotAvailable = 33028;
    private const ushort Code7DataOverPDU = 34048;
    public static readonly ushort CONNTYPE_PG = 1;
    public static readonly ushort CONNTYPE_OP = 2;
    public static readonly ushort CONNTYPE_BASIC = 3;
    public int _LastError = 0;
    private 
    // #nullable disable
    byte[] ISO_CR = new byte[22]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 22,
      (byte) 17,
      (byte) 224,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 192,
      (byte) 1,
      (byte) 10,
      (byte) 193,
      (byte) 2,
      (byte) 1,
      (byte) 0,
      (byte) 194,
      (byte) 2,
      (byte) 1,
      (byte) 2
    };
    private byte[] TPKT_ISO = new byte[7]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 31,
      (byte) 2,
      (byte) 240,
      (byte) 128
    };
    private byte[] S7_PN = new byte[25]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 25,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 4,
      (byte) 0,
      (byte) 0,
      (byte) 8,
      (byte) 0,
      (byte) 0,
      (byte) 240,
      (byte) 0,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 30
    };
    private byte[] S7_RW = new byte[35]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 31,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 5,
      (byte) 0,
      (byte) 0,
      (byte) 14,
      (byte) 0,
      (byte) 0,
      (byte) 4,
      (byte) 1,
      (byte) 18,
      (byte) 10,
      (byte) 16,
      (byte) 2,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 132,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 4,
      (byte) 0,
      (byte) 0
    };
    private static int Size_RD = 31;
    private static int Size_WR = 35;
    private byte[] S7_MRD_HEADER = new byte[19]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 31,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 5,
      (byte) 0,
      (byte) 0,
      (byte) 14,
      (byte) 0,
      (byte) 0,
      (byte) 4,
      (byte) 1
    };
    private byte[] S7_MRD_ITEM = new byte[12]
    {
      (byte) 18,
      (byte) 10,
      (byte) 16,
      (byte) 2,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 132,
      (byte) 0,
      (byte) 0,
      (byte) 0
    };
    private byte[] S7_MWR_HEADER = new byte[19]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 31,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 5,
      (byte) 0,
      (byte) 0,
      (byte) 14,
      (byte) 0,
      (byte) 0,
      (byte) 5,
      (byte) 1
    };
    private byte[] S7_MWR_PARAM = new byte[12]
    {
      (byte) 18,
      (byte) 10,
      (byte) 16,
      (byte) 2,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 132,
      (byte) 0,
      (byte) 0,
      (byte) 0
    };
    private byte[] S7_SZL_FIRST = new byte[33]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 33,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 7,
      (byte) 0,
      (byte) 0,
      (byte) 5,
      (byte) 0,
      (byte) 0,
      (byte) 8,
      (byte) 0,
      (byte) 8,
      (byte) 0,
      (byte) 1,
      (byte) 18,
      (byte) 4,
      (byte) 17,
      (byte) 68,
      (byte) 1,
      (byte) 0,
      byte.MaxValue,
      (byte) 9,
      (byte) 0,
      (byte) 4,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
    };
    private byte[] S7_SZL_NEXT = new byte[33]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 33,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 7,
      (byte) 0,
      (byte) 0,
      (byte) 6,
      (byte) 0,
      (byte) 0,
      (byte) 12,
      (byte) 0,
      (byte) 4,
      (byte) 0,
      (byte) 1,
      (byte) 18,
      (byte) 8,
      (byte) 18,
      (byte) 68,
      (byte) 1,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 10,
      (byte) 0,
      (byte) 0,
      (byte) 0
    };
    private byte[] S7_GET_DT = new byte[29]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 29,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 7,
      (byte) 0,
      (byte) 0,
      (byte) 56,
      (byte) 0,
      (byte) 0,
      (byte) 8,
      (byte) 0,
      (byte) 4,
      (byte) 0,
      (byte) 1,
      (byte) 18,
      (byte) 4,
      (byte) 17,
      (byte) 71,
      (byte) 1,
      (byte) 0,
      (byte) 10,
      (byte) 0,
      (byte) 0,
      (byte) 0
    };
    private byte[] S7_SET_DT = new byte[39]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 39,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 7,
      (byte) 0,
      (byte) 0,
      (byte) 137,
      (byte) 3,
      (byte) 0,
      (byte) 8,
      (byte) 0,
      (byte) 14,
      (byte) 0,
      (byte) 1,
      (byte) 18,
      (byte) 4,
      (byte) 17,
      (byte) 71,
      (byte) 2,
      (byte) 0,
      byte.MaxValue,
      (byte) 9,
      (byte) 0,
      (byte) 10,
      (byte) 0,
      (byte) 25,
      (byte) 19,
      (byte) 18,
      (byte) 6,
      (byte) 23,
      (byte) 55,
      (byte) 19,
      (byte) 0,
      (byte) 1
    };
    private byte[] S7_SET_PWD = new byte[37]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 37,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 7,
      (byte) 0,
      (byte) 0,
      (byte) 39,
      (byte) 0,
      (byte) 0,
      (byte) 8,
      (byte) 0,
      (byte) 12,
      (byte) 0,
      (byte) 1,
      (byte) 18,
      (byte) 4,
      (byte) 17,
      (byte) 69,
      (byte) 1,
      (byte) 0,
      byte.MaxValue,
      (byte) 9,
      (byte) 0,
      (byte) 8,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
    };
    private byte[] S7_CLR_PWD = new byte[29]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 29,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 7,
      (byte) 0,
      (byte) 0,
      (byte) 41,
      (byte) 0,
      (byte) 0,
      (byte) 8,
      (byte) 0,
      (byte) 4,
      (byte) 0,
      (byte) 1,
      (byte) 18,
      (byte) 4,
      (byte) 17,
      (byte) 69,
      (byte) 2,
      (byte) 0,
      (byte) 10,
      (byte) 0,
      (byte) 0,
      (byte) 0
    };
    private byte[] S7_STOP = new byte[33]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 33,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 14,
      (byte) 0,
      (byte) 0,
      (byte) 16,
      (byte) 0,
      (byte) 0,
      (byte) 41,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 9,
      (byte) 80,
      (byte) 95,
      (byte) 80,
      (byte) 82,
      (byte) 79,
      (byte) 71,
      (byte) 82,
      (byte) 65,
      (byte) 77
    };
    private byte[] S7_HOT_START = new byte[37]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 37,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 12,
      (byte) 0,
      (byte) 0,
      (byte) 20,
      (byte) 0,
      (byte) 0,
      (byte) 40,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 253,
      (byte) 0,
      (byte) 0,
      (byte) 9,
      (byte) 80,
      (byte) 95,
      (byte) 80,
      (byte) 82,
      (byte) 79,
      (byte) 71,
      (byte) 82,
      (byte) 65,
      (byte) 77
    };
    private byte[] S7_COLD_START = new byte[39]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 39,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 15,
      (byte) 0,
      (byte) 0,
      (byte) 22,
      (byte) 0,
      (byte) 0,
      (byte) 40,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 253,
      (byte) 0,
      (byte) 2,
      (byte) 67,
      (byte) 32,
      (byte) 9,
      (byte) 80,
      (byte) 95,
      (byte) 80,
      (byte) 82,
      (byte) 79,
      (byte) 71,
      (byte) 82,
      (byte) 65,
      (byte) 77
    };
    private const byte pduStart = 40;
    private const byte pduStop = 41;
    private const byte pduAlreadyStarted = 2;
    private const byte pduAlreadyStopped = 7;
    private byte[] S7_GET_STAT = new byte[33]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 33,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 7,
      (byte) 0,
      (byte) 0,
      (byte) 44,
      (byte) 0,
      (byte) 0,
      (byte) 8,
      (byte) 0,
      (byte) 8,
      (byte) 0,
      (byte) 1,
      (byte) 18,
      (byte) 4,
      (byte) 17,
      (byte) 68,
      (byte) 1,
      (byte) 0,
      byte.MaxValue,
      (byte) 9,
      (byte) 0,
      (byte) 4,
      (byte) 4,
      (byte) 36,
      (byte) 0,
      (byte) 0
    };
    private byte[] S7_BI = new byte[37]
    {
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 37,
      (byte) 2,
      (byte) 240,
      (byte) 128,
      (byte) 50,
      (byte) 7,
      (byte) 0,
      (byte) 0,
      (byte) 5,
      (byte) 0,
      (byte) 0,
      (byte) 8,
      (byte) 0,
      (byte) 12,
      (byte) 0,
      (byte) 1,
      (byte) 18,
      (byte) 4,
      (byte) 17,
      (byte) 67,
      (byte) 3,
      (byte) 0,
      byte.MaxValue,
      (byte) 9,
      (byte) 0,
      (byte) 8,
      (byte) 48,
      (byte) 65,
      (byte) 48,
      (byte) 48,
      (byte) 48,
      (byte) 48,
      (byte) 48,
      (byte) 65
    };
    private static int ISOTCP = 102;
    private static int MinPduSize = 16;
    private static int MinPduSizeToRequest = 240;
    private static int MaxPduSizeToRequest = 960;
    private static int DefaultTimeout = 2000;
    private static int IsoHSize = 7;
    private int _PDULength = 0;
    private int _PduSizeRequested = 480;
    private int _PLCPort = S7Client.ISOTCP;
    private string IPAddress;
    private byte LocalTSAP_HI;
    private byte LocalTSAP_LO;
    private byte RemoteTSAP_HI;
    private byte RemoteTSAP_LO;
    private byte LastPDUType;
    private ushort ConnType = S7Client.CONNTYPE_PG;
    private byte[] PDU = new byte[2048];
    private MsgSocket Socket = (MsgSocket) null;
    private int Time_ms = 0;
    private Dictionary<string, Sharp7.List> _list = new Dictionary<string, Sharp7.List>();
    private Dictionary<string, Sharp7.Tag> _tag = new Dictionary<string, Sharp7.Tag>();
    private Dictionary<string, Sharp7.Package> _package = new Dictionary<string, Sharp7.Package>();

    private void CreateSocket()
    {
      this.Socket = new MsgSocket();
      this.Socket.ConnectTimeout = S7Client.DefaultTimeout;
      this.Socket.ReadTimeout = S7Client.DefaultTimeout;
      this.Socket.WriteTimeout = S7Client.DefaultTimeout;
    }

    private int TCPConnect()
    {
      if (this._LastError == 0)
      {
        try
        {
          this._LastError = this.Socket.Connect(this.IPAddress, this._PLCPort);
        }
        catch
        {
          this._LastError = 3;
        }
      }
      return this._LastError;
    }

    private void RecvPacket(byte[] Buffer, int Start, int Size)
    {
      if (this.Connected)
        this._LastError = this.Socket.Receive(Buffer, Start, Size);
      else
        this._LastError = 9;
    }

    private void SendPacket(byte[] Buffer, int Len)
    {
      if (this.Connected)
        this._LastError = this.Socket.Send(Buffer, Len);
      else
        this._LastError = 9;
    }

    private void SendPacket(byte[] Buffer) => this.SendPacket(Buffer, Buffer.Length);

    private int RecvIsoPacket()
    {
      bool flag = false;
      int num = 0;
      while (this._LastError == 0 && !flag)
      {
        this.RecvPacket(this.PDU, 0, 4);
        if (this._LastError == 0)
        {
          num = (int) this.PDU.GetWordAt(2);
          if (num == S7Client.IsoHSize)
            this.RecvPacket(this.PDU, 4, 3);
          else if (num > this._PduSizeRequested + S7Client.IsoHSize || num < S7Client.MinPduSize)
            this._LastError = 196608;
          else
            flag = true;
        }
      }
      if (this._LastError == 0)
      {
        this.RecvPacket(this.PDU, 4, 3);
        this.LastPDUType = this.PDU[5];
        this.RecvPacket(this.PDU, 7, num - S7Client.IsoHSize);
      }
      return this._LastError == 0 ? num : 0;
    }

    private int ISOConnect()
    {
      this.ISO_CR[16] = this.LocalTSAP_HI;
      this.ISO_CR[17] = this.LocalTSAP_LO;
      this.ISO_CR[20] = this.RemoteTSAP_HI;
      this.ISO_CR[21] = this.RemoteTSAP_LO;
      this.SendPacket(this.ISO_CR);
      if (this._LastError == 0)
      {
        int num = this.RecvIsoPacket();
        if (this._LastError == 0)
        {
          if (num == 22)
          {
            if (this.LastPDUType != (byte) 208)
              this._LastError = 65536;
          }
          else
            this._LastError = 196608;
        }
      }
      return this._LastError;
    }

    private int NegotiatePduLength()
    {
      this.S7_PN.SetWordAt(23, (ushort) this._PduSizeRequested);
      this.SendPacket(this.S7_PN);
      if (this._LastError == 0)
      {
        int num = this.RecvIsoPacket();
        if (this._LastError == 0)
        {
          if (num == 27 && this.PDU[17] == (byte) 0 && this.PDU[18] == (byte) 0)
          {
            this._PDULength = (int) this.PDU.GetWordAt(25);
            if (this._PDULength <= 0)
              this._LastError = 1048576;
          }
          else
            this._LastError = 1048576;
        }
      }
      return this._LastError;
    }

    private int CpuError(ushort Error)
    {
      switch (Error)
      {
        case 0:
          return 0;
        case 5:
          return 9437184;
        case 6:
          return 10485760;
        case 7:
          return 11534336;
        case 10:
        case 53769:
          return 12582912;
        case 33028:
          return 20971520;
        case 34048:
          return 7340032;
        case 53825:
          return 30408704;
        case 54786:
          return 31457280;
        case 54788:
        case 54789:
          return 32505856;
        case 56321:
          return 13631488;
        default:
          return 36700160;
      }
    }

    public Dictionary<string, Sharp7.List> List
    {
      get => this._list;
      set => value = this._list;
    }

    public Dictionary<string, Sharp7.Tag> Tag
    {
      get => this._tag;
      set => value = this._tag;
    }

    public Dictionary<string, Sharp7.Package> Package
    {
      get => this._package;
      set => value = this._package;
    }

    public S7Client()
    {
      this.CreateSocket();
      this.List = new Dictionary<string, Sharp7.List>();
    }

    public S7Client(string filename)
    {
      this.CreateSocket();
      this.List = new Dictionary<string, Sharp7.List>();
      this.Tag = new Dictionary<string, Sharp7.Tag>();
      this.Package = new Dictionary<string, Sharp7.Package>();
      this.RegisterXml(filename);
    }

    ~S7Client() => this.Disconnect();

    public int Connect()
    {
      this._LastError = 0;
      this.Time_ms = 0;
      int tickCount = Environment.TickCount;
      if (!this.Connected)
      {
        this.TCPConnect();
        if (this._LastError == 0)
        {
          this.ISOConnect();
          if (this._LastError == 0)
            this._LastError = this.NegotiatePduLength();
        }
      }
      if (this._LastError != 0)
        this.Disconnect();
      else
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int ConnectTo(string Address, int Rack, int Slot)
    {
      ushort RemoteTSAP = (ushort) (((int) this.ConnType << 8) + Rack * 32 + Slot);
      this.SetConnectionParams(Address, (ushort) 256, RemoteTSAP);
      return this.Connect();
    }

    public int SetConnectionParams(string Address, ushort LocalTSAP, ushort RemoteTSAP)
    {
      int num1 = (int) LocalTSAP & (int) ushort.MaxValue;
      int num2 = (int) RemoteTSAP & (int) ushort.MaxValue;
      this.IPAddress = Address;
      this.LocalTSAP_HI = (byte) (num1 >> 8);
      this.LocalTSAP_LO = (byte) (num1 & (int) byte.MaxValue);
      this.RemoteTSAP_HI = (byte) (num2 >> 8);
      this.RemoteTSAP_LO = (byte) (num2 & (int) byte.MaxValue);
      return 0;
    }

    public int SetConnectionType(ushort ConnectionType)
    {
      this.ConnType = ConnectionType;
      return 0;
    }

    public int Disconnect()
    {
      this.Socket?.Close();
      return 0;
    }

    public int GetParam(int ParamNumber, ref int Value)
    {
      int num = 0;
      switch (ParamNumber)
      {
        case 2:
          Value = this.PLCPort;
          break;
        case 3:
          Value = this.ConnTimeout;
          break;
        case 4:
          Value = this.SendTimeout;
          break;
        case 5:
          Value = this.RecvTimeout;
          break;
        case 10:
          Value = this.PduSizeRequested;
          break;
        default:
          num = 38797312;
          break;
      }
      return num;
    }

    public int SetParam(int ParamNumber, ref int Value)
    {
      int num = 0;
      switch (ParamNumber)
      {
        case 2:
          this.PLCPort = Value;
          break;
        case 3:
          this.ConnTimeout = Value;
          break;
        case 4:
          this.SendTimeout = Value;
          break;
        case 5:
          this.RecvTimeout = Value;
          break;
        case 10:
          this.PduSizeRequested = Value;
          break;
        default:
          num = 38797312;
          break;
      }
      return num;
    }

    public int SetAsCallBack(S7Client.S7CliCompletion Completion, IntPtr usrPtr) => 40894464;

    public int ReadArea(
      S7Area Area,
      int DBNumber,
      int Start,
      int Amount,
      S7WordLength WordLen,
      byte[] Buffer)
    {
      return this.ReadArea((int) Area, DBNumber, Start, Amount, (int) WordLen, Buffer);
    }

    public int ReadArea(
      S7Area Area,
      int DBNumber,
      int Start,
      int Amount,
      S7WordLength WordLen,
      byte[] Buffer,
      ref int BytesRead)
    {
      return this.ReadArea((int) Area, DBNumber, Start, Amount, (int) WordLen, Buffer, ref BytesRead);
    }

    public int ReadArea(
      int Area,
      int DBNumber,
      int Start,
      int Amount,
      int WordLen,
      byte[] Buffer)
    {
      int BytesRead = 0;
      return this.ReadArea(Area, DBNumber, Start, Amount, WordLen, Buffer, ref BytesRead);
    }

    public int ReadArea(
      int Area,
      int DBNumber,
      int Start,
      int Amount,
      int WordLen,
      byte[] Buffer,
      ref int BytesRead)
    {
      int destinationIndex = 0;
      this._LastError = 0;
      this.Time_ms = 0;
      int tickCount = Environment.TickCount;
      if (Area == 28)
        WordLen = 28;
      if (Area == 29)
        WordLen = 29;
      int num1 = WordLen.DataSizeByte();
      if (num1 == 0)
        return 5242880;
      int num2;
      switch (WordLen)
      {
        case 1:
          Amount = 1;
          goto label_13;
        case 28:
          num2 = 0;
          break;
        default:
          num2 = WordLen != 29 ? 1 : 0;
          break;
      }
      if (num2 != 0)
      {
        Amount *= num1;
        num1 = 1;
        WordLen = 2;
      }
label_13:
      int num3 = (this._PDULength - 18) / num1;
      int num4 = Amount;
      while (num4 > 0 && this._LastError == 0)
      {
        int num5 = num4;
        if (num5 > num3)
          num5 = num3;
        int length = num5 * num1;
        Array.Copy((Array) this.S7_RW, 0, (Array) this.PDU, 0, S7Client.Size_RD);
        this.PDU[27] = (byte) Area;
        if (Area == 132)
          this.PDU.SetWordAt(25, (ushort) DBNumber);
        int num6;
        if (WordLen == 1 || WordLen == 28 || WordLen == 29)
        {
          num6 = Start;
          this.PDU[22] = (byte) WordLen;
        }
        else
          num6 = Start << 3;
        this.PDU.SetWordAt(23, (ushort) num5);
        this.PDU[30] = (byte) (num6 & (int) byte.MaxValue);
        int num7 = num6 >> 8;
        this.PDU[29] = (byte) (num7 & (int) byte.MaxValue);
        this.PDU[28] = (byte) (num7 >> 8 & (int) byte.MaxValue);
        this.SendPacket(this.PDU, S7Client.Size_RD);
        if (this._LastError == 0)
        {
          int num8 = this.RecvIsoPacket();
          if (this._LastError == 0)
          {
            if (num8 < 25)
              this._LastError = 262144;
            else if (this.PDU[21] != byte.MaxValue)
            {
              this._LastError = this.CpuError((ushort) this.PDU[21]);
            }
            else
            {
              Array.Copy((Array) this.PDU, 25, (Array) Buffer, destinationIndex, length);
              destinationIndex += length;
            }
          }
        }
        num4 -= num5;
        Start += num5 * num1;
      }
      if (this._LastError == 0)
      {
        BytesRead = destinationIndex;
        this.Time_ms = Environment.TickCount - tickCount;
      }
      else
        BytesRead = 0;
      return this._LastError;
    }

    public int WriteArea(
      S7Area Area,
      int DBNumber,
      int Start,
      int Amount,
      S7WordLength WordLen,
      byte[] Buffer)
    {
      int BytesWritten = 0;
      return this.WriteArea((int) Area, DBNumber, Start, Amount, (int) WordLen, Buffer, ref BytesWritten);
    }

    public int WriteArea(
      S7Area Area,
      int DBNumber,
      int Start,
      int Amount,
      S7WordLength WordLen,
      byte[] Buffer,
      ref int BytesWritten)
    {
      return this.WriteArea((int) Area, DBNumber, Start, Amount, (int) WordLen, Buffer, ref BytesWritten);
    }

    public int WriteArea(
      int Area,
      int DBNumber,
      int Start,
      int Amount,
      int WordLen,
      byte[] Buffer)
    {
      int BytesWritten = 0;
      return this.WriteArea(Area, DBNumber, Start, Amount, WordLen, Buffer, ref BytesWritten);
    }

    public int WriteArea(
      int Area,
      int DBNumber,
      int Start,
      int Amount,
      int WordLen,
      byte[] Buffer,
      ref int BytesWritten)
    {
      int sourceIndex = 0;
      this._LastError = 0;
      this.Time_ms = 0;
      int tickCount = Environment.TickCount;
      if (Area == 28)
        WordLen = 28;
      if (Area == 29)
        WordLen = 29;
      int num1 = WordLen.DataSizeByte();
      if (num1 == 0)
        return 5242880;
      int num2;
      switch (WordLen)
      {
        case 1:
          Amount = 1;
          goto label_13;
        case 28:
          num2 = 0;
          break;
        default:
          num2 = WordLen != 29 ? 1 : 0;
          break;
      }
      if (num2 != 0)
      {
        Amount *= num1;
        num1 = 1;
        WordLen = 2;
      }
label_13:
      int num3 = (this._PDULength - 35) / num1;
      int num4 = Amount;
      while (num4 > 0 && this._LastError == 0)
      {
        int num5 = num4;
        if (num5 > num3)
          num5 = num3;
        int length = num5 * num1;
        int Len = S7Client.Size_WR + length;
        Array.Copy((Array) this.S7_RW, 0, (Array) this.PDU, 0, S7Client.Size_WR);
        this.PDU.SetWordAt(2, (ushort) Len);
        this.PDU.SetWordAt(15, (ushort) (length + 4));
        this.PDU[17] = (byte) 5;
        this.PDU[27] = (byte) Area;
        if (Area == 132)
          this.PDU.SetWordAt(25, (ushort) DBNumber);
        int num6;
        int num7;
        if (WordLen == 1 || WordLen == 28 || WordLen == 29)
        {
          num6 = Start;
          num7 = length;
          this.PDU[22] = (byte) WordLen;
        }
        else
        {
          num6 = Start << 3;
          num7 = length << 3;
        }
        this.PDU.SetWordAt(23, (ushort) num5);
        this.PDU[30] = (byte) (num6 & (int) byte.MaxValue);
        int num8 = num6 >> 8;
        this.PDU[29] = (byte) (num8 & (int) byte.MaxValue);
        this.PDU[28] = (byte) (num8 >> 8 & (int) byte.MaxValue);
        switch (WordLen)
        {
          case 1:
            this.PDU[32] = (byte) 3;
            break;
          case 28:
          case 29:
            this.PDU[32] = (byte) 9;
            break;
          default:
            this.PDU[32] = (byte) 4;
            break;
        }
        this.PDU.SetWordAt(33, (ushort) num7);
        Array.Copy((Array) Buffer, sourceIndex, (Array) this.PDU, 35, length);
        this.SendPacket(this.PDU, Len);
        if (this._LastError == 0)
        {
          int num9 = this.RecvIsoPacket();
          if (this._LastError == 0)
          {
            if (num9 == 22)
            {
              if (this.PDU[21] != byte.MaxValue)
                this._LastError = this.CpuError((ushort) this.PDU[21]);
            }
            else
              this._LastError = 196608;
          }
        }
        sourceIndex += length;
        num4 -= num5;
        Start += num5 * num1;
      }
      if (this._LastError == 0)
      {
        BytesWritten = sourceIndex;
        this.Time_ms = Environment.TickCount - tickCount;
      }
      else
        BytesWritten = 0;
      return this._LastError;
    }

    public int ReadMultiVars(S7Client.S7DataItem[] Items, int ItemsCount)
    {
      byte[] numArray1 = new byte[12];
      byte[] numArray2 = new byte[1024];
      this._LastError = 0;
      this.Time_ms = 0;
      int tickCount = Environment.TickCount;
      if (ItemsCount > S7Client.MaxVars)
        return 4194304;
      Array.Copy((Array) this.S7_MRD_HEADER, 0, (Array) this.PDU, 0, this.S7_MRD_HEADER.Length);
      this.PDU.SetWordAt(13, (ushort) (ItemsCount * numArray1.Length + 2));
      this.PDU[18] = (byte) ItemsCount;
      int num1 = 19;
      for (int index = 0; index < ItemsCount; ++index)
      {
        Array.Copy((Array) this.S7_MRD_ITEM, (Array) numArray1, numArray1.Length);
        numArray1[3] = (byte) Items[index].WordLen;
        numArray1.SetWordAt(4, (ushort) Items[index].Amount);
        if (Items[index].Area == 132)
          numArray1.SetWordAt(6, (ushort) Items[index].DBNumber);
        numArray1[8] = (byte) Items[index].Area;
        int start = Items[index].Start;
        numArray1[11] = (byte) (start & (int) byte.MaxValue);
        int num2 = start >> 8;
        numArray1[10] = (byte) (num2 & (int) byte.MaxValue);
        int num3 = num2 >> 8;
        numArray1[9] = (byte) (num3 & (int) byte.MaxValue);
        Array.Copy((Array) numArray1, 0, (Array) this.PDU, num1, numArray1.Length);
        num1 += numArray1.Length;
      }
      if (num1 > this._PDULength)
        return 7340032;
      this.PDU.SetWordAt(2, (ushort) num1);
      this.SendPacket(this.PDU, num1);
      if (this._LastError != 0)
        return this._LastError;
      int num4 = this.RecvIsoPacket();
      if (this._LastError != 0)
        return this._LastError;
      if (num4 < 22)
      {
        this._LastError = 196608;
        return this._LastError;
      }
      this._LastError = this.CpuError(this.PDU.GetWordAt(17));
      if (this._LastError != 0)
        return this._LastError;
      int byteAt = (int) this.PDU.GetByteAt(20);
      if (byteAt != ItemsCount || byteAt > S7Client.MaxVars)
      {
        this._LastError = 8388608;
        return this._LastError;
      }
      int sourceIndex = 21;
      for (int index = 0; index < ItemsCount; ++index)
      {
        Array.Copy((Array) this.PDU, sourceIndex, (Array) numArray2, 0, num4 - sourceIndex);
        if (numArray2[0] == byte.MaxValue)
        {
          int wordAt = (int) numArray2.GetWordAt(2);
          if (numArray2[1] != (byte) 9 && numArray2[1] != (byte) 7 && numArray2[1] != (byte) 3)
            wordAt >>= 3;
          Marshal.Copy(numArray2, 4, Items[index].pData, wordAt);
          Items[index].Result = 0;
          if (wordAt % 2 != 0)
            ++wordAt;
          sourceIndex = sourceIndex + 4 + wordAt;
        }
        else
        {
          Items[index].Result = this.CpuError((ushort) numArray2[0]);
          sourceIndex += 4;
        }
      }
      this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int WriteMultiVars(S7Client.S7DataItem[] Items, int ItemsCount)
    {
      byte[] numArray1 = new byte[this.S7_MWR_PARAM.Length];
      byte[] numArray2 = new byte[1024];
      this._LastError = 0;
      this.Time_ms = 0;
      int tickCount = Environment.TickCount;
      if (ItemsCount > S7Client.MaxVars)
        return 4194304;
      Array.Copy((Array) this.S7_MWR_HEADER, 0, (Array) this.PDU, 0, this.S7_MWR_HEADER.Length);
      this.PDU.SetWordAt(13, (ushort) (ItemsCount * this.S7_MWR_PARAM.Length + 2));
      this.PDU[18] = (byte) ItemsCount;
      int num1 = this.S7_MWR_HEADER.Length;
      for (int index = 0; index < ItemsCount; ++index)
      {
        Array.Copy((Array) this.S7_MWR_PARAM, 0, (Array) numArray1, 0, this.S7_MWR_PARAM.Length);
        numArray1[3] = (byte) Items[index].WordLen;
        numArray1[8] = (byte) Items[index].Area;
        numArray1.SetWordAt(4, (ushort) Items[index].Amount);
        numArray1.SetWordAt(6, (ushort) Items[index].DBNumber);
        int start = Items[index].Start;
        numArray1[11] = (byte) (start & (int) byte.MaxValue);
        int num2 = start >> 8;
        numArray1[10] = (byte) (num2 & (int) byte.MaxValue);
        int num3 = num2 >> 8;
        numArray1[9] = (byte) (num3 & (int) byte.MaxValue);
        Array.Copy((Array) numArray1, 0, (Array) this.PDU, num1, numArray1.Length);
        num1 += this.S7_MWR_PARAM.Length;
      }
      int num4 = 0;
      for (int index = 0; index < ItemsCount; ++index)
      {
        numArray2[0] = (byte) 0;
        switch (Items[index].WordLen)
        {
          case 1:
            numArray2[1] = (byte) 3;
            break;
          case 28:
          case 29:
            numArray2[1] = (byte) 9;
            break;
          default:
            numArray2[1] = (byte) 4;
            break;
        }
        int length = Items[index].WordLen != 29 && Items[index].WordLen != 28 ? Items[index].Amount : Items[index].Amount * 2;
        if (numArray2[1] != (byte) 9 && numArray2[1] != (byte) 3)
          numArray2.SetWordAt(2, (ushort) (length * 8));
        else
          numArray2.SetWordAt(2, (ushort) length);
        Marshal.Copy(Items[index].pData, numArray2, 4, length);
        if (length % 2 != 0)
        {
          numArray2[length + 4] = (byte) 0;
          ++length;
        }
        Array.Copy((Array) numArray2, 0, (Array) this.PDU, num1, length + 4);
        num1 = num1 + length + 4;
        num4 = num4 + length + 4;
      }
      if (num1 > this._PDULength)
        return 7340032;
      this.PDU.SetWordAt(2, (ushort) num1);
      this.PDU.SetWordAt(15, (ushort) num4);
      this.SendPacket(this.PDU, num1);
      this.RecvIsoPacket();
      if (this._LastError == 0)
      {
        this._LastError = this.CpuError(this.PDU.GetWordAt(17));
        if (this._LastError != 0)
          return this._LastError;
        int byteAt = (int) this.PDU.GetByteAt(20);
        if (byteAt != ItemsCount || byteAt > S7Client.MaxVars)
        {
          this._LastError = 8388608;
          return this._LastError;
        }
        for (int index = 0; index < ItemsCount; ++index)
          Items[index].Result = this.PDU[index + 21] != byte.MaxValue ? this.CpuError((ushort) this.PDU[index + 21]) : 0;
        this.Time_ms = Environment.TickCount - tickCount;
      }
      return this._LastError;
    }

    public int DBRead(int DBNumber, int Start, int Size, byte[] Buffer) => this.ReadArea(S7Area.DB, DBNumber, Start, Size, S7WordLength.Byte, Buffer);

    public int ReadClass(object SourceClass, S7Area S7Area, int DBNumber, int Start = 0)
    {
      int classSize = (int) Class.GetClassSize(SourceClass);
      byte[] numArray = new byte[classSize];
      if (classSize <= 0)
        throw new Exception("The size of the class is less than 1 byte and therefore cannot be read");
      int num = this.ReadArea(S7Area, DBNumber, Start, classSize, S7WordLength.Byte, numArray);
      Class.FromBytes(SourceClass, numArray);
      return num;
    }

    public int DBWrite(int DBNumber, int Start, int Size, byte[] Buffer) => this.WriteArea(S7Area.DB, DBNumber, Start, Size, S7WordLength.Byte, Buffer);

    public int MBRead(int Start, int Size, byte[] Buffer) => this.ReadArea(S7Area.MK, 0, Start, Size, S7WordLength.Byte, Buffer);

    public int MBWrite(int Start, int Size, byte[] Buffer) => this.WriteArea(S7Area.MK, 0, Start, Size, S7WordLength.Byte, Buffer);

    public int EBRead(int Start, int Size, byte[] Buffer) => this.ReadArea(S7Area.PE, 0, Start, Size, S7WordLength.Byte, Buffer);

    public int EBWrite(int Start, int Size, byte[] Buffer) => this.WriteArea(S7Area.PE, 0, Start, Size, S7WordLength.Byte, Buffer);

    public int ABRead(int Start, int Size, byte[] Buffer) => this.ReadArea(S7Area.PA, 0, Start, Size, S7WordLength.Byte, Buffer);

    public int ABWrite(int Start, int Size, byte[] Buffer) => this.WriteArea(S7Area.PA, 0, Start, Size, S7WordLength.Byte, Buffer);

    public int TMRead(int Start, int Amount, ushort[] Buffer)
    {
      byte[] Buffer1 = new byte[Amount * 2];
      int num = this.ReadArea(S7Area.TM, 0, Start, Amount, S7WordLength.Timer, Buffer1);
      if (num == 0)
      {
        for (int index = 0; index < Amount; ++index)
          Buffer[index] = (ushort) (((uint) Buffer1[index * 2 + 1] << 8) + (uint) Buffer1[index * 2]);
      }
      return num;
    }

    public int TMWrite(int Start, int Amount, ushort[] Buffer)
    {
      byte[] Buffer1 = new byte[Amount * 2];
      for (int index = 0; index < Amount; ++index)
      {
        Buffer1[index * 2 + 1] = (byte) (((int) Buffer[index] & 65280) >> 8);
        Buffer1[index * 2] = (byte) ((uint) Buffer[index] & (uint) byte.MaxValue);
      }
      return this.WriteArea(S7Area.TM, 0, Start, Amount, S7WordLength.Timer, Buffer1);
    }

    public int CTRead(int Start, int Amount, ushort[] Buffer)
    {
      byte[] Buffer1 = new byte[Amount * 2];
      int num = this.ReadArea(S7Area.CT, 0, Start, Amount, S7WordLength.Counter, Buffer1);
      if (num == 0)
      {
        for (int index = 0; index < Amount; ++index)
          Buffer[index] = (ushort) (((uint) Buffer1[index * 2 + 1] << 8) + (uint) Buffer1[index * 2]);
      }
      return num;
    }

    public int CTWrite(int Start, int Amount, ushort[] Buffer)
    {
      byte[] Buffer1 = new byte[Amount * 2];
      for (int index = 0; index < Amount; ++index)
      {
        Buffer1[index * 2 + 1] = (byte) (((int) Buffer[index] & 65280) >> 8);
        Buffer1[index * 2] = (byte) ((uint) Buffer[index] & (uint) byte.MaxValue);
      }
      return this.WriteArea(S7Area.CT, 0, Start, Amount, S7WordLength.Counter, Buffer1);
    }

    public 
    #nullable enable
    object? Read(
    #nullable disable
    string variable, S7Type types)
    {
      PLCAddress plcAddress = new PLCAddress(variable, types);
      this.ReadArea(plcAddress.S7Area, plcAddress.DBNumber, plcAddress.Start, plcAddress.Size, plcAddress.S7WordLength, plcAddress.Butter);
      return PLCAddress.GetValue(plcAddress.Butter, types);
    }

    public 
    #nullable enable
    object? Read(string name)
    {
      this.ReadArea(this.List[name].s7Area, this.List[name].dbNumber, this.List[name].start, this.List[name].size, this.List[name].s7WordLength, this.List[name].buff);
      return PLCAddress.GetValue(this.List[name].buff, this.List[name].s7Type);
    }

    public int Write(string variable, S7Type types, object value)
    {
      bool stat = false;
      PLCAddress plcAddress = new PLCAddress(variable, types);
      plcAddress.Butter = PLCAddress.Deserialization(types, value, out stat);
      return stat ? this.WriteArea(plcAddress.S7Area, plcAddress.DBNumber, plcAddress.Start, plcAddress.Size, plcAddress.S7WordLength, plcAddress.Butter) : 9999;
    }

    public int Write(string name, object value)
    {
      bool stat = false;
      this.List[name].buff = PLCAddress.Deserialization(this.List[name].s7Type, value, out stat);
      return stat ? this.WriteArea(this.List[name].s7Area, this.List[name].dbNumber, this.List[name].start, this.List[name].size, this.List[name].s7WordLength, this.List[name].buff) : 9999;
    }

    public int ListBlocks(ref S7Client.S7BlocksList List) => 40894464;

    private string SiemensTimestamp(long EncodedDate) => new DateTime(1984, 1, 1).AddSeconds((double) (EncodedDate * 86400L)).ToShortDateString();

    public int GetAgBlockInfo(int BlockType, int BlockNum, ref S7Client.S7BlockInfo Info)
    {
      this._LastError = 0;
      this.Time_ms = 0;
      int tickCount = Environment.TickCount;
      this.S7_BI[30] = (byte) BlockType;
      this.S7_BI[31] = (byte) (BlockNum / 10000 + 48);
      BlockNum %= 10000;
      this.S7_BI[32] = (byte) (BlockNum / 1000 + 48);
      BlockNum %= 1000;
      this.S7_BI[33] = (byte) (BlockNum / 100 + 48);
      BlockNum %= 100;
      this.S7_BI[34] = (byte) (BlockNum / 10 + 48);
      BlockNum %= 10;
      this.S7_BI[35] = (byte) (BlockNum / 1 + 48);
      this.SendPacket(this.S7_BI);
      if (this._LastError == 0)
      {
        if (this.RecvIsoPacket() > 32)
        {
          ushort wordAt = this.PDU.GetWordAt(27);
          if (wordAt == (ushort) 0)
          {
            Info.BlkFlags = (int) this.PDU[42];
            Info.BlkLang = (int) this.PDU[43];
            Info.BlkType = (int) this.PDU[44];
            Info.BlkNumber = (int) this.PDU.GetWordAt(45);
            Info.LoadSize = this.PDU.GetDIntAt(47);
            Info.CodeDate = this.SiemensTimestamp((long) this.PDU.GetWordAt(59));
            Info.IntfDate = this.SiemensTimestamp((long) this.PDU.GetWordAt(65));
            Info.SBBLength = (int) this.PDU.GetWordAt(67);
            Info.LocalData = (int) this.PDU.GetWordAt(71);
            Info.MC7Size = (int) this.PDU.GetWordAt(73);
            Info.Author = this.PDU.GetCharsAt(75, 8).Trim(new char[1]);
            Info.Family = this.PDU.GetCharsAt(83, 8).Trim(new char[1]);
            Info.Header = this.PDU.GetCharsAt(91, 8).Trim(new char[1]);
            Info.Version = (int) this.PDU[99];
            Info.CheckSum = (int) this.PDU.GetWordAt(101);
          }
          else
            this._LastError = this.CpuError(wordAt);
        }
        else
          this._LastError = 196608;
      }
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int GetPgBlockInfo(ref S7Client.S7BlockInfo Info, byte[] Buffer, int Size) => 40894464;

    public int ListBlocksOfType(int BlockType, ushort[] List, ref int ItemsCount) => 40894464;

    public int Upload(int BlockType, int BlockNum, byte[] UsrData, ref int Size) => 40894464;

    public int FullUpload(int BlockType, int BlockNum, byte[] UsrData, ref int Size) => 40894464;

    public int Download(int BlockNum, byte[] UsrData, int Size) => 40894464;

    public int Delete(int BlockType, int BlockNum) => 40894464;

    public int DBGet(int DBNumber, byte[] UsrData, ref int Size)
    {
      S7Client.S7BlockInfo Info = new S7Client.S7BlockInfo();
      int tickCount = Environment.TickCount;
      this.Time_ms = 0;
      this._LastError = this.GetAgBlockInfo(65, DBNumber, ref Info);
      if (this._LastError == 0)
      {
        int mc7Size = Info.MC7Size;
        if (mc7Size <= UsrData.Length)
        {
          Size = mc7Size;
          this._LastError = this.DBRead(DBNumber, 0, mc7Size, UsrData);
          if (this._LastError == 0)
            Size = mc7Size;
        }
        else
          this._LastError = 35651584;
      }
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int DBFill(int DBNumber, int FillChar)
    {
      S7Client.S7BlockInfo Info = new S7Client.S7BlockInfo();
      int tickCount = Environment.TickCount;
      this.Time_ms = 0;
      this._LastError = this.GetAgBlockInfo(65, DBNumber, ref Info);
      if (this._LastError == 0)
      {
        byte[] Buffer = new byte[Info.MC7Size];
        for (int index = 0; index < Info.MC7Size; ++index)
          Buffer[index] = (byte) FillChar;
        this._LastError = this.DBWrite(DBNumber, 0, Info.MC7Size, Buffer);
      }
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int GetPlcDateTime(ref DateTime DT)
    {
      this._LastError = 0;
      this.Time_ms = 0;
      int tickCount = Environment.TickCount;
      this.SendPacket(this.S7_GET_DT);
      if (this._LastError == 0)
      {
        if (this.RecvIsoPacket() > 30)
        {
          if (this.PDU.GetWordAt(27) == (ushort) 0 && this.PDU[29] == byte.MaxValue)
            DT = this.PDU.GetDateTimeAt(35);
          else
            this._LastError = 8388608;
        }
        else
          this._LastError = 196608;
      }
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int SetPlcDateTime(DateTime DT)
    {
      this._LastError = 0;
      this.Time_ms = 0;
      int tickCount = Environment.TickCount;
      this.S7_SET_DT.SetDateTimeAt(31, DT);
      this.SendPacket(this.S7_SET_DT);
      if (this._LastError == 0)
      {
        if (this.RecvIsoPacket() > 30)
        {
          if (this.PDU.GetWordAt(27) > (ushort) 0)
            this._LastError = 8388608;
        }
        else
          this._LastError = 196608;
      }
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int SetPlcSystemDateTime() => this.SetPlcDateTime(DateTime.Now);

    public int GetOrderCode(ref S7Client.S7OrderCode Info)
    {
      S7Client.S7SZL SZL = new S7Client.S7SZL();
      int Size = 1024;
      SZL.Data = new byte[Size];
      int tickCount = Environment.TickCount;
      this._LastError = this.ReadSZL(17, 0, ref SZL, ref Size);
      if (this._LastError == 0)
      {
        Info.Code = SZL.Data.GetCharsAt(2, 20);
        Info.V1 = SZL.Data[Size - 3];
        Info.V2 = SZL.Data[Size - 2];
        Info.V3 = SZL.Data[Size - 1];
      }
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int GetCpuInfo(ref S7Client.S7CpuInfo Info)
    {
      S7Client.S7SZL SZL = new S7Client.S7SZL();
      int Size = 1024;
      SZL.Data = new byte[Size];
      int tickCount = Environment.TickCount;
      this._LastError = this.ReadSZL(28, 0, ref SZL, ref Size);
      if (this._LastError == 0)
      {
        Info.ModuleTypeName = SZL.Data.GetCharsAt(172, 32);
        Info.SerialNumber = SZL.Data.GetCharsAt(138, 24);
        Info.ASName = SZL.Data.GetCharsAt(2, 24);
        Info.Copyright = SZL.Data.GetCharsAt(104, 26);
        Info.ModuleName = SZL.Data.GetCharsAt(36, 24);
      }
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int GetCpInfo(ref S7Client.S7CpInfo Info)
    {
      S7Client.S7SZL SZL = new S7Client.S7SZL();
      int Size = 1024;
      SZL.Data = new byte[Size];
      int tickCount = Environment.TickCount;
      this._LastError = this.ReadSZL(305, 1, ref SZL, ref Size);
      if (this._LastError == 0)
      {
        Info.MaxPduLength = this.PDU.GetIntAt(2);
        Info.MaxConnections = this.PDU.GetIntAt(4);
        Info.MaxMpiRate = this.PDU.GetDIntAt(6);
        Info.MaxBusRate = this.PDU.GetDIntAt(10);
      }
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int ReadSZL(int ID, int Index, ref S7Client.S7SZL SZL, ref int Size)
    {
      int destinationIndex = 0;
      bool flag1 = false;
      bool flag2 = true;
      byte num1 = 0;
      ushort num2 = 0;
      this._LastError = 0;
      this.Time_ms = 0;
      int tickCount = Environment.TickCount;
      SZL.Header.LENTHDR = (ushort) 0;
      do
      {
        if (flag2)
        {
          this.S7_SZL_FIRST.SetWordAt(11, ++num2);
          this.S7_SZL_FIRST.SetWordAt(29, (ushort) ID);
          this.S7_SZL_FIRST.SetWordAt(31, (ushort) Index);
          this.SendPacket(this.S7_SZL_FIRST);
        }
        else
        {
          this.S7_SZL_NEXT.SetWordAt(11, ++num2);
          this.PDU[24] = num1;
          this.SendPacket(this.S7_SZL_NEXT);
        }
        if (this._LastError != 0)
          return this._LastError;
        int num3 = this.RecvIsoPacket();
        if (this._LastError == 0)
        {
          if (flag2)
          {
            if (num3 > 32)
            {
              if (this.PDU.GetWordAt(27) == (ushort) 0 && this.PDU[29] == byte.MaxValue)
              {
                int length = (int) this.PDU.GetWordAt(31) - 8;
                flag1 = this.PDU[26] == (byte) 0;
                num1 = this.PDU[24];
                SZL.Header.LENTHDR = this.PDU.GetWordAt(37);
                SZL.Header.N_DR = this.PDU.GetWordAt(39);
                Array.Copy((Array) this.PDU, 41, (Array) SZL.Data, destinationIndex, length);
                destinationIndex += length;
                SZL.Header.LENTHDR += SZL.Header.LENTHDR;
              }
              else
                this._LastError = 8388608;
            }
            else
              this._LastError = 196608;
          }
          else if (num3 > 32)
          {
            if (this.PDU.GetWordAt(27) == (ushort) 0 && this.PDU[29] == byte.MaxValue)
            {
              int wordAt = (int) this.PDU.GetWordAt(31);
              flag1 = this.PDU[26] == (byte) 0;
              num1 = this.PDU[24];
              Array.Copy((Array) this.PDU, 37, (Array) SZL.Data, destinationIndex, wordAt);
              destinationIndex += wordAt;
              SZL.Header.LENTHDR += SZL.Header.LENTHDR;
            }
            else
              this._LastError = 8388608;
          }
          else
            this._LastError = 196608;
        }
        flag2 = false;
      }
      while (!flag1 && this._LastError == 0);
      if (this._LastError == 0)
      {
        Size = (int) SZL.Header.LENTHDR;
        this.Time_ms = Environment.TickCount - tickCount;
      }
      return this._LastError;
    }

    public int ReadSZLList(ref S7Client.S7SZLList List, ref int ItemsCount) => 40894464;

    public int PlcHotStart()
    {
      this._LastError = 0;
      int tickCount = Environment.TickCount;
      this.SendPacket(this.S7_HOT_START);
      if (this._LastError == 0)
        this._LastError = this.RecvIsoPacket() <= 18 ? 196608 : (this.PDU[19] == (byte) 40 ? (this.PDU[20] != (byte) 2 ? 14680064 : 15728640) : 14680064);
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int PlcColdStart()
    {
      this._LastError = 0;
      int tickCount = Environment.TickCount;
      this.SendPacket(this.S7_COLD_START);
      if (this._LastError == 0)
        this._LastError = this.RecvIsoPacket() <= 18 ? 196608 : (this.PDU[19] == (byte) 40 ? (this.PDU[20] != (byte) 2 ? 14680064 : 15728640) : 14680064);
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int PlcStop()
    {
      this._LastError = 0;
      int tickCount = Environment.TickCount;
      this.SendPacket(this.S7_STOP);
      if (this._LastError == 0)
        this._LastError = this.RecvIsoPacket() <= 18 ? 196608 : (this.PDU[19] == (byte) 41 ? (this.PDU[20] != (byte) 7 ? 16777216 : 19922944) : 16777216);
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int PlcCopyRamToRom(uint Timeout) => 40894464;

    public int PlcCompress(uint Timeout) => 40894464;

    public int PlcGetStatus(ref int Status)
    {
      this._LastError = 0;
      int tickCount = Environment.TickCount;
      this.SendPacket(this.S7_GET_STAT);
      if (this._LastError == 0)
      {
        if (this.RecvIsoPacket() > 30)
        {
          ushort wordAt = this.PDU.GetWordAt(27);
          if (wordAt == (ushort) 0)
          {
            switch (this.PDU[44])
            {
              case 0:
              case 4:
              case 8:
                Status = (int) this.PDU[44];
                break;
              default:
                Status = 4;
                break;
            }
          }
          else
            this._LastError = this.CpuError(wordAt);
        }
        else
          this._LastError = 196608;
      }
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int SetSessionPassword(string Password)
    {
      byte[] numArray = new byte[8]
      {
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32,
        (byte) 32
      };
      this._LastError = 0;
      int tickCount = Environment.TickCount;
      numArray.SetCharsAt(0, Password);
      numArray[0] = (byte) ((uint) numArray[0] ^ 85U);
      numArray[1] = (byte) ((uint) numArray[1] ^ 85U);
      for (int index = 2; index < 8; ++index)
        numArray[index] = (byte) ((uint) numArray[index] ^ 85U ^ (uint) numArray[index - 2]);
      Array.Copy((Array) numArray, 0, (Array) this.S7_SET_PWD, 29, 8);
      this.SendPacket(this.S7_SET_PWD);
      if (this._LastError == 0)
      {
        if (this.RecvIsoPacket() > 32)
        {
          ushort wordAt = this.PDU.GetWordAt(27);
          if (wordAt > (ushort) 0)
            this._LastError = this.CpuError(wordAt);
        }
        else
          this._LastError = 196608;
      }
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      return this._LastError;
    }

    public int ClearSessionPassword()
    {
      this._LastError = 0;
      int tickCount = Environment.TickCount;
      this.SendPacket(this.S7_CLR_PWD);
      if (this._LastError == 0)
      {
        if (this.RecvIsoPacket() > 30)
        {
          ushort wordAt = this.PDU.GetWordAt(27);
          if (wordAt > (ushort) 0)
            this._LastError = this.CpuError(wordAt);
        }
        else
          this._LastError = 196608;
      }
      return this._LastError;
    }

    public int GetProtection(ref S7Client.S7Protection Protection)
    {
      S7Client.S7SZL SZL = new S7Client.S7SZL();
      int Size = 256;
      SZL.Data = new byte[Size];
      this._LastError = this.ReadSZL(562, 4, ref SZL, ref Size);
      if (this._LastError == 0)
      {
        Protection.sch_schal = SZL.Data.GetWordAt(2);
        Protection.sch_par = SZL.Data.GetWordAt(4);
        Protection.sch_rel = SZL.Data.GetWordAt(6);
        Protection.bart_sch = SZL.Data.GetWordAt(8);
        Protection.anl_sch = SZL.Data.GetWordAt(10);
      }
      return this._LastError;
    }

    public int IsoExchangeBuffer(byte[] Buffer, ref int Size)
    {
      this._LastError = 0;
      this.Time_ms = 0;
      int tickCount = Environment.TickCount;
      Array.Copy((Array) this.TPKT_ISO, 0, (Array) this.PDU, 0, this.TPKT_ISO.Length);
      this.PDU.SetWordAt(2, (ushort) (Size + this.TPKT_ISO.Length));
      try
      {
        Array.Copy((Array) Buffer, 0, (Array) this.PDU, this.TPKT_ISO.Length, Size);
      }
      catch
      {
        return 196608;
      }
      this.SendPacket(this.PDU, this.TPKT_ISO.Length + Size);
      if (this._LastError == 0)
      {
        int num = this.RecvIsoPacket();
        if (this._LastError == 0)
        {
          Array.Copy((Array) this.PDU, this.TPKT_ISO.Length, (Array) Buffer, 0, num - this.TPKT_ISO.Length);
          Size = num - this.TPKT_ISO.Length;
        }
      }
      if (this._LastError == 0)
        this.Time_ms = Environment.TickCount - tickCount;
      else
        Size = 0;
      return this._LastError;
    }

    public int AsReadArea(
      int Area,
      int DBNumber,
      int Start,
      int Amount,
      int WordLen,
      byte[] Buffer)
    {
      return 40894464;
    }

    public int AsWriteArea(
      int Area,
      int DBNumber,
      int Start,
      int Amount,
      int WordLen,
      byte[] Buffer)
    {
      return 40894464;
    }

    public int AsDBRead(int DBNumber, int Start, int Size, byte[] Buffer) => 40894464;

    public int AsDBWrite(int DBNumber, int Start, int Size, byte[] Buffer) => 40894464;

    public int AsMBRead(int Start, int Size, byte[] Buffer) => 40894464;

    public int AsMBWrite(int Start, int Size, byte[] Buffer) => 40894464;

    public int AsEBRead(int Start, int Size, byte[] Buffer) => 40894464;

    public int AsEBWrite(int Start, int Size, byte[] Buffer) => 40894464;

    public int AsABRead(int Start, int Size, byte[] Buffer) => 40894464;

    public int AsABWrite(int Start, int Size, byte[] Buffer) => 40894464;

    public int AsTMRead(int Start, int Amount, ushort[] Buffer) => 40894464;

    public int AsTMWrite(int Start, int Amount, ushort[] Buffer) => 40894464;

    public int AsCTRead(int Start, int Amount, ushort[] Buffer) => 40894464;

    public int AsCTWrite(int Start, int Amount, ushort[] Buffer) => 40894464;

    public int AsListBlocksOfType(int BlockType, ushort[] List) => 40894464;

    public int AsReadSZL(int ID, int Index, ref S7Client.S7SZL Data, ref int Size) => 40894464;

    public int AsReadSZLList(ref S7Client.S7SZLList List, ref int ItemsCount) => 40894464;

    public int AsUpload(int BlockType, int BlockNum, byte[] UsrData, ref int Size) => 40894464;

    public int AsFullUpload(int BlockType, int BlockNum, byte[] UsrData, ref int Size) => 40894464;

    public int ASDownload(int BlockNum, byte[] UsrData, int Size) => 40894464;

    public int AsPlcCopyRamToRom(uint Timeout) => 40894464;

    public int AsPlcCompress(uint Timeout) => 40894464;

    public int AsDBGet(int DBNumber, byte[] UsrData, ref int Size) => 40894464;

    public int AsDBFill(int DBNumber, int FillChar) => 40894464;

    public bool CheckAsCompletion(ref int opResult)
    {
      opResult = 0;
      return false;
    }

    public int WaitAsCompletion(int Timeout) => 40894464;

    public string ErrorText(int Error)
    {
      switch (Error)
      {
        case 0:
          return "OK";
        case 1:
          return "SYS: Error creating the Socket";
        case 2:
          return "TCP: Connection Timeout";
        case 3:
          return "TCP: Connection Error";
        case 4:
          return "TCP: Data receive Timeout";
        case 5:
          return "TCP: Error receiving Data";
        case 6:
          return "TCP: Data send Timeout";
        case 7:
          return "TCP: Error sending Data";
        case 8:
          return "TCP: Connection reset by the Peer";
        case 9:
          return "CLI: Client not connected";
        case 9999:
          return "Input value error";
        case 10065:
          return "TCP: Unreachable host";
        case 65536:
          return "ISO: Connection Error";
        case 196608:
          return "ISO: Invalid PDU received";
        case 262144:
          return "ISO: Invalid Buffer passed to Send/Receive";
        case 1048576:
          return "CLI: Error in PDU negotiation";
        case 2097152:
          return "CLI: Invalid param(s) supplied";
        case 3145728:
          return "CLI: Job pending";
        case 4194304:
          return "CLI: Too many items (>20) in multi read/write";
        case 5242880:
          return "CLI: Invalid WordLength";
        case 6291456:
          return "CLI: Partial data written";
        case 7340032:
          return "CPU: Total data exceeds the PDU size";
        case 8388608:
          return "CLI: Invalid CPU answer";
        case 9437184:
          return "CPU: Address out of range";
        case 10485760:
          return "CPU: Invalid Transport size";
        case 11534336:
          return "CPU: Data size mismatch";
        case 12582912:
          return "CPU: Item not available";
        case 13631488:
          return "CPU: Invalid value supplied";
        case 14680064:
          return "CPU: Cannot start PLC";
        case 15728640:
          return "CPU: PLC already RUN";
        case 16777216:
          return "CPU: Cannot stop PLC";
        case 17825792:
          return "CPU: Cannot copy RAM to ROM";
        case 18874368:
          return "CPU: Cannot compress";
        case 19922944:
          return "CPU: PLC already STOP";
        case 20971520:
          return "CPU: Function not available";
        case 22020096:
          return "CPU: Upload sequence failed";
        case 23068672:
          return "CLI: Invalid data size received";
        case 24117248:
          return "CLI: Invalid block type";
        case 25165824:
          return "CLI: Invalid block number";
        case 26214400:
          return "CLI: Invalid block size";
        case 30408704:
          return "CPU: Function not authorized for current protection level";
        case 31457280:
          return "CPU: Invalid password";
        case 32505856:
          return "CPU: No password to set or clear";
        case 33554432:
          return "CLI: Job Timeout";
        case 34603008:
          return "CLI: Partial data read";
        case 35651584:
          return "CLI: The buffer supplied is too small to accomplish the operation";
        case 36700160:
          return "CLI: Function refused by CPU (Unknown error)";
        case 37748736:
          return "CLI: Cannot perform (destroying)";
        case 38797312:
          return "CLI: Invalid Param Number";
        case 39845888:
          return "CLI: Cannot change this param now";
        case 40894464:
          return "CLI: Function not implemented";
        default:
          return "CLI: Unknown error (0x" + Convert.ToString(Error, 16) + ")";
      }
    }

    public int LastError() => this._LastError;

    public int RequestedPduLength() => this._PduSizeRequested;

    public int NegotiatedPduLength() => this._PDULength;

    public int ExecTime() => this.Time_ms;

    public int ExecutionTime => this.Time_ms;

    public int PduSizeNegotiated => this._PDULength;

    public int PduSizeRequested
    {
      get => this._PduSizeRequested;
      set
      {
        if (value < S7Client.MinPduSizeToRequest)
          value = S7Client.MinPduSizeToRequest;
        if (value > S7Client.MaxPduSizeToRequest)
          value = S7Client.MaxPduSizeToRequest;
        this._PduSizeRequested = value;
      }
    }

    public int PLCPort
    {
      get => this._PLCPort;
      set => this._PLCPort = value;
    }

    public int ConnTimeout
    {
      get => this.Socket.ConnectTimeout;
      set => this.Socket.ConnectTimeout = value;
    }

    public int RecvTimeout
    {
      get => this.Socket.ReadTimeout;
      set => this.Socket.ReadTimeout = value;
    }

    public int SendTimeout
    {
      get => this.Socket.WriteTimeout;
      set => this.Socket.WriteTimeout = value;
    }

    public bool Connected => this.Socket != null && this.Socket.Connected;

    public void Add(string name, string variable, S7Type types)
    {
      PLCAddress plcAddress = new PLCAddress(variable, types);
      this.List.Add(name, new Sharp7.List(plcAddress.S7Area, plcAddress.DBNumber, plcAddress.Start, plcAddress.Size, plcAddress.S7Type, plcAddress.Butter, plcAddress.S7WordLength));
    }

    public void Add(object SourceClass, string DBName, S7Area s7area, int DBNumber, int Start = 0)
    {
      Decimal d = (Decimal) Start + 0.0M;
      string empty = string.Empty;
      string str = string.Empty;
      switch (s7area)
      {
        case S7Area.PE:
          str = "I";
          break;
        case S7Area.PA:
          str = "O";
          break;
        case S7Area.MK:
          str = "M";
          break;
        case S7Area.DB:
          str = "D" + DBNumber.ToString() + ".";
          break;
      }
      foreach (PropertyInfo property in SourceClass.GetType().GetProperties())
      {
        switch (property.PropertyType.ToString())
        {
          case "System.Boolean":
            this.Add(DBName + "." + property.Name, str + d.ToString(), S7Type.Bit);
            d += 0.1M;
            if (d - Math.Truncate(d) > 0.7M)
            {
              d = Math.Truncate(d) + 1.0M;
              break;
            }
            break;
          case "System.Byte":
            if (d % 1.0M != 0.0M)
              d = Math.Truncate(d) + 1.0M;
            this.Add(DBName + "." + property.Name, str + d.ToString().Split('.')[0], S7Type.Byte);
            d += 1.0M;
            break;
          case "System.Double":
            if (d % 2.0M != 0.0M)
              d = !(Math.Truncate(d) % 2.0M != 0.0M) ? Math.Truncate(d) + 2.0M : Math.Truncate(d) + 1.0M;
            this.Add(DBName + "." + property.Name, str + d.ToString().Split('.')[0], S7Type.LReal);
            d += 8.0M;
            break;
          case "System.Int16":
            if (d % 2.0M != 0.0M)
              d = !(Math.Truncate(d) % 2.0M != 0.0M) ? Math.Truncate(d) + 2.0M : Math.Truncate(d) + 1.0M;
            this.Add(DBName + "." + property.Name, str + d.ToString().Split('.')[0], S7Type.Int);
            d += 2.0M;
            break;
          case "System.Int32":
            if (d % 2.0M != 0.0M)
              d = !(Math.Truncate(d) % 2.0M != 0.0M) ? Math.Truncate(d) + 2.0M : Math.Truncate(d) + 1.0M;
            this.Add(DBName + "." + property.Name, str + d.ToString().Split('.')[0], S7Type.DInt);
            d += 4.0M;
            break;
          case "System.Int64":
            if (d % 2.0M != 0.0M)
              d = !(Math.Truncate(d) % 2.0M != 0.0M) ? Math.Truncate(d) + 2.0M : Math.Truncate(d) + 1.0M;
            this.Add(DBName + "." + property.Name, str + d.ToString().Split('.')[0], S7Type.LInt);
            d += 8.0M;
            break;
          case "System.Single":
            if (d % 2.0M != 0.0M)
              d = !(Math.Truncate(d) % 2.0M != 0.0M) ? Math.Truncate(d) + 2.0M : Math.Truncate(d) + 1.0M;
            this.Add(DBName + "." + property.Name, str + d.ToString().Split('.')[0], S7Type.Real);
            d += 4.0M;
            break;
          case "System.UInt16":
            if (d % 2.0M != 0.0M)
              d = !(Math.Truncate(d) % 2.0M != 0.0M) ? Math.Truncate(d) + 2.0M : Math.Truncate(d) + 1.0M;
            this.Add(DBName + "." + property.Name, str + d.ToString().Split('.')[0], S7Type.Word);
            d += 2.0M;
            break;
          case "System.UInt32":
            if (d % 2.0M != 0.0M)
              d = !(Math.Truncate(d) % 2.0M != 0.0M) ? Math.Truncate(d) + 2.0M : Math.Truncate(d) + 1.0M;
            this.Add(DBName + "." + property.Name, str + d.ToString().Split('.')[0], S7Type.DWord);
            d += 4.0M;
            break;
          case "System.UInt64":
            if (d % 2.0M != 0.0M)
              d = !(Math.Truncate(d) % 2.0M != 0.0M) ? Math.Truncate(d) + 2.0M : Math.Truncate(d) + 1.0M;
            this.Add(DBName + "." + property.Name, str + d.ToString().Split('.')[0], S7Type.LWord);
            d += 8.0M;
            break;
        }
      }
    }

    private void Add()
    {
      foreach (KeyValuePair<string, Sharp7.Tag> keyValuePair in this.Tag)
      {
        PLCAddress plcAddress = new PLCAddress(this.Package[keyValuePair.Key.Split('.')[0]].s7area, this.Package[keyValuePair.Key.Split('.')[0]].dbnumber, keyValuePair.Value.address, keyValuePair.Value.s7type);
        this.List.Add(keyValuePair.Key, new Sharp7.List(plcAddress.S7Area, plcAddress.DBNumber, plcAddress.Start, plcAddress.Size, plcAddress.S7Type, plcAddress.Butter, plcAddress.S7WordLength));
      }
    }

    private void RegisterXml(string filename)
    {
      XmlDocument xmlDocument = new XmlDocument();
      new XmlReaderSettings().IgnoreComments = true;
      xmlDocument.Load(filename);
      XmlNodeList childNodes = xmlDocument.SelectSingleNode("Data").ChildNodes;
      object obj = (object) null;
      foreach (XmlElement xmlElement in childNodes)
      {
        S7Area S7area;
        switch (xmlElement.GetAttribute("s7area"))
        {
          case "D":
          case "DB":
            S7area = S7Area.DB;
            break;
          case "E":
          case "I":
            S7area = S7Area.PE;
            break;
          case "M":
            S7area = S7Area.MK;
            break;
          case "O":
          case "Q":
            S7area = S7Area.PA;
            break;
          default:
            S7area = S7Area.DB;
            break;
        }
        this.Package.Add(xmlElement.GetAttribute("name"), new Sharp7.Package(int.Parse(xmlElement.GetAttribute("dbnumber")), S7area, int.Parse(xmlElement.GetAttribute("startAddress")), int.Parse(xmlElement.GetAttribute("lenght")), new byte[int.Parse(xmlElement.GetAttribute("lenght"))]));
        foreach (XmlElement childNode in xmlElement.ChildNodes)
        {
          S7Type S7Type;
          switch (childNode.GetAttribute("type"))
          {
            case "bool":
              S7Type = S7Type.Bit;
              break;
            case "byte":
              S7Type = S7Type.Byte;
              break;
            case "dint":
              S7Type = S7Type.DInt;
              break;
            case "dword":
              S7Type = S7Type.DWord;
              break;
            case "int":
              S7Type = S7Type.Int;
              break;
            case "lint":
              S7Type = S7Type.LInt;
              break;
            case "lreal":
              S7Type = S7Type.LReal;
              break;
            case "lword":
              S7Type = S7Type.LWord;
              break;
            case "real":
              S7Type = S7Type.Real;
              break;
            case "word":
              S7Type = S7Type.Word;
              break;
            default:
              S7Type = S7Type.Byte;
              break;
          }
          this.Tag.Add(xmlElement.GetAttribute("name") + "." + childNode.GetAttribute("number"), new Sharp7.Tag(S7Type, Decimal.Parse(childNode.GetAttribute("address")), obj, childNode.GetAttribute("name")));
        }
      }
      this.Add();
    }

    public void Read()
    {
      if (this.Package.Count == 0)
        return;
      foreach (KeyValuePair<string, Sharp7.Package> keyValuePair in this.Package)
      {
        this.Package[keyValuePair.Key].status = this.ReadArea(this.Package[keyValuePair.Key].s7area, this.Package[keyValuePair.Key].dbnumber, this.Package[keyValuePair.Key].startaddress, this.Package[keyValuePair.Key].lenght, S7WordLength.Byte, this.Package[keyValuePair.Key].buff);
        if (!this.Connected || this.Package[keyValuePair.Key].status != 0)
          Array.Clear((Array) this.Package[keyValuePair.Key].buff, 0, this.Package[keyValuePair.Key].buff.Length);
      }
      Decimal num;
      foreach (KeyValuePair<string, Sharp7.Tag> keyValuePair in this.Tag)
      {
        switch (this.Tag[keyValuePair.Key].s7type)
        {
          case S7Type.Bit:
            Sharp7.Tag tag1 = this.Tag[keyValuePair.Key];
            byte[] buff1 = this.Package[keyValuePair.Key.Split('.')[0]].buff;
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int pos1 = int.Parse(num.ToString().Split('.')[0]);
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int bit = int.Parse(num.ToString().Split('.')[1]);
                        // ISSUE: variable of a boxed type
           var bitAt = (ValueType) buff1.GetBitAt(pos1, bit);
            tag1.value = bitAt;
            break;
          case S7Type.Byte:
            Sharp7.Tag tag2 = this.Tag[keyValuePair.Key];
            byte[] buff2 = this.Package[keyValuePair.Key.Split('.')[0]].buff;
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int pos2 = int.Parse(num.ToString());
            // ISSUE: variable of a boxed type
            var byteAt = (ValueType) buff2.GetByteAt(pos2);
            tag2.value = (object) byteAt;
            break;
          case S7Type.Word:
            Sharp7.Tag tag3 = this.Tag[keyValuePair.Key];
            byte[] buff3 = this.Package[keyValuePair.Key.Split('.')[0]].buff;
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int pos3 = int.Parse(num.ToString());
                        // ISSUE: variable of a boxed type
            var wordAt = (ValueType) buff3.GetWordAt(pos3);
            tag3.value = (object) wordAt;
            break;
          case S7Type.Int:
            Sharp7.Tag tag4 = this.Tag[keyValuePair.Key];
            byte[] buff4 = this.Package[keyValuePair.Key.Split('.')[0]].buff;
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int pos4 = int.Parse(num.ToString());
                        // ISSUE: variable of a boxed type
            var intAt = (ValueType) (short) buff4.GetIntAt(pos4);
            tag4.value = (object) intAt;
            break;
          case S7Type.DWord:
            Sharp7.Tag tag5 = this.Tag[keyValuePair.Key];
            byte[] buff5 = this.Package[keyValuePair.Key.Split('.')[0]].buff;
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int pos5 = int.Parse(num.ToString());
                        // ISSUE: variable of a boxed type
            var dwordAt = (ValueType) buff5.GetDWordAt(pos5);
            tag5.value = (object) dwordAt;
            break;
          case S7Type.DInt:
            Sharp7.Tag tag6 = this.Tag[keyValuePair.Key];
            byte[] buff6 = this.Package[keyValuePair.Key.Split('.')[0]].buff;
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int pos6 = int.Parse(num.ToString());
                        // ISSUE: variable of a boxed type
            var dintAt = (ValueType) buff6.GetDIntAt(pos6);
            tag6.value = (object) dintAt;
            break;
          case S7Type.Real:
            Sharp7.Tag tag7 = this.Tag[keyValuePair.Key];
            byte[] buff7 = this.Package[keyValuePair.Key.Split('.')[0]].buff;
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int pos7 = int.Parse(num.ToString());
                        // ISSUE: variable of a boxed type
            var realAt = (ValueType) buff7.GetRealAt(pos7);
            tag7.value = (object) realAt;
            break;
          case S7Type.LReal:
            Sharp7.Tag tag8 = this.Tag[keyValuePair.Key];
            byte[] buff8 = this.Package[keyValuePair.Key.Split('.')[0]].buff;
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int pos8 = int.Parse(num.ToString());
                        // ISSUE: variable of a boxed type
            var lrealAt = (ValueType) buff8.GetLRealAt(pos8);
            tag8.value = (object) lrealAt;
            break;
          case S7Type.LWord:
            Sharp7.Tag tag9 = this.Tag[keyValuePair.Key];
            byte[] buff9 = this.Package[keyValuePair.Key.Split('.')[0]].buff;
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int pos9 = int.Parse(num.ToString());
                        // ISSUE: variable of a boxed type
            var lwordAt = (ValueType) buff9.GetLWordAt(pos9);
            tag9.value = (object) lwordAt;
            break;
          case S7Type.LInt:
            Sharp7.Tag tag10 = this.Tag[keyValuePair.Key];
            byte[] buff10 = this.Package[keyValuePair.Key.Split('.')[0]].buff;
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int pos10 = int.Parse(num.ToString());
                        // ISSUE: variable of a boxed type
            var lintAt = (ValueType) buff10.GetLIntAt(pos10);
            tag10.value = (object) lintAt;
            break;
          case S7Type.DateTime:
            Sharp7.Tag tag11 = this.Tag[keyValuePair.Key];
            byte[] buff11 = this.Package[keyValuePair.Key.Split('.')[0]].buff;
            num = this.Tag[keyValuePair.Key].address - (Decimal) this.Package[keyValuePair.Key.Split('.')[0]].startaddress;
            int pos11 = int.Parse(num.ToString());
                        // ISSUE: variable of a boxed type
            var dateTimeAt = (ValueType) buff11.GetDateTimeAt(pos11);
            tag11.value = (object) dateTimeAt;
            break;
        }
      }
    }

    public struct S7DataItem
    {
      public int Area;
      public int WordLen;
      public int Result;
      public int DBNumber;
      public int Start;
      public int Amount;
      public IntPtr pData;
    }

    public struct S7OrderCode
    {
      public string Code;
      public byte V1;
      public byte V2;
      public byte V3;
    }

    public struct S7CpuInfo
    {
      public string ModuleTypeName;
      public string SerialNumber;
      public string ASName;
      public string Copyright;
      public string ModuleName;
    }

    public struct S7CpInfo
    {
      public int MaxPduLength;
      public int MaxConnections;
      public int MaxMpiRate;
      public int MaxBusRate;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct S7BlocksList
    {
      public int OBCount;
      public int FBCount;
      public int FCCount;
      public int SFBCount;
      public int SFCCount;
      public int DBCount;
      public int SDBCount;
    }

    public struct S7BlockInfo
    {
      public int BlkType;
      public int BlkNumber;
      public int BlkLang;
      public int BlkFlags;
      public int MC7Size;
      public int LoadSize;
      public int LocalData;
      public int SBBLength;
      public int CheckSum;
      public int Version;
      public string CodeDate;
      public string IntfDate;
      public string Author;
      public string Family;
      public string Header;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SZL_HEADER
    {
      public ushort LENTHDR;
      public ushort N_DR;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct S7SZL
    {
      public S7Client.SZL_HEADER Header;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
      public byte[] Data;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct S7SZLList
    {
      public S7Client.SZL_HEADER Header;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8190)]
      public ushort[] Data;
    }

    public struct S7Protection
    {
      public ushort sch_schal;
      public ushort sch_par;
      public ushort sch_rel;
      public ushort bart_sch;
      public ushort anl_sch;
    }

    public delegate void S7CliCompletion(IntPtr usrPtr, int opCode, int opResult);
  }
}
