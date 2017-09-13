using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    class Program
    {
        static  void Main(string[] args)
        {
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("{0,25}", filePath);

            Process.Start("D:\\项目\\我的测试项目\\2017test\\IO\\bin\\Debug\\a.txt");


            #region 远程连接新建文件

            //if (connectState())
            //{
            //    string newpath = System.IO.Path.GetFullPath(@"////172.16.42.64//d$//共享//bianma.txt");
            //    Console.WriteLine(newpath);
            //    FileStream file = File.Open(newpath, FileMode.Create);
            //    string str = "wmy";
            //    byte[] buffer = System.Text.Encoding.Default.GetBytes(str);

            //    file.Write(buffer, 0, buffer.Length);
            //    Console.WriteLine(str);
            //    file.Close();

            //} 
            #endregion
            Console.Read();
        }

        //建立远程连接
        public static bool connectState()
        {
            bool Flag = false;
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                //远程连接地址和用户名，密码
                string ip = System.Configuration.ConfigurationManager.AppSettings["ip"];
                string user = System.Configuration.ConfigurationManager.AppSettings["user"];
                string pwd = System.Configuration.ConfigurationManager.AppSettings["pwd"];
                string dosLine = @"net use \\"+ip+@"\d$\共享 "+pwd+@" /user:"+ip+@"\"+user;
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return Flag;
        }
    }
}
