FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy
WORKDIR /usr/local/src/TestQueriesGenerationTool

COPY TestQueriesGenerator.Library/ TestQueriesGenerator.Library/
COPY TestQueriesGenerator.App.CLI/ TestQueriesGenerator.App.CLI/

RUN dotnet publish TestQueriesGenerator.App.CLI/TestQueriesGenerator.App.CLI.csproj --output "/usr/local/bin/TestQueriesGenerationTool/CLI/" --configuration "Release" --use-current-runtime --no-self-contained
WORKDIR /usr/local/bin/TestQueriesGenerationTool