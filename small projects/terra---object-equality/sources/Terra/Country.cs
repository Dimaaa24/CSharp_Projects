using System;

namespace iQuest.Terra
{
    public class Country : IComparable
    {
        public string Name { get; }

        public string Capital { get; }

        public Country(string name, string capital)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Capital = capital ?? throw new ArgumentNullException(nameof(capital));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Country))
            {
                return false;
            }

            return (Name == ((Country)obj).Name)
                && (Capital == ((Country)obj).Capital);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() | Capital.GetHashCode();
        }

        public int CompareTo(object other)
        {
            if (other == null)
            {
                return 1;
            }

            if (!(other is Country)) 
            {
                throw new ArgumentException(nameof(other));
            }

            if(Name.CompareTo(((Country)other).Name) != 0)
            {
                return Name.CompareTo(((Country)other).Name);
            }

            if(Capital.CompareTo(((Country)other).Capital) != 0)
            {
                return Capital.CompareTo(((Country)other).Capital);
            }

            return 0;
        }
    }
}