namespace Custom_Hashtables.Test
{
    [TestClass]
    public class ConstructorTests
    {
        private HashTable<Person> table;

        [TestMethod]
        public void HavingAHashTable_WhenCounstructorSizeInvalid_ThrowNewException()
        {
            Assert.ThrowsException<ArgumentException>(() => table = new HashTable<Person>(0));
        }

        [TestMethod]
        public void HavingAHashTable_WhenCallingConstructor_HashTableConstructed()
        {
            table = new HashTable<Person>(100);
            Assert.AreEqual(table.Count(), 0);
        }
    }
}
