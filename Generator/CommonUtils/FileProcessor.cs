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
        static private String lastPath = "videos/background2.mp4";
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
            str = str.Replace(lastPath, ss);
            sw = new StreamWriter(FilePath);
            sw.Write(str);
            sw.Close();
            Console.WriteLine(str);
            lastPath = ss;
        }
    }
}
