using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CommonUtils
{
    public class Run_Start
    {

        public Run_Start()
        {
        }

        public bool AutoRunAfterStart(string localPath)
        {

            RegistryKey HKCU = Registry.CurrentUser;
            RegistryKey Run = HKCU.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            try
            {
                Run.SetValue("WallpaperApp.exe", localPath);
                Run.Close();
                HKCU.Close();
                return true;
            }
            catch
            {
                return false;
            }
            

        }
        //删除注册表钟的特定值
        public bool DeleteSubKey()
        {
            RegistryKey HKCU = Registry.CurrentUser;
            RegistryKey Run = HKCU.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            try
            {
                //if (run == null)
                //    run = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");

                Run.DeleteValue("WallpaperApp.exe");
                Run.Close();
                HKCU.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        ///     检查当前程序是否在启动项中
        /// </summary>
        /// <returns></returns>
        public static bool CheckExistRegisterApp()
        {
            string ShortFileName = "WallpaperApp.exe";           //获得应用程序名
            bool bResult = false;

            try
            {
                Microsoft.Win32.RegistryKey Reg;
                Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (Reg == null)
                {
                    Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                }

                foreach (string s in Reg.GetValueNames())
                {
                    if (s.Equals(ShortFileName))
                    {
                        bResult = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return bResult;
        }
    }
}
