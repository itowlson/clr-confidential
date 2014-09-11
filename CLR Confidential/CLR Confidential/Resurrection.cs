using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    public class SelfTrackOMatic
    {
        public static SelfTrackOMatic LastFinalised;

        public SelfTrackOMatic()
        {
            Console.WriteLine("creating instance #" + GetHashCode());
        }

        ~SelfTrackOMatic()
        {
            Console.WriteLine("finalising instance #" + GetHashCode());
            if (!Environment.HasShutdownStarted)
            {
                LastFinalised = this;
                //GC.ReRegisterForFinalize(this);
            }
        }

        public static void TestResurrection()
        {
            for (int i = 0; i < 10; ++i)
            {
                new SelfTrackOMatic();
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine(LastFinalised.GetHashCode());
            LastFinalised = null;
            Console.WriteLine("re-collecting");
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

    }
}
