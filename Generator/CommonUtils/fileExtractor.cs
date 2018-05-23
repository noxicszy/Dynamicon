using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace CommonUtils {

    public class fileExtractor {

        String path;
        String WorkDirectory = System.IO.Directory.GetCurrentDirectory();
        StreamWriter sw = null;
        public fileExtractor() {

            try
            {
                FileStream fs;
                //创建输出流，将得到文件名子目录名保存到txt中
                if (!System.IO.File.Exists("my_app\\iconList.txt"))
                {
                    fs = new FileStream("my_app\\iconList.txt", FileMode.CreateNew);
                    sw = new StreamWriter(fs);
                }
                else
                    sw = new StreamWriter(new FileStream("my_app\\iconList.txt", FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("##############");
            }
        }

        IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();

        public void getDesktopFile() {
            //获取桌面图标
            path = "C:\\Users\\";
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo d in root.GetDirectories()) {
                if (d.Name == "All Users" || d.Name == "Public" || d.Name == "Default User" || d.Name == "Default" || d.Name == "defaultuser0") continue;
                path = path + d.Name + "\\";
                break;
            }
            path = path + "Desktop\\";
            DirectoryInfo rootEx = new DirectoryInfo(path);
            //遍历桌面文件
            foreach (FileInfo f in rootEx.GetFiles()) {
                Image img;
                string filePath = path + f.Name;

                img = System.Drawing.Icon.ExtractAssociatedIcon(filePath).ToBitmap();
                //提取图片
                try
                {
                    img.Save(WorkDirectory + "\\my_app\\images\\icons\\" + f.Name + ".jpg");
                }
                catch (Exception)
                {
                    Console.WriteLine("image saving error!");
                }
                //写入文件信息:文件名\t桌面路径\t实际路径
                try
                {
                    //文件名
                    sw.Write(f.Name + '\t');
                    //桌面路径
                    sw.Write(filePath + '\t');
                    //实际路径(对于非快捷方式,路径同桌面路径)
                    if (f.Name.Contains("lnk"))
                    {
                        IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(filePath);
                        sw.WriteLine(shortcut.TargetPath);
                    }
                    else sw.WriteLine(filePath);
                }
                catch (Exception)
                {
                    Console.WriteLine("link saving error!");
                }
                
            }
            if (sw != null) sw.Close();
        }
    }
}
