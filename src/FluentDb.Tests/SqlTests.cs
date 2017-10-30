
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentDb.Tests
{
    [TestClass]
    public class SqlTests
    {
        private SqlConnection CreateConnection() =>
            new SqlConnection("Data Source=zsql;Initial Catalog=CensorDb;User ID=sa;Password=Qwerty11;");


        [TestMethod]
        public void DB_OpenConnection()
        {
            using (var db = CreateConnection())
            {
                db.Connect();

                Assert.AreEqual(db.State, ConnectionState.Open);
            }
        }
    }
}
