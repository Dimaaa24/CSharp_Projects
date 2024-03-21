namespace Custom_Hashtables.Test
{
    [TestClass]
    public class PutTests
    {
        private HashTable<Person> table;

        public PutTests()
        {
            Person p1 = new Person { Id = 1, Name = "Alex" };
            table = new HashTable<Person>(200);
            table.Put("1",p1);
        }

        [TestMethod]
        public void HavingAHashTable_WhenKeyIsNull_ThenThrowNewException()
        {
            Person p = new Person();
            Assert.ThrowsException<ArgumentNullException>(() => table.Put(null, p));
        }

        [TestMethod]
        public void HavingAHashTable_WhenCallingPutMethod_ThenItemIsAddedToTheTable()
        {
            List<Person> people = new List<Person>
            {
                new Person { Id = 1, Name = "Alex" }
            };
            Person p2 = new Person { Id = 2, Name = "Mona" };

            table.Put("2", p2);

            List<Person> people2 = table.Indexer();
            people2.OrderBy(q => q.Id).ToList();
            for (int i = 0; i < people.Count; i++)
            {
                Assert.AreEqual(people[i].Id, people2[i].Id);
                Assert.AreEqual(people2[i].Name, people[i].Name);
            }
        }

        [TestMethod]
        public void HavingAHashTable_WhenCallingPutMethod_ThenSizeIsIncreased()
        {
            Person p2 = new Person { Id = 2, Name = "Mona" };

            table.Put("2", p2);

            Assert.AreEqual(2, table.Count());
        }

    }
}
