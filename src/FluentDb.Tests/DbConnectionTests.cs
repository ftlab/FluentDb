using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using System.Linq;

namespace FluentDb.Tests
{
    /// <summary>
    /// ���� � �����������
    /// </summary>
    [TestClass]
    public class DbConnectionTests
    {
        private SQLiteConnection CreateConnection() =>
            new SQLiteConnection("Data Source=:memory:");


        /// <summary>
        /// ������� ����������
        /// </summary>
        [TestMethod]
        public void DB_Connect()
        {
            using (var db = CreateConnection())
            {
                db.Connect();
            }
        }

        /// <summary>
        /// ��������� ������
        /// </summary>
        [TestMethod]
        public void DB_ExecuteNonQuery()
        {
            using (var db = CreateConnection())
            {
                db.Connect();

                db.ExecuteNonQuery(cmd =>
                    cmd.SetCommandText("SELECT 1"));

                db.ExecuteNonQuery("select 1");

                db.ExecuteNonQuery("select @Code, @Name", new { Code = "Code", Name = "Name" });
            }
        }

        /// <summary>
        /// ��������� ������ ������������ ��������� ��������
        /// </summary>
        [TestMethod]
        public void DB_ExecuteScalar()
        {
            using (var db = CreateConnection())
            {
                db.Connect();

                var sValue = db.ExecuteScalar<string>(cmd =>
                    cmd.SetCommandText("SELECT 'Hello, World'"));
                Assert.AreEqual(sValue, "Hello, World");

                sValue = db.ExecuteScalar<string>("select 'Hello'");
                Assert.AreEqual(sValue, "Hello");

                sValue = db.ExecuteScalar<string>("select @Name", new { Name = "World" });
                Assert.AreEqual(sValue, "World");

                var lValue = db.ExecuteScalarAsync<long>(cmd =>
                    cmd.SetCommandText("select 3"));
                Assert.AreEqual(lValue.Result, 3L);

                lValue = db.ExecuteScalarAsync<long>("select 4");
                Assert.AreEqual(lValue.Result, 4L);

                lValue = db.ExecuteScalarAsync<long>("select @Value", new { Value = 5L });
                Assert.AreEqual(lValue.Result, 5L);
            }
        }

        [TestMethod]
        public void DB_ExecuteReader()
        {
            using (var db = CreateConnection())
            {
                db.Connect();

                var records = db.AsEnumerable(cmd =>
                    cmd.SetCommandText("select 1, 'Hello' union all select 2, 'World'"));
                int cnt = 0;
                foreach (var record in records)
                    cnt++;
                Assert.AreEqual(2, cnt);

                var rows = db.AsEnumerable(
                    commandText: "select 1, 'Hello' union all select 2, 'World'"
                    , map: r => new { Id = r.GetInt64(0), Value = r.GetString(1) })
                    .ToArray();

                Assert.AreEqual(2, rows.Length);
                Assert.AreEqual(1L, rows[0].Id);
                Assert.AreEqual("Hello", rows[0].Value);
                Assert.AreEqual(2L, rows[1].Id);
                Assert.AreEqual("World", rows[1].Value);
            }
        }

    }
}
