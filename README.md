# HC repros

- Issue #1 (`src/Application/Modules/Users/Queries/UserQueries.cs#26`)

## Development

### Add database connection string for MySQL

`dotnet user-secrets set ConnectionStrings:Default "Server=127.0.0.1;Port=3306;User=example;Password=example;Database=example" --project src/Application/`
