using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Confidential
{
    public class EvilPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as EvilPerson;
            if (other == null)
            {
                return false;
            }

            return other.Id == Id && other.Name == Name;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Name.GetHashCode();
        }

        public static void HuntTheEvilPerson()
        {
            var evilPeopleDirectory = new Dictionary<EvilPerson, Address>();

            var bob = new EvilPerson { Id = 1, Name = "BOB" };
            var whereBobLives = new Address { Town = "Twin Peaks" };

            evilPeopleDirectory[bob] = whereBobLives;

            Console.WriteLine(evilPeopleDirectory[bob].Town);

            bob.Name = "<spoiler warning>";

            Console.WriteLine(evilPeopleDirectory[bob].Town);
        }
    }

    public class Address
    {
        public string Town { get; set; }
    }
}
