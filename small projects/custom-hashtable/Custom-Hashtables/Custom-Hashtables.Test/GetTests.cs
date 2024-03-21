namespace Custom_Hashtables.Test
{
    [TestClass]
    public class GetTests
    {
        private HashTable<Person> table;

        public GetTests()
        {
            Person p2 = new Person { Id = 2, Name = "Mona" };
            Person p1 = new Person { Id = 1, Name = "Alex" };
            table = new HashTable<Person>(200);
            table.Put("1", p1);
            table.Put("2", p2);
        }

        [TestMethod]
        public void HavingAHashTable_WhenKeyIsNull_ThenThrowNewException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => table.Get(null));
        }

        [TestMethod]
        public void HavingAHashTable_WhenKeyExists_ItemIsReturned()
        {
            Person p2 = new Person { Id = 2, Name = "Mona" };

            Assert.AreEqual(p2.Id, table.Get("2").Id);
            Assert.AreEqual(p2.Name, table.Get("2").Name);
        }

        [TestMethod]
        public void HavingAHashTable_WhenKeyIsNotExistent_NullIsReturned()
        {
            Assert.AreEqual(null, table.Get("3"));
        }
    }
}
