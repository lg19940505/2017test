using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__dll_Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
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
                    int a = G_SetWSConfigInfo(0, WSIp, WSPort, WSFileName);
                    int b = G_EnglishKCPreView(klgNameCode);   // 根据编码调用对应的知识点课件   

                    // G_EnglishPreView("H");       // 根据版本调用对应的词典工具
                    Form1 f = new Form1();
                    int ss = 12;
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
        }

        // 调用课件
        // 配置WS信息
        [DllImport(@"C:\Users\Administrator\Desktop\Code\Bin\EnglishPreview.dll", EntryPoint = "G_SetWSConfigInfo", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int G_SetWSConfigInfo(int nSetType, string pIP, string pPort, string pWsName);

        // 根据知识点编码调用知识点解析课件
        [DllImport(@"C:\Users\Administrator\Desktop\Code\Bin\EnglishPreview.dll", EntryPoint = "G_EnglishKCPreView", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int G_EnglishKCPreView(string KLname);

        // 根据版本编码调用调用词典
        [DllImport(@"C:\Users\Administrator\Desktop\Code\Bin\EnglishPreview.dll", EntryPoint = "G_EnglishPreView", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int G_EnglishPreView(string version);

        [DllImport(@"C:\Users\Administrator\Desktop\Code\Bin\EnglishPreview.dll", EntryPoint = "G_EnglishPreViewDestoryWindow", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern void G_EnglishPreViewDestoryWindow();

    }
}
