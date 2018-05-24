using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using MahApps.Metro.Controls;
using WinWallpaper.Utils;
using CommonUtils;
using ContextMenu = System.Windows.Forms.ContextMenu;
using MenuItem = System.Windows.Forms.MenuItem;

namespace WallpaperApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private CommonUtils.CMD c = new CMD();
        CommonUtils.Run_Start p = new Run_Start();
        private CommonUtils.fileExtractor e = new fileExtractor();
        private static NotifyIcon trayIcon;
        private static NotifyIcon trayIconForNotice;
        private Icon ico = new System.Drawing.Icon("icon.ico");
        private static string Path = System.IO.Directory.GetCurrentDirectory();
        //uflags常数
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_NOZORDER = 0x0004;
        const UInt32 SWP_NOREDRAW = 0x0008;
        const UInt32 SWP_NOACTIVATE = 0x0010;
        const UInt32 SWP_FRAMECHANGED = 0x0020;
        const UInt32 SWP_SHOWWINDOW = 0x0040;
        const UInt32 SWP_HIDEWINDOW = 0x0080;
        const UInt32 SWP_NOCOPYBITS = 0x0100;
        const UInt32 SWP_NOOWNERZORDER = 0x0200;
        const UInt32 SWP_NOSENDCHANGING = 0x0400;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public MainWindow()
        {
            //分辨率获取
            System.Drawing.Rectangle rect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            int h = rect.Height; //高（像素）
            int w = rect.Width; //宽（像素）
            //提取桌面文件
            
            Console.WriteLine(Path);
            e.getDesktopFile();

            //运行electron窗口
            string cmdstr = Path + "\\electron-v2.0.1-win32-x64\\electron.exe " + Path + "\\my_app";
            //string cmdstr = "C:\\Users\\YongMao\\Desktop\\Dynamicon\\electron-v2.0.1-win32-x64\\electron.exe C:\\Users\\YongMao\\Desktop\\Dynamicon\\my_app";
            c.execute(cmdstr);
            IntPtr desktophandle = Win32.User32.GetDesktopWindow();
            IntPtr windowHandle2 = IntPtr.Zero;
            //抓取electron窗口句柄
            System.Threading.Thread.Sleep(1000);
            while (windowHandle2 == IntPtr.Zero)
                windowHandle2 = Win32.User32.FindWindow(null, "dynamicon");

            //抓取桌面层句柄
            IntPtr desktopHandle = Win32.User32.FindWindow("Progman", null);
            IntPtr zero;
            //生成一个WorkerW 顶级窗口 桌面列表会随之搬家
            Win32.User32.SendMessageTimeout(desktopHandle, 0x52c, new IntPtr(0), IntPtr.Zero, Win32.User32.SendMessageTimeoutFlags.SMTO_NORMAL, 0x3e8, out zero);
            IntPtr workerw = IntPtr.Zero;
            //消息会生成两个WorkerW 顶级窗口 所以要枚举不包含“SHELLDLL_DefView”这个的 WorkerW 窗口 隐藏掉。
            Win32.User32.EnumWindows(delegate (IntPtr tophandle, IntPtr topparamhandle)
            {
                if (Win32.User32.FindWindowEx(tophandle, IntPtr.Zero, "SHELLDLL_DefView", null) != IntPtr.Zero)
                {
                    workerw = Win32.User32.FindWindowEx(IntPtr.Zero, tophandle, "WorkerW", null);
                }
                return true;
            }, IntPtr.Zero);
            Win32.User32.ShowWindow(workerw, Win32.User32.SW_HIDE);
            Win32.User32.SetParent(windowHandle2, desktopHandle);
            //桌面层置顶
            Win32.User32.SetWindowPos(windowHandle2, IntPtr.Zero, 0, 0, w, h, TOPMOST_FLAGS);
            InitializeComponent();
            //AddTrayIcon();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddTrayIcon();
            AddTrayIconForNotice();
            this.Show();
        }

        private void EndTask() {

            if (trayIcon != null) {
                trayIcon.Visible = false;
                trayIcon.Dispose();
                trayIcon = null;
            }
            if (trayIconForNotice != null)
            {
                trayIconForNotice.Visible = false;
                trayIconForNotice.Dispose();
                trayIconForNotice = null;
            }
        }

        private void AddTrayIcon() {

            if (trayIcon != null) {
                return;
            }
            trayIcon = new NotifyIcon
            {
                Icon = Properties.Resources.icon,
                Text = "Dynamicon"
            };
            trayIcon.Visible = true;
            trayIcon.ShowBalloonTip(5000, "提示", "Dynamicon开始运行！", ToolTipIcon.Info);

            trayIcon.MouseClick += TrayIcon_MouseClick;

            ContextMenu menu = new ContextMenu();

            MenuItem closeItem4= new MenuItem();
            closeItem4.Text = "主界面";
            closeItem4.Click += new EventHandler(delegate
            {
                this.Show();
            });

            MenuItem closeItem3 = new MenuItem();
            closeItem3.Text = "设置";
            closeItem3.Click += new EventHandler(delegate
            {
                //function
            });

            MenuItem closeItem2 = new MenuItem();
            closeItem2.Text = "资源管理器";
            closeItem2.Click += new EventHandler(delegate
            {
                CommonUtils.CMD c = new CMD();
                c.execute("explorer.exe");
            });

            MenuItem closeItem = new MenuItem();
            closeItem.Text = "退出";
            closeItem.Click += new EventHandler(delegate
            {
                CommonUtils.CMD c = new CMD();
                c.execute("taskkill /im electron.exe /f");
                System.Threading.Thread.Sleep(2000);
                EndTask();
                Environment.Exit(0);
            });

            menu.MenuItems.Add(closeItem4);
            menu.MenuItems.Add(closeItem3);
            menu.MenuItems.Add(closeItem2);
            menu.MenuItems.Add(closeItem);
            trayIcon.ContextMenu = menu;//设置NotifyIcon的右键弹出菜单
        }

        private void AddTrayIconForNotice()
        {
            if (trayIconForNotice != null)
            {
                return;
            }
            trayIconForNotice = new NotifyIcon
            {
                Icon = Properties.Resources.icon,
                Text = "Dynamicon"
            };
            trayIconForNotice.Visible = false;
        }

        private void TrayIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Visibility = Visibility.Visible;
        }


        
        //-------------------------- 事件处理 -----------------------------

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //function
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
            trayIcon.ShowBalloonTip(5000, "提示", "Dynamicon已最小化！", ToolTipIcon.Info);
        }



        private void Exit_click(object sender, RoutedEventArgs e)
        {
            CommonUtils.CMD c = new CMD();
            c.execute("taskkill /im electron.exe /f");
            System.Threading.Thread.Sleep(2000);
            EndTask();
            Environment.Exit(0);
        }

        private void Setting_click(object sender, RoutedEventArgs e)
        {
            //function
        }

        private void btnFull_Checked(object sender, RoutedEventArgs e)
        {

            //System.Threading.Thread.Sleep(2000);
            bool success = p.AutoRunAfterStart(Path);
            if (trayIconForNotice == null) AddTrayIconForNotice();
            if (success) trayIconForNotice.ShowBalloonTip(5000, "提示", "已设置为开机自启动！", ToolTipIcon.Info);
            else trayIconForNotice.ShowBalloonTip(5000, "提示", "设置自启动失败，请以管理员身份运行！", ToolTipIcon.Info);

        }

        private void btnFull_Unchecked(object sender, RoutedEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            bool success = p.DeleteSubKey();
            if (trayIconForNotice == null) AddTrayIconForNotice();
            if (success) trayIconForNotice.ShowBalloonTip(5000, "提示", "已取消开机自启动！", ToolTipIcon.Info);
            else trayIconForNotice.ShowBalloonTip(5000, "提示", "设置自启动失败，请以管理员身份运行！", ToolTipIcon.Info);
        }

    }
}