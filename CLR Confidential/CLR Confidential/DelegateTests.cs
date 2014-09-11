using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    public class DelegateTests
    {
        public delegate TResult MapD<TArg, TResult>(TArg arg);

        public abstract class MapC<TArg, TResult>
        {
            public abstract TResult Invoke(TArg arg);
        }

        public static void Compare()
        {
            MapD<int, int> mapd = Square;
            mapd(7);  // JIT
            MapC<int, int> mapc = new Squarer();
            mapc.Invoke(7);  // JIT

            int runCount = 5;
            int testCount = 50000000;

            for (int run = 0; run < runCount; ++run)
            {
                Stopwatch sw = Stopwatch.StartNew();

                for (int i = 0; i < testCount; ++i)
                {
                    mapd.Invoke(i % 1000);
                }

                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
            }
        }

        private static int Square(int i) { return i * i; }

        private class Squarer : MapC<int, int>
        {
            public override int Invoke(int arg)
            {
                return arg * arg;
            }
        }
    }
}
