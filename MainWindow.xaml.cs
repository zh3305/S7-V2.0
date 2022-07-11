using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sharp7;
using System.Threading;

namespace S7小助手V2._0
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        S7Client Plc;
        Thread DataRefresh;//新建一个线程刷新值和判断plc是否在线
        System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();//计算更新耗时用
        ViewMode viewmode = new ViewMode();
        int rack;
        int slot;
        public MainWindow()
        {
            InitializeComponent();
            //加载XML文件
            Plc = new S7Client(System.IO.Path.Combine(Environment.CurrentDirectory, "PlcTag.xml"));
            //PDU大小为默认为480，1500为960，1200、300为240，400为480，此处用1500测试设置960
            Plc.PduSizeRequested = 960;
            //设置为基本连接
            Plc.SetConnectionType(3);
            Load(Plc.Tag);
           
        }
        /// <summary>
        /// 把数据加载到Listview显示
        /// </summary>
        /// <param name="Tag"></param>
        private void Load(Dictionary<string,Tag> Tag)
        {
            foreach (KeyValuePair<string, Tag> item in Tag)
            {
                //把Tag的值加载到Listview
                viewmode.VimeAdd(item.Key, item.Value.name, item.Value.s7type.ToString());
            }
            Number.Text = viewmode.Lst_bind.Count.ToString();
            this.DataContext = viewmode;
          
        }
        /// <summary>
        /// 刷新值
        /// </summary>
        private void Read()
        {
            while (true)
            {
                Stopwatch.Start();
                int status = 0;
                if (Plc.Connected)
                {
                    //读取值
                    Plc.Read();                   
                    int j = 0;
                    foreach (KeyValuePair<string, Tag> item in Plc.Tag)
                    {
                        //把值更新到界面
                        viewmode.Lst_bind[j].Value = item.Value.value.ToString();
                        j++;
                    }
                }
                else
                {
                    //断线重连
                    sign();
                }
                Stopwatch.Stop();

                this.Dispatcher.Invoke((Action)delegate ()
                {
                    //刷新耗时
                    T.Text = Stopwatch.ElapsedMilliseconds.ToString();
                    //plc状态显示
                    if (Plc.PlcGetStatus(ref status)==0)
                    {
                        switch (status)
                        {
                            case 4 :
                                Status.Text = "Stop";
                                break;
                            case 8:
                                Status.Text = "Run";
                                break;
                            default:
                                Status.Text = "未知";
                                break;
                        }
                    }
                    else
                    {
                        Status.Text = "离线";
                    }
                  
                });
               
                Stopwatch.Reset();
                //刷新周期500ms
               Thread.Sleep(500);
            }
        }
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Rack.Text.Replace(" ",""),out rack)&& int.TryParse(Slot.Text.Replace(" ", ""), out slot))
            {
                Plc.PduSizeRequested = 960;
                int status=  Plc.ConnectTo(Ip.Text.Replace(" ", ""), rack, slot);        
                if (status==0)
                {
                    Close.IsEnabled = true;
                    Open.IsEnabled = false;
                    Ip.IsEnabled = false;
                    Rack.IsEnabled = false;
                    Slot.IsEnabled = false;
                    DataRefresh = new Thread(new ThreadStart(Read));
                    DataRefresh.IsBackground = true;
                    DataRefresh.Start();
                }
                else
                {
                    MessageBox.Show("连接失败"+Plc.ErrorText(status));
                }
            }
            else
            {
                MessageBox.Show("请检查连接参数");
            }
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
    
            if (Open.IsEnabled == false)
            {
                Plc.PlcStop();
                DataRefresh.Abort();
                ThreadState aaa = DataRefresh.ThreadState;
                Stopwatch.Reset();
                Status.Text = "未知";
                this.Dispatcher.Invoke((Action)delegate ()
                {
                    T.Text = "0";
                });
                if (Plc.Disconnect() == 0)
                {
                    Close.IsEnabled = !true;
                    Open.IsEnabled = Ip.IsEnabled = Rack.IsEnabled = Slot.IsEnabled = true;
                }
            }
        }
        /// <summary>
        /// 断线重连
        /// </summary>
        private void sign()
        {  
                if (Plc.Connected == false)
                {
                this.Dispatcher.Invoke((Action)delegate ()
                {
                    Plc.ConnectTo(Ip.Text.Replace(" ", ""), rack, slot);
                });
            }
                Thread.Sleep(3000);
        }
        /// <summary>
        /// 写入值
        /// </summary>
        /// <param name="data"></param>
        private void Write(ref string data)
        {
            User Title = hostlist.SelectedValue as User;
            data = Plc.ErrorText(Plc.Write(Title.Tag, data));          
        }
        /// <summary>
        /// 双击鼠标修改值或者删除不需要监控的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hostlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (hostlist.SelectedValue != null)
            {
                User Title = hostlist.SelectedValue as User;
                int Index = hostlist.Items.IndexOf(Title);
                try
                {
                    //连接plc后双击鼠标修改值，断开连接后双击鼠标删除不需要的选项
                    if (Plc.Connected)
                    {
                        //plc在线时如果选中的修改项数据类型为布尔量，则直接取反，不会弹出修改值窗口
                        if (Title.Type == "Bit")
                        {
                            if (Title.Value == "True")
                            {
                                Plc.Write(Title.Tag, 0);
                            }
                            else
                            {
                                Plc.Write(Title.Tag, 1);
                            }

                        }
                        else
                        {
                            //弹出修改值窗口
                            var win = new SonFrom(Write);
                            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            win.Owner = this;
                            win.ShowDialog();
                        }

                    }
                    else
                    {
                        //删除项的方法
                        viewmode.VimeSub(Index);
                        Plc.Tag.Remove(Title.Tag);
                        Number.Text = hostlist.Items.Count.ToString();
                    }
                }
                catch (Exception)
                {


                }


            }
        }
    }
}
