using System;
using System.Data;
using System.Data.Common;

namespace FluentDb
{
    /// <summary>
    /// Методы расширяющие DbParameter
    /// </summary>
    public static partial class DbParameterExtension
    {
        /// <summary>
        /// Установаить имя параметра
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DbParameter SetName(this DbParameter parameter
            , string name)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            parameter.ParameterName = name;
            return parameter;
        }

        /// <summary>
        /// Установить значение параметра
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DbParameter SetValue(this DbParameter parameter
            , object value)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            if (value == null)
                parameter.Value = DBNull.Value;
            else
                parameter.Value = value;
            return parameter;
        }

        /// <summary>
        /// Установить значение параметра
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DbParameter SetDbType(this DbParameter parameter
            , DbType type)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            parameter.DbType = type;
            return parameter;
        }

        /// <summary>
        /// Установить направление параметра
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DbParameter SetDirection(this DbParameter parameter
            , ParameterDirection direction)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            parameter.Direction = direction;
            return parameter;
        }

        /// <summary>
        /// Установить размер значения параметра
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static DbParameter SetSize(this DbParameter parameter
            , int size)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            parameter.Size = size;
            return parameter;
        }
    }
}
