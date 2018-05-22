using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shapes;
using ContextMenu = System.Windows.Forms.ContextMenu;
using MenuItem = System.Windows.Forms.MenuItem;

namespace CommonUtils {

    public class CMD {
        Process p;  //创建并实例化一个操作进程的类：Process 
        string strOutput;
        public CMD() {
            p = new Process();
            p.StartInfo.FileName = "cmd.exe";    //设置要启动的应用程序  
            p.StartInfo.UseShellExecute = false;   //设置是否使用操作系统shell启动进程  
            p.StartInfo.RedirectStandardInput = true;  //指示应用程序是否从StandardInput流中读取  
            p.StartInfo.RedirectStandardOutput = true; //将应用程序的输入写入到StandardOutput流中  
            p.StartInfo.RedirectStandardError = true;  //将应用程序的错误输出写入到StandarError流中  
            p.StartInfo.CreateNoWindow = true;    //是否在新窗口中启动进程  
            strOutput = null;
        }
        public string execute(string str) {
            try {
                p.Start();
                p.StandardInput.WriteLine(str);    //将CMD命令写入StandardInput流中  
                //p.WaitForExit();                           //无限期等待，直至进程退出 
                p.Close();
            }
            catch (Exception e) {
                strOutput = e.Message;
            }
            return strOutput;
        }
        public void closeCMD() {
            //p.StandardInput.WriteLine("exit");         //将 exit 命令写入StandardInput流中  
            //strOutput = p.StandardOutput.ReadToEnd();   //读取所有输出的流的所有字符  
            p.Close();                                  //释放进程，关闭进程  
        }
    }
}
