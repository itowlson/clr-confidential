using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    public static class Boxing
    {
        public static void CSharpCastNotation_Reference(object o)
        {
            var s = (string)o;
            Console.WriteLine(s);
        }

        public static void CSharpCastNotation_AutomaticValueConversion(int i)
        {
            var l = (long)i;
            Console.WriteLine(l);
        }

        public static void CSharpCastNotation_ObjectToValue(object o)
        {
            var i = (long)o;
            Console.WriteLine(i);
        }

        public static void CSharpCastNotation_Conversion(decimal d)
        {
            var i = (int)d;
            Console.WriteLine(i);
        }

        public static void SeriouslyIToldYouNeverEverToDoThis()
        {
            EvilPoint point = new EvilPoint { X = 1, Y = 2 };
            object o = point;
            dynamic point_ = o;

            Console.WriteLine(point.X + " / " + point_.X);

            point.X = 2;

            Console.WriteLine(point.X + " / " + point_.X);

            point_.X = 3;

            Console.WriteLine(point.X + " / " + point_.X);

            EvilPoint thatPointAgain = (EvilPoint)o;
            thatPointAgain.X = 4;

            Console.WriteLine(point.X + " / " + point_.X);

            typeof(EvilPoint)
                .GetProperty("X")
                .SetValue(point, 5);

            Console.WriteLine(point.X + " / " + point_.X);

            typeof(EvilPoint)
                .GetProperty("X")
                .SetValue(point_, 6);

            Console.WriteLine(point.X + " / " + point_.X);

            typeof(EvilPoint)
                .GetProperty("X")
                .SetValue(o, 7);

            Console.WriteLine(point.X + " / " + point_.X);
        }
    }

    public interface IX
    {
        int X { get; set; }
    }
}
