using System;
using System.Collections.Generic;
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
        /// Исполняет запрос и возвращает итератор с записями
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="behavior"></param>
        /// <returns></returns>
        public static IEnumerable<IDataRecord> ExecuteReader(this DbCommand cmd
            , CommandBehavior behavior = CommandBehavior.Default)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            using (var reader = cmd.ExecuteReader(behavior))
                foreach (var record in reader.AsEnumerable())
                    yield return record;
        }

        /// <summary>
        /// Исполняет запрос и возвращает итератор с записями
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="map"></param>
        /// <param name="behavior"></param>
        /// <returns></returns>
        public static IEnumerable<T> ExecuteReader<T>(this DbCommand cmd
            , Func<IDataRecord, T> map
            , CommandBehavior behavior = CommandBehavior.Default)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            if (map == null) throw new ArgumentNullException(nameof(map));

            using (var reader = cmd.ExecuteReader(behavior))
                foreach (IDataRecord record in reader.AsEnumerable())
                    yield return map(record);
        }
    }
}
