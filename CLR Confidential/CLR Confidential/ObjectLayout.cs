using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SomeInteropStruct
    {
        public int cbSize;
        public IntPtr cookie;
        public int width;
        public int height;
    }

    public static class ObjectLayoutTests
    {
        public static void StructInteropLayout()
        {
            Console.WriteLine(Marshal.SizeOf(typeof(SomeInteropStruct)));
        }
    }
}
