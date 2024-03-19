namespace Custom_Hashtables.Test
{
    [TestClass]
    public class CountTests
    {
        private readonly HashTable<Person> table;

        public CountTests()
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
        public void HavingAHashTable_WhenCountIsCalled_ThenSizeIsReturned()
        {
            Assert.AreEqual(3, table.Count());
        }
    }
}
