using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace debugDLL
{
     public  class MFCDLL
    {
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
