# Welcome to FluentDb

Данная сборка предоставляет  методы расширяющие объекты ADO.NET

- [Home](https://github.com/ftlab)
- [NuGet Package](https://www.nuget.org/packages/FluentDb)

1. Пример использования 1
```cs
using (var db = CreateConnection())
{
	db.Connect();
	var value = db.ExecuteScalar<string>("SELECT @Name", new { Name = "World" });
}
```
2. Пример использования 2
```cs
using (var db = CreateConnection())
{
	db.Connect();
    db.ExecuteNonQuery(cmd =>
      cmd.SetCommandText("SELECT @Id, @Code")
         .SetCommandTimeout(TimeSpan.FromSeconds(5))
         .AddParameter("Id", 0L)
         .AddParameter(p => p.SetName("Code")
                             .SetDbType(DbType.String)
                             .SetValue("Hello")));
}
```

### Markdown

Markdown is a lightweight and easy-to-use syntax for styling your writing. It includes conventions for

```markdown
Syntax highlighted code block

# Header 1
## Header 2
### Header 3

- Bulleted
- List

1. Numbered
2. List

**Bold** and _Italic_ and `Code` text

[Link](url) and ![Image](src)
```

For more details see [GitHub Flavored Markdown](https://guides.github.com/features/mastering-markdown/).

### Jekyll Themes

Your Pages site will use the layout and styles from the Jekyll theme you have selected in your [repository settings](https://github.com/ftlab/FluentDb/settings). The name of this theme is saved in the Jekyll `_config.yml` configuration file.

### Support or Contact

Having trouble with Pages? Check out our [documentation](https://help.github.com/categories/github-pages-basics/) or [contact support](https://github.com/contact) and we’ll help you sort it out.
