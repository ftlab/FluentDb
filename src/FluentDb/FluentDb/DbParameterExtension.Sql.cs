using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FluentDb
{
    /// <summary>
    /// Методы расширяющие DbParameter
    /// </summary>
    public static partial class DbParameterExtension
    {
        /// <summary>
        /// Использовать как SQl параметр
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="init"></param>
        /// <returns></returns>
        public static DbParameter AsSql(this DbParameter parameter
            , Action<SqlParameter> init)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            var sqlParam = parameter as SqlParameter;
            if (sqlParam == null) throw new ArgumentException("Parameter is not Sql", nameof(parameter));
            init?.Invoke(sqlParam);
            return sqlParam;
        }
    }
}
