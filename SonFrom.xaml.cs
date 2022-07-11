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
using System.Windows.Shapes;
using System.Threading;

namespace S7小助手V2._0
{
    /// <summary>
    /// 申明委托
    /// </summary>
    /// <param name="z"></param>
    public delegate void DelTest(ref String Data);
    /// <summary>
    /// SonFrom.xaml 的交互逻辑
    /// </summary>
    public partial class SonFrom : Window
    {
        public DelTest OutData;
        public SonFrom(DelTest del)
        {
            this.OutData = del;
            InitializeComponent();
            Write.Focus();
        }
        /// <summary>
        /// 写入方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteButton_Click(object sender, RoutedEventArgs e)
        {
            refoutvalue.Text = "";
            string text = Write.Text;
            OutData(ref text);
            refoutvalue.Text = text;
            Write.Text = null;
            Write.Focus();
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 移动窗体事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                e.Handled = true;
                try
                {
                    //防止在WriteBox上移动窗口时报错
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.DragMove();//可移动窗口的方法
                    }));

                }
                catch (Exception)
                {


                }
            }
        }
        /// <summary>
        /// 鼠标右键关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            CloseButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
        /// <summary>
        /// Enter事件触发写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Write_KeyDown(object sender, KeyEventArgs e)
        {
            //判断是否由Enter键触发事件，如果是才执行WriteButton_Click事件
            if (Key.Enter == e.Key)
            {
                WriteButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }
}
