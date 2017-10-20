using System;
using System.Data.Common;

namespace FluentDb
{
    /// <summary>
    /// методы расширяющие DbConnection
    /// </summary>
    public static partial class DbConnectionExtension
    {
        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="con"></param>
        /// <param name="init"></param>
        /// <returns></returns>
        public static DbConnection ExecuteNonQuery(this DbConnection con
            , Action<DbCommand> init)
        {
            if (con == null) throw new ArgumentNullException(nameof(con));
            using (var cmd = con.CreateCommand())
                init?.Invoke(cmd);
            return con;
        }

        /// <summary>
        /// Выполнить запрос
        /// </summary>
        /// <param name="con"></param>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static DbConnection ExecuteNonQuery(this DbConnection con
            , string cmdText)
        {
            return con.ExecuteNonQuery(cmd
                => cmd.SetCommandText(cmdText));
        }

        /// <summary>
        /// Выполнить запрос
        /// </summary>
        /// <param name="con"></param>
        /// <param name="cmdText"></param>
        /// <param name="bag"></param>
        /// <returns></returns>
        public static DbConnection ExecuteNonQuery(this DbConnection con
            , string cmdText
            , object bag)
        {
            return con.ExecuteNonQuery(cmd
                => cmd.SetCommandText(cmdText)
                .AddParameters(bag));
        }
    }
}
