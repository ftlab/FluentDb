using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace FluentDb
{
    /// <summary>
    /// Методы расширяющие DbConnection
    /// </summary>
    public static partial class DbConnectionExtension
    {
        /// <summary>
        /// Исполнить команду для получения скалярного значения
        /// </summary>
        /// <typeparam name="T">тип возвращаемого значения</typeparam>
        /// <param name="connection">соединение с БД</param>
        /// <param name="init">инициализация команды</param>
        /// <returns>скалярное значение</returns>
        public static T ExecuteScalar<T>(this DbConnection connection
            , Action<DbCommand> init)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            using (var command = connection.CreateCommand())
            {
                init?.Invoke(command);
                return command.ExecuteScalar<T>();
            }
        }

        /// <summary>
        /// Исполнить команду для получения скалярного значения
        /// </summary>
        /// <typeparam name="T">тип возвращаемого значения</typeparam>
        /// <param name="connection">соединение с БД</param>
        /// <param name="init">инициализация команды</param>
        /// <returns>скалярное значение</returns>
        public static async Task<T> ExecuteScalarAsync<T>(this DbConnection connection
            , Action<DbCommand> init)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            using (var command = connection.CreateCommand())
            {
                init?.Invoke(command);
                var result = await command.ExecuteScalarAsync<T>();
                return result;
            }
        }
    }
}
