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

```cs
db.ExecuteNonQuery(
    cmdText: "INSERT INTO MYTABLE VALUES (@Id, @Code)"
  , bag: new { Id = 1, Code = "Код" });
```

### 2. ExecuteNonQuery

```cs
db.ExecuteNonQuery("CREATE TABLE MYTABLE(Id, Code)");
```

### 3. ExecuteScalar

```cs
var value = await db.ExecuteScalarAsync<long>("SELECT 4");
```

### 4. ExecuteReader

```cs
//преобразование
var rows = db.AsEnumerable(
       commandText: "SELECT 1, 'Hello' UNION ALL SELECT 2, 'World'"
     , map: r => new { Id = r.GetInt64(0), Value = r.GetString(1) })
     .ToArray();
//автоматическое преобразование
var entities = db.AsEnumerable<Entity>(
       commandText: "SELECT 1 as Id, 'Hello' as Name")
     .ToArray();
```