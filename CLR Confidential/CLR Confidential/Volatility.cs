using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    public class Volatility
    {
        private volatile int _myVolatileInt = 123;
        private int[] _myVastCollectionOfVolatileInts = new int[1000];

        public int Read()
        {
            return _myVolatileInt;
        }

        public int ReadFromCollection(int index)
        {
            return Volatile.Read(ref _myVastCollectionOfVolatileInts[index]);
        }
    }
}
