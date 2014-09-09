using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    public static class NonObjectTypes
    {
        public static void Int32Me(ref int i1, out int i2)
        {
            i2 = 0;
        }

        unsafe public static void Int32Me(int* pi)
        {
            *pi = 0;
        }
    }
}
