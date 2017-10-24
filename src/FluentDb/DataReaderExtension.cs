using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace FluentDb
{
    /// <summary>
    /// Расширение для IDataReader
    /// </summary>
    public static class DataReaderExtension
    {
        /// <summary>
        /// Вернуть как перечислимое
        /// </summary>
        /// <param name="reader">считыватель</param>
        /// <returns>перечислимое</returns>
        public static IEnumerable<IDataRecord> AsEnumerable(this IDataReader reader)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            while (reader.Read())
                yield return reader;
        }

        /// <summary>
        /// Вернуть как перечислимое
        /// </summary>
        /// <typeparam name="T">тип возвращаемого элемента</typeparam>
        /// <param name="reader">считыватель</param>
        /// <param name="map">преобразователь</param>
        /// <returns>перечислимое</returns>
        public static IEnumerable<T> AsEnumerable<T>(this IDataReader reader
            , Func<IDataRecord, T> map)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            foreach (var record in reader.AsEnumerable())
                yield return map(record);
        }

        /// <summary>
        /// Вернуть как перечислимое
        /// </summary>
        /// <typeparam name="T">тип возвращаемого элемента</typeparam>
        /// <param name="reader">считыватель</param>
        /// <returns>перечислимое</returns>
        public static IEnumerable<T> AsEnumerable<T>(this IDataReader reader)
            where T : new()
        {
            var fields = Enumerable
                .Range(0, reader.FieldCount)
                .Select(i => reader.GetName(i))
                .ToArray();

            var members = typeof(T).GetMembers()
                .Where(m =>
                     fields.Contains(m.Name)
                    && (m is PropertyInfo
                        || m is FieldInfo
                    ))
                .ToArray();

            foreach (var record in reader.AsEnumerable())
            {
                T instance = new T();
                foreach (var member in members)
                {
                    var value = reader[member.Name];
                    if (Convert.IsDBNull(value))
                        value = null;

                    var prop = member as PropertyInfo;
                    if (prop != null)
                    {
                        prop.SetValue(instance, value);
                        continue;
                    }

                    var field = member as FieldInfo;
                    if (field != null)
                    {
                        field.SetValue(instance, value);
                        continue;
                    }

                    throw new NotSupportedException(member.MemberType.ToString());
                }
                yield return instance;
            }
        }
    }
}
