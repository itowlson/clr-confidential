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

    public struct ApproximateValue
    {
        private readonly double _estimate;
        private readonly double _epsilon;

        public ApproximateValue(double estimate, double epsilon)
        {
            _estimate = estimate;
            _epsilon = epsilon;
        }

        public override bool Equals(object obj)
        {
            if (obj is ApproximateValue)
            {
                var other = (ApproximateValue)obj;

                // no!  no!  no!
                var distance = Math.Abs(other._estimate - _estimate);

                return distance <= _epsilon;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _estimate.GetHashCode();
        }

        public static void Reprehensible()
        {
            var approx1 = new ApproximateValue(100.00315, 0.00007);
            var approx2 = new ApproximateValue(100.00319, 0.00003);
            var approx3 = new ApproximateValue(100.00321, 0.00005);

            Console.WriteLine("transitive?");
            Console.WriteLine(approx1.Equals(approx2));
            Console.WriteLine(approx2.Equals(approx3));
            Console.WriteLine(approx1.Equals(approx3));

            Console.WriteLine("symmetric?");
            Console.WriteLine(approx1.Equals(approx2));
            Console.WriteLine(approx2.Equals(approx1));
        }
    }

    public class Name
    {
        private readonly string _text;

        public Name(string text)
        {
            _text = text;
        }

        public string Text
        {
            get { return _text; }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Name;

            if (other == null)
            {
                return false;
            }

            return StringComparer.OrdinalIgnoreCase.Equals(other._text, this._text);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(_text);
        }
    }

    public class ScopedName : Name
    {
        private readonly string _namespace;

        public ScopedName(string @namespace, string name)
            : base(name)
        {
            _namespace = @namespace;
        }

        public override bool Equals(object obj)
        {
            var other = obj as ScopedName;

            if (other == null)
            {
                return false;
            }

            return StringComparer.OrdinalIgnoreCase.Equals(other.Text, this.Text)
                && StringComparer.OrdinalIgnoreCase.Equals(other._namespace, this._namespace);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Text)
                ^ StringComparer.OrdinalIgnoreCase.GetHashCode(_namespace);
        }
    }

    public static class EqualityTests
    {
        public static void Name()
        {
            ScopedName microsoftServer = new ScopedName("ms", "server1");
            ScopedName myServer = new ScopedName("ivan", "server1");

            Console.WriteLine(microsoftServer.Equals(myServer));

            Name skynetServer = new Name("server1");

            Console.WriteLine(skynetServer.Equals(microsoftServer));
        }
    }
}
