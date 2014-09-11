using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    public class StackTraceTests
    {
        public static void A()
        {
            try
            {
                new StackTraceTests().B();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void B()
        {
            Console.WriteLine(C);
        }

        public string C
        {
            get
            {
                Console.WriteLine("Getting C");
                string s = null;
                return s.Length.ToString();
            }
        }

        public static BigInteger Factorial(BigInteger i)
        {
            if (i == 0)
            {
                return 1;
            }
            return i * Factorial(i - 1);
        }

        public static BigInteger Factorial_(BigInteger i, BigInteger accumulator)
        {
            if (i == 0)
            {
                return accumulator;
            }
            //if (i == 19990)
            //{
            //    throw new Exception();
            //}
            return Factorial_(i - 1, accumulator * i);
        }

        public static bool IsOdd(int i)
        {
            if (i == 0)
            {
                return false;
            }
            return IsEven(i - 1);
        }

        public static bool IsEven(int i)
        {
            if (i == 0)
            {
                return true;
            }
            return IsOdd(i - 1);
        }
    }
}
