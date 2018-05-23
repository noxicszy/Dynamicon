using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace CommonUtils {

    public class fileExtractor {

        String path;
        StreamWriter sw = null;
        public fileExtractor() {

            try {
                //创建输出流，将得到文件名子目录名保存到txt中
                sw = new StreamWriter(new FileStream("iconList.txt", FileMode.Append));
            }
            catch (IOException e) {
                Console.WriteLine(e.Message);
            }
        }

        IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();

        public void getDesktopFile() {
            //获取桌面图标
            String path = "C:\\Users\\";
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo d in root.GetDirectories()) {
                if (d.Name == "All Users" || d.Name == "Public" || d.Name == "Default User" || d.Name == "Default" || d.Name == "defaultuser0") continue;
                path = path + d.Name + "\\";
                break;
            }
            path = path + "Desktop\\";
            DirectoryInfo rootEx = new DirectoryInfo(path);
            foreach (FileInfo f in rootEx.GetFiles()) {
                string filePath = path + f.Name;
                if (f.Name.Contains("lnk")) {
                    IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(filePath);
                    sw.WriteLine(shortcut.TargetPath);
                }
                else sw.WriteLine(filePath);
            }
            if (sw != null) sw.Close();
        }
    }
}
