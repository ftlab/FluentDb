# Welcome to FluentDb

Данная сборка предоставляет  методы расширяющие объекты ADO.NET

- [Home](https://github.com/ftlab)
- [NuGet Package](https://www.nuget.org/packages/FluentDb)

пример использования
```cs
using (var db = new SQLiteConnection("Data Source=:memory:"))
{
    db.Connect()
    .ExecuteNonQuery(cmd =>
        cmd.SetCommandText("SELECT @Id, @Code")
           .SetCommandTimeout(TimeSpan.FromSeconds(5))
           .AddParameter("Id", 0L)
           .AddParameter(p => p.SetName("Code")
                               .SetDbType(DbType.String)
                               .SetValue("Hello")));
}
```
## Примеры
### 1. Bag of parameters
### 2. ExecuteNonQuery
### 3. ExecuteScalar
### 4. ExecuteReader