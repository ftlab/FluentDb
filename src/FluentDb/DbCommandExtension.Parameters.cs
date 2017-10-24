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
        /// Добавить параметр
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="init"></param>
        /// <returns></returns>
        public static DbCommand AddParameter(this DbCommand cmd
            , Action<DbParameter> init)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            var parameter = cmd.CreateParameter();
            init?.Invoke(parameter);
            cmd.Parameters.Add(parameter);
            return cmd;
        }

        /// <summary>
        /// Добавить параметр
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DbCommand AddParameter(this DbCommand cmd
            , string name, object value)
        {
            return cmd.AddParameter(p => p.SetName(name).SetValue(value));
        }

        /// <summary>
        /// Добавить параметры из мешка
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="bag"></param>
        /// <returns></returns>
        public static DbCommand AddParameters(this DbCommand cmd
            , object bag)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            if (bag == null) throw new ArgumentNullException(nameof(bag));

            foreach (var property in bag.GetType().GetProperties())
                cmd.AddParameter(property.Name, property.GetValue(bag));

            return cmd;
        }
    }
}
