using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    public interface IPantaloon
    {
        void Wear();
    }

    public interface IAbradable
    {
        void Wear();
    }

    public class IllMadeJeans : IPantaloon, IAbradable
    {
        public void Wear()  // public non-virtual
        {
            Console.WriteLine("IllMadeJeans.Wear");
        }

        void IPantaloon.Wear()  // private virtual
        {
            Console.WriteLine("IPantaloon.Wear");
        }

        void IAbradable.Wear()  // private virtual
        {
            Console.WriteLine("IAbradable.Wear");
        }
    }

    public class MisguidedTrousers : IPantaloon
    {
        public void Wear()  // public virtual final
        {
            throw new NotImplementedException();
        }
    }

}
