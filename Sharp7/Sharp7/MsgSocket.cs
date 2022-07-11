// Decompiled with JetBrains decompiler
// Type: Sharp7.MsgSocket
// Assembly: Sharp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 02CEF60A-46C4-41DA-9A48-13BCB115154D
// Assembly location: D:\Desktop\Sharp7\S7小助手V2.0\bin\Debug\Sharp7.dll

using System;
using System.Net.Sockets;
using System.Threading;

namespace Sharp7
{
  internal class MsgSocket
  {
    private Socket TCPSocket;
    private int _ReadTimeout = 2000;
    private int _WriteTimeout = 2000;
    private int _ConnectTimeout = 1000;
    private int LastError;

    ~MsgSocket() => this.Close();

    public void Close()
    {
      if (this.TCPSocket == null)
        return;
      this.TCPSocket.Dispose();
      this.TCPSocket = (Socket) null;
    }

    private void CreateSocket()
    {
      this.TCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      this.TCPSocket.NoDelay = true;
    }

    private void TCPPing(string Host, int Port)
    {
      this.LastError = 0;
      Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      try
      {
        if (!socket.BeginConnect(Host, Port, (AsyncCallback) null, (object) null).AsyncWaitHandle.WaitOne(this._ConnectTimeout, true))
          this.LastError = 3;
      }
      catch
      {
        this.LastError = 3;
      }
      socket.Close();
    }

    public int Connect(string Host, int Port)
    {
      this.LastError = 0;
      if (!this.Connected)
      {
        this.TCPPing(Host, Port);
        if (this.LastError == 0)
        {
          try
          {
            this.CreateSocket();
            this.TCPSocket.Connect(Host, Port);
          }
          catch
          {
            this.LastError = 3;
          }
        }
      }
      return this.LastError;
    }

    private int WaitForData(int Size, int Timeout)
    {
      bool flag = false;
      int tickCount = Environment.TickCount;
      this.LastError = 0;
      try
      {
        int available = this.TCPSocket.Available;
        while (available < Size && !flag)
        {
          Thread.Sleep(2);
          available = this.TCPSocket.Available;
          flag = Environment.TickCount - tickCount > Timeout;
          if (flag && available > 0)
          {
            try
            {
              this.TCPSocket.Receive(new byte[available], 0, available, SocketFlags.None);
            }
            catch
            {
              this.LastError = 5;
            }
          }
        }
      }
      catch
      {
        this.LastError = 5;
      }
      if (flag)
        this.LastError = 5;
      return this.LastError;
    }

    public int Receive(byte[] Buffer, int Start, int Size)
    {
      int num = 0;
      this.LastError = this.WaitForData(Size, this._ReadTimeout);
      if (this.LastError == 0)
      {
        try
        {
          num = this.TCPSocket.Receive(Buffer, Start, Size, SocketFlags.None);
        }
        catch
        {
          this.LastError = 5;
        }
        if (num == 0)
        {
          this.LastError = 5;
          this.Close();
        }
      }
      return this.LastError;
    }

    public int Send(byte[] Buffer, int Size)
    {
      this.LastError = 0;
      try
      {
        this.TCPSocket.Send(Buffer, Size, SocketFlags.None);
      }
      catch
      {
        this.LastError = 7;
        this.Close();
      }
      return this.LastError;
    }

    public bool Connected => this.TCPSocket != null && this.TCPSocket.Connected;

    public int ReadTimeout
    {
      get => this._ReadTimeout;
      set => this._ReadTimeout = value;
    }

    public int WriteTimeout
    {
      get => this._WriteTimeout;
      set => this._WriteTimeout = value;
    }

    public int ConnectTimeout
    {
      get => this._ConnectTimeout;
      set => this._ConnectTimeout = value;
    }
  }
}
