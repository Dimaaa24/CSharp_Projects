namespace Custom_Hashtables.Test
{
    [TestClass]
    public class ContainsKeyTests
    {
        private HashTable<Person> table;

        public ContainsKeyTests()
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

            Assert.ThrowsException<ArgumentNullException>(() => table.ContainsKey(null));
        }

        [TestMethod]
        public void HavingAHashTable_WhenKeyIsNotExistent_ThenFalseIsReturned()
        {
            Assert.AreEqual(false, table.ContainsKey("cheie"));
        }

        [TestMethod]
        public void HavingAHashTable_WhenKeyIsExistent_ThenTrueIsReturned()
        {
            Assert.AreEqual(true, table.ContainsKey("2"));
        }
    }
}
