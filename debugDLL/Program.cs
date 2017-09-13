using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace debugDLL
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            #region mfc调试
            int ss = 12;
            if (args.Length == 0) // 测试使用20170219
                                  // if (args.Length > 0) // 输入正确参数
            {
                args = new string[1];
                //  args[0] = "lgwebp://IResLib\\KJview\testInterface.exe#CD050370DA00DEAAA";              
                // args[0] = "lgwebp://IResLib\\KJview\\LGCourseware.exe#CE0706413A00MBAAA";

                // args[0] = " test#CE0604403A002BAAA|0|172.16.42.55|8088|Service12";
                args[0] = "lgwebp://IResLib\\KJview\\LGCourseware.exe#CC04000000000C0AG@172.16.42.55@8088@service12";
                // MessageBox.Show(args[0]);
                List<string> _argsArray = args[0].Split('#').LastOrDefault().Split('@').ToList(); // 分割字符串：找出知识点编码
                string klgNameCode = _argsArray[0]; // 获取知识点编码
                                                    // string callType = _argsArray[1]; // 参数类型
                string WSIp = _argsArray[1]; // IP
                string WSPort = _argsArray[2]; // Port
                string WSFileName = _argsArray[3]; // Port
                                                   //string klgname = args[0].Split('#').LastOrDefault();
                if (klgNameCode.Length > 0) // 知识点编码正确
                {
                    // EnglishPreViewWeb.CourseWare.SetInitWebServiceInfo(0, WSIp, WSPort, WSFileName);
                    // EnglishPreViewWeb.CourseWare.GetCoursewareFromCode_English(klgNameCode);
                    //G_SetWSConfigInfo(0,"172.16.42.55","8088", "Service12");             
                    int a =MFCDLL.G_SetWSConfigInfo(0, WSIp, WSPort, WSFileName);
                    int b = MFCDLL.G_EnglishKCPreView(klgNameCode);   // 根据编码调用对应的知识点课件   

                    // G_EnglishPreView("H");       // 根据版本调用对应的词典工具
                    
                    ss = ss + 4;
                    //  G_EnglishPreViewDestoryWindow();
                }
                else
                {
                    MessageBox.Show(klgNameCode + "：参数不正确！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("请传入正确的参数");
                return;
            }

            // G_EnglishPreViewDestoryWindow();
            Console.WriteLine(ss);
            Console.Read();


        #endregion

        #region dll调试
        //int x = CPPDLL.Add(10, 20);
        //Console.WriteLine(x);
        //Console.Read(); 
        #endregion

        // 调用课件
        // 配置WS信息


    }
    }
}
