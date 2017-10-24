using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace FluentDb
{
    /// <summary>
    /// методы расширяющие DbCommand
    /// </summary>
    public static partial class DbCommandExtension
    {
        /// <summary>
        /// Исполняет запрос и возвращает значение первой колонки первой строки
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static async Task<T> ExecuteScalarAsync<T>(this DbCommand cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            var result = await cmd.ExecuteScalarAsync();
            if (Convert.IsDBNull(result))
                result = null;
            return (T)result;
        }

        /// <summary>
        /// Исполняет запрос и возвращает значение первой колонки первой строки
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(this DbCommand cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            var result = cmd.ExecuteScalar();
            if (Convert.IsDBNull(result))
                result = null;
            return (T)result;
        }
    }
}
