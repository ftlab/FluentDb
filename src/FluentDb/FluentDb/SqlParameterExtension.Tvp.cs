using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FluentDb
{
    /// <summary>
    /// Методы расширяющий SqlParameter
    /// </summary>
    public static partial class SqlParameterExtension
    {
        /// <summary>
        /// Использовать как Table-Value параметр
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="typeName"></param>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static SqlParameter AsTvp(this SqlParameter parameter
             , string typeName
             , DataTable dataTable)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
            parameter.SqlValue = dataTable ?? throw new ArgumentNullException(nameof(dataTable));

            return parameter;
        }

        /// <summary>
        /// Использовать как Table-Value параметр
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="typeName"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static SqlParameter AsTvp(this SqlParameter parameter
            , string typeName
            , DbDataReader reader)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
            parameter.SqlValue = reader ?? throw new ArgumentNullException(nameof(reader));

            return parameter;
        }

        /// <summary>
        /// Использовать как Table-Value параметр
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="typeName"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        public static SqlParameter AsTvp(this SqlParameter parameter
            , string typeName
            , IEnumerable<SqlDataRecord> records)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
            parameter.SqlValue = records ?? throw new ArgumentNullException(nameof(records));

            return parameter;
        }
    }
}
