namespace Custom_Hashtables.Test
{
    [TestClass]
    public class RemoveTests
    {
        private HashTable<Person> table;

        public RemoveTests()
        {
            Person p1 = new Person { Id = 1, Name = "Alex" };
            Person p2 = new Person { Id = 2, Name = "Muna" };
            Person p3 = new Person { Id = 3, Name = "Silviu" };
            table = new HashTable<Person>(200);
            table.Put("1", p1);
            table.Put("2", p2);
            table.Put("3", p3);
        }

        [TestMethod]
        public void HavingAHashTable_WhenKeyIsNull_ThenThrowNewException()
        {
            Person p = new Person();
            Assert.ThrowsException<ArgumentNullException>(() => table.Put(null, p));
        }

        [TestMethod]
        public void HavingAHashTable_WhenRemoveIsCalled_ThenRemoveElement()
        {
            List<Person> people = new List<Person>
            {
                new Person { Id = 1, Name = "Alex" },
                new Person { Id = 3, Name = "Silviu" }
            };

            table.Remove("2");

            List<Person> people2 = table.Indexer();
            people2.OrderBy(q => q.Id).ToList();
            for (int i = 0; i < people.Count; i++)
            {
                Assert.AreEqual(people[i].Id, people2[i].Id);
                Assert.AreEqual(people2[i].Name, people[i].Name);
            }
        }

        [TestMethod]
        public void HavingAHashTable_WhenRemoveIsCalled_ThenSizeIsDecreased()
        {
            table.Remove("2");

            Assert.AreEqual(2, table.Count());
        }
    }
}
