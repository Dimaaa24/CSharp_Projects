namespace Custom_Hashtables
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HashTable<Person> hashTable = new HashTable<Person>();

            Person p = new Person()
            {
                Id = 0,
                Name = "Angel"
            };


            Person p1 = new Person
            {
                Id = 1,
                Name = "Alex"
            };

            Person p2 = new Person
            {
                Id = 2,
                Name = "Alice"
            };

            Person p3 = new Person
            {
                Id = 3,
                Name = "Victor"
            };

            hashTable.Put("0", p);
            hashTable.Put("1", p1);
            hashTable.Put("2", p2);
            hashTable.Put("3", p3);

            int nrElems = hashTable.Count();

            Console.WriteLine($"Hash count={nrElems}");

            Console.WriteLine($"Hash has key 3:{hashTable.ContainsKey("3")}");

            Console.WriteLine($"Hash has key 4:{hashTable.ContainsKey("4")}");

            List<Person> people = hashTable.Indexer();

            foreach (Person person in people)
            {
                Console.WriteLine(person.Id + "-" + person.Name);
            }

            hashTable.Remove("1");

            nrElems = hashTable.Count();

            Console.WriteLine($"Hash count={nrElems}");

            people = hashTable.Indexer();

            foreach (Person person in people)
            {
                Console.WriteLine(person.Id + "-" + person.Name);
            }

            hashTable.Put("1", p3);
            hashTable.Put("5", p2);
            hashTable.Put("4", p3);

            Console.WriteLine($"Hash has key 4:{hashTable.ContainsKey("4")}");

            people = hashTable.Indexer();

            foreach (Person person in people)
            {
                Console.WriteLine(person.Id + "-" + person.Name);
            }


            nrElems = hashTable.Count();

            Console.WriteLine($"Hash count={nrElems}");

            people = hashTable.Indexer();

            foreach (Person person in people)
            {
                Console.WriteLine(person.Id + "-" + person.Name);
            }

            hashTable.Remove("2");

            nrElems = hashTable.Count();

            Console.WriteLine($"Hash count={nrElems}");

            people = hashTable.Indexer();

            foreach (Person person in people)
            {
                Console.WriteLine(person.Id + "-" + person.Name);
            }
        }
    }
}
