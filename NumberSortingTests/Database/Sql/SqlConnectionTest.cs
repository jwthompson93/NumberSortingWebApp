using NumberSortingWebApp.Library.Database.Sql;

namespace NumberSortingTests.Database.Sql
{
    public class SqlConnectionTest
    {

        private SortedNumberConnection SortedNumberConnection;

        [SetUp]
        public void Setup()
        {
            SortedNumberConnection = new SortedNumberConnection();
        }

        [Test]
        public void Test_SortedNumbersConnection_GetAll()
        {
            var sortedNumbers = SortedNumberConnection.GetAll();
            Assert.IsNotNull(sortedNumbers);
        }

        [Test]
        [TestCase(1)]
        public void Test_SortedNumbersConnection_GetById(long id)
        {
            var sortedNumbers = SortedNumberConnection.GetById(id);
            Assert.IsNotNull(sortedNumbers);
        }
    }
}
