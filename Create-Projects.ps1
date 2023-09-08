Write-Host "`nStep 1: Creating a New Solution`n"

dotnet new sln
dotnet new gitignore


Write-Host "`nStep 2: Creating Projects from Templates`n"

dotnet new classlib --name "TestQueriesGenerator.Library" --framework "net6.0"
dotnet new nunit --name "TestQueriesGenerator.Testing" --framework "net6.0"
dotnet new console --name "TestQueriesGenerator.App.CLI" --framework "net6.0"


Write-Host "`nStep 3: Adding References to Projects`n"

dotnet add "TestQueriesGenerator.Testing" reference "TestQueriesGenerator.Library"
dotnet add "TestQueriesGenerator.App.CLI" reference "TestQueriesGenerator.Library"


Write-Host "`nStep 4: Adding Projects to the Solution`n"

dotnet sln add "TestQueriesGenerator.Library"
dotnet sln add "TestQueriesGenerator.Testing"
dotnet sln add "TestQueriesGenerator.App.CLI"


Write-Host "`nStep 5: Displaying Projects from the Solution`n"

dotnet sln list
