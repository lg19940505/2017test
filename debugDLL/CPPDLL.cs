using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace debugDLL
{
    public class CPPDLL
    {
        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "Add", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int x, int y);

        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "Sub", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Sub(int x, int y);

        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "Multiply", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Multiply(int x, int y);

        [DllImport("CSharpInvokeCPP.dll", EntryPoint = "Divide", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
        public static extern int Divide(int x, int y);
    }
}
