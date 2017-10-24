using System;
using System.Data.Common;

namespace FluentDb
{
    /// <summary>
    /// Методы расширяющие DbConnection
    /// </summary>
    public static partial class DbConnectionExtension
    {
        /// <summary>
        /// Открыть соединение
        /// </summary>
        /// <param name="connection">соединение</param>
        /// <returns></returns>
        public static DbConnection Connect(this DbConnection connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            connection.Open();
            return connection;
        }
    }
}
