using System;
using System.Data;
using System.Data.Common;

namespace FluentDb
{
    /// <summary>
    /// методы расширяющие DbCommand
    /// </summary>
    public static partial class DbCommandExtension
    {
        /// <summary>
        /// Установить текст команды
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DbCommand SetCommandText(this DbCommand cmd
            , string commandText)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            cmd.CommandText = commandText;
            return cmd;
        }

        /// <summary>
        /// Установить тип команды
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DbCommand SetCommandType(this DbCommand cmd
            , CommandType type)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            cmd.CommandType = type;
            return cmd;
        }

        /// <summary>
        /// Установить таймаут команды
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static DbCommand SetCommandTimeout(this DbCommand cmd
            , TimeSpan timeout)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            cmd.CommandTimeout = (int)timeout.TotalSeconds;
            return cmd;
        }
    }
}
