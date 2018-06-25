using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils
{
    public class FileProcessor
    {
        private String str;
        private StreamReader sr;
        private StreamWriter sw;
        private String FilePath;
        static private String mode = "video";
        static private String lastVideoPath = "videos/background2.mp4";
        static private String lastPicPath = "./images/background.png";
        public FileProcessor(String filePath)
        {
            sr = new StreamReader(filePath);
            str = sr.ReadToEnd();
            sr.Close();
            FilePath = filePath;
            Console.WriteLine(str);
        }

        public void changeVideoPath(String ss) {
            ss = ss.Replace("\\", "/");
            String tmp = ss.Remove(0, ss.Length - 3);
            if (tmp == "jpg" || tmp == "png" || tmp == "bmp")
            {
                if (mode == "video")
                {
                    str = str.Replace("mode = \"video\"", "mode = \"image\"");
                    mode = "image";
                }
                str = str.Replace(lastPicPath, ss);
                sw = new StreamWriter(FilePath);
                sw.Write(str);
                sw.Close();
                Console.Write(str);
                lastPicPath = ss;
            }
            else
            {
                if (mode == "image")
                {
                    str = str.Replace("mode = \"image\"", "mode = \"video\"");
                    mode = "video";
                }
                str = str.Replace(lastVideoPath, ss);
                sw = new StreamWriter(FilePath);
                sw.Write(str);
                sw.Close();
                Console.WriteLine(str);
                lastVideoPath = ss;
            }

        }
    }
}
