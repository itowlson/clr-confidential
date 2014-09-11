using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    public static class ExceptionTests
    {
        private static void ReticulateCore(object spline)
        {
            Console.WriteLine(spline.GetType());
        }

        public static void Reticulate(object spline)
        {
            Console.WriteLine("preparing to reticulate");

            try
            {
                ReticulateCore(spline);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("there is no spline");
                throw ex;
            }

            Console.WriteLine("reticulated");
        }

        public static void LoggedReticulate(object spline)
        {
            try
            {
                Reticulate(spline);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void MeasureExceptionPerformance()
        {
            int runCount = 5;
            int testCount = 2000000;

            for (int run = 0; run < runCount; ++run)
            {
                Stopwatch sw = Stopwatch.StartNew();

                int successCount = 0;
                for (int i = 0; i < testCount; ++i)
                {
                    try
                    {
                        if (DoMaybeFailyThing(i))
                        {
                            ++successCount;
                        }
                    }
                    catch (ArgumentException)
                    {
                    }
                }

                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
            }
        }

        private static bool DoMaybeFailyThing(int i)
        {
            // Pretend to do useful thing
            //System.IO.File.Exists(@"c:\temp\test.txt");
            if (i % 100 == 0)
            {
                return false;
                //throw new ArgumentException();
            }
            return true;
        }
    }
}
