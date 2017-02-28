using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace com.rungine.toolkit.Views
{
    /// <summary>
    /// HeaderView.xaml 的交互逻辑
    /// </summary>
    public partial class HeaderView : UserControl
    {
        public HeaderView()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void btnMaxWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowOperation.FullOrMin(Application.Current.MainWindow);
        }

        private void btnMinWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void gridTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.DragMove();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public static class WindowOperation
    {
        public static void FullOrMin(this Window window)
        {
            //如果是全屏,则最小化
            if (window.WindowState == WindowState.Maximized)
            {
                window.Topmost = false;
                window.WindowState = WindowState.Normal;
                window.WindowStyle = WindowStyle.None;

                window.ResizeMode = ResizeMode.CanResizeWithGrip;//设置为可调整窗体大小
                window.Width = 800;
                window.Height = 600;

                //获取窗口句柄 
                var handle = new WindowInteropHelper(window).Handle;

                window.WindowState = WindowState.Normal;
                window.MinHeight = 200;
                window.MinWidth = 250;
                return;
            }

            //如果是窗口,则全屏
            if (window.WindowState == WindowState.Normal)
            {
                //变成无边窗体
                window.WindowState = WindowState.Normal;//假如已经是Maximized，就不能进入全屏，所以这里先调整状态
                window.WindowStyle = WindowStyle.None;
                window.ResizeMode = ResizeMode.NoResize;
                window.Topmost = true;//最大化后总是在最上面
                //获取窗口句柄 
                var handle = new WindowInteropHelper(window).Handle;
                window.WindowState = WindowState.Maximized;
            }

        }

        static void window_Deactivated(object sender, EventArgs e)
        {
            var window = sender as Window;
            window.Topmost = false;
        }

        static void window_Activated(object sender, EventArgs e)
        {
            var window = sender as Window;
            window.Topmost = true;
        }
    }
}
