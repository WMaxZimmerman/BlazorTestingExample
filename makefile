build:
	dotnet build src/BlazorTestingExample.sln

test:
	dotnet test src/BlazorTestingExample.sln

run:
	dotnet run --project src/BlazorTestingExample.Web/BlazorTestingExample.Web.csproj

migration:
	dotnet ef migrations add "$(name)" --context "BlazorTestingExampleDbContext" --startup-project "./src/BlazorTestingExample.API/BlazorTestingExample.API.csproj" --project "./src/BlazorTestingExample.Core/BlazorTestingExample.Core.csproj" -o "Clients/Db/Migrations"

migration_run:
	dotnet ef database update --context "BlazorTestingExampleDbContext" --startup-project "./src/BlazorTestingExample.Web/BlazorTestingExample.Web.csproj" --project "./src/BlazorTestingExample.Core/BlazorTestingExample.Core.csproj"
