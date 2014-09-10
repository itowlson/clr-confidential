using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    public struct Point
    {
        private readonly int _x;
        private readonly int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public static void ValueEquality()
        {
            Point origin = new Point(0, 0);
            Point whereILive = new Point(0, 0);

            Console.WriteLine(origin.Equals(whereILive));

            var sw = Stopwatch.StartNew();

            for (int i = 0; i < 1000000; ++i)
            {
                origin.Equals(whereILive);
                //origin.GetHashCode();
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        //public override bool Equals(object obj)
        //{
        //    if (!(obj is Point))
        //    {
        //        return false;
        //    }

        //    Point other = (Point)obj;
        //    return X == other.X && Y == other.Y;
        //}

        //public override int GetHashCode()
        //{
        //    return X.GetHashCode() ^ Y.GetHashCode();
        //}

        public static void TestMemory()
        {
            var points = new Point[10000000];
            for (int i = 0; i < points.Length; ++i)
            {
                points[i] = new Point(0,0);
            }
            var approxMB = GC.GetTotalMemory(false) / 1000000;
            Console.WriteLine(approxMB);
            GC.KeepAlive(points);
        }
    }

    public struct EvilPoint
    {
        public int X { get; set; }  // Never do this
        public int Y { get; set; }  // Dammit, I just told you never to do this
    }
}
