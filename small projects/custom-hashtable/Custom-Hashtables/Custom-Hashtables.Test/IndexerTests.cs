namespace Custom_Hashtables.Test
{
    [TestClass]
    public class IndexerTests
    {
        private HashTable<Person> table;

        public IndexerTests()
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
        public void HavingAHashTable_WhenIndexerIsCalled_ElementsAreReturnedAsAList()
        {
            List<Person> people = new List<Person>
            {
                new Person { Id = 1, Name = "Alex" },
                new Person { Id = 2, Name = "Muna" },
                new Person { Id = 3, Name = "Silviu" }
            };

            List<Person> people2 = table.Indexer();

            people2.OrderBy(q => q.Id).ToList();
            for (int i=0; i<people.Count; i++)
            {
                Assert.AreEqual(people[i].Id, people2[i].Id);
                Assert.AreEqual(people[i].Name, people2[i].Name);
            }
        }
    }
}
