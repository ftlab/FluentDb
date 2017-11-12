using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace FluentDb
{
    /// <summary>
    /// Методы расширяющие DbConnection
    /// </summary>
    public static partial class DbConnectionExtension
    {
        /// <summary>
        /// Исполняет запрос и возвращает итератор с записями
        /// </summary>
        /// <param name="connection">соединение с БД</param>
        /// <param name="init">инициализация команды</param>
        /// <param name="behavior">поведение</param>
        /// <returns></returns>
        public static IEnumerable<IDataRecord> AsEnumerable(this DbConnection connection
            , Action<DbCommand> init
            , CommandBehavior behavior = CommandBehavior.Default)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            using (var cmd = connection.CreateCommand())
            {
                init?.Invoke(cmd);
                foreach (var record in cmd.AsEnumerable(behavior))
                    yield return record;
            }
        }

        /// <summary>
        /// Исполняет запрос и возвращает итератор с записями
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="connection">соединение с БД</param>
        /// <param name="init">инициализация команды</param>
        /// <param name="map">преобразование</param>
        /// <param name="behavior">поведение</param>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this DbConnection connection
            , Action<DbCommand> init
            , Func<IDataRecord, T> map
            , CommandBehavior behavior = CommandBehavior.Default)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (map == null) throw new ArgumentNullException(nameof(map));
            using (var cmd = connection.CreateCommand())
            {
                init?.Invoke(cmd);
                foreach (var record in cmd.AsEnumerable(map, behavior))
                    yield return record;
            }
        }

        /// <summary>
        /// Исполняет запрос и возвращает итератор с записями
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="connection">соединение с БД</param>
        /// <param name="init">инициализация команды</param>
        /// <param name="behavior">поведение</param>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this DbConnection connection
            , Action<DbCommand> init
            , CommandBehavior behavior = CommandBehavior.Default)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            using (var cmd = connection.CreateCommand())
            {
                init?.Invoke(cmd);
                foreach (var record in cmd.AsEnumerable<T>(behavior))
                    yield return record;
            }
        }

        /// <summary>
        /// Исполняет запрос и возвращает итератор с записями
        /// </summary>
        /// <param name="connection">соединение с БД</param>
        /// <param name="commandText">текст команды</param>
        /// <param name="behavior">поведение</param>
        /// <returns></returns>
        public static IEnumerable<IDataRecord> AsEnumerable(this DbConnection connection
            , string commandText
            , CommandBehavior behavior = CommandBehavior.Default)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            foreach (var record in connection.AsEnumerable(cmd => cmd.SetCommandText(commandText), behavior))
                yield return record;
        }

        /// <summary>
        /// Исполняет запрос и возвращает итератор с записями
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="connection">Соединение с БД</param>
        /// <param name="commandText">текст команды</param>
        /// <param name="map">преобразование</param>
        /// <param name="behavior">поведение</param>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this DbConnection connection
            , string commandText
            , Func<IDataRecord, T> map
            , CommandBehavior behavior = CommandBehavior.Default)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (map == null) throw new ArgumentNullException(nameof(map));
            foreach (var record in connection.AsEnumerable(cmd => cmd.SetCommandText(commandText), map, behavior))
                yield return record;
        }

        /// <summary>
        /// Исполняет запрос и возвращает итератор с записями
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения</typeparam>
        /// <param name="connection">Соединение с БД</param>
        /// <param name="commandText">текст команды</param>
        /// <param name="behavior">поведение</param>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this DbConnection connection
            , string commandText
            , CommandBehavior behavior = CommandBehavior.Default)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            foreach (var record in connection.AsEnumerable<T>(cmd => cmd.SetCommandText(commandText), behavior))
                yield return record;
        }

        /// <summary>
        /// Исполняет запрос и возвращает итератор с записями
        /// </summary>
        /// <param name="connection">соединение с БД</param>
        /// <param name="commandText">текст команды</param>
        /// <param name="bag">мешок с параметрами</param>
        /// <param name="behavior">поведение</param>
        /// <returns></returns>
        public static IEnumerable<IDataRecord> AsEnumerable(this DbConnection connection
            , string commandText
            , object bag
            , CommandBehavior behavior = CommandBehavior.Default)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            foreach (var record in connection.AsEnumerable(cmd =>
                                        cmd.SetCommandText(commandText)
                                        .AddParameters(bag)))
                yield return record;
        }

        /// <summary>
        /// Исполняет запрос и возвращает итератор с записями
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection">соединение с БД</param>
        /// <param name="commandText">текст комнады</param>
        /// <param name="bag">мешок с параметрами</param>
        /// <param name="map">преобразование</param>
        /// <param name="behavior">поведение</param>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this DbConnection connection
            , string commandText
            , object bag
            , Func<IDataRecord, T> map
            , CommandBehavior behavior = CommandBehavior.Default)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (map == null) throw new ArgumentNullException(nameof(map));
            foreach (var record in connection.AsEnumerable(cmd =>
                                        cmd.SetCommandText(commandText)
                                        .AddParameters(bag)
                                   , map, behavior))
                yield return record;
        }

        /// <summary>
        /// Исполняет запрос и возвращает итератор с записями
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection">соединение с БД</param>
        /// <param name="commandText">текст комнады</param>
        /// <param name="bag">мешок с параметрами</param>
        /// <param name="behavior">поведение</param>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable<T>(this DbConnection connection
            , string commandText
            , object bag
            , CommandBehavior behavior = CommandBehavior.Default)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            foreach (var record in connection.AsEnumerable<T>(cmd =>
                                        cmd.SetCommandText(commandText)
                                        .AddParameters(bag)
                                   , behavior))
                yield return record;
        }
    }
}
