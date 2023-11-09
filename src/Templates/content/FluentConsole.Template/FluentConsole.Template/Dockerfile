FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/FluentConsole.Template/FluentConsole.Template.csproj", "src/FluentConsole.Template/"]
RUN dotnet restore "src/FluentConsole.Template/FluentConsole.Template.csproj"
COPY . .
WORKDIR "/src/src/FluentConsole.Template"
RUN dotnet build "FluentConsole.Template.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FluentConsole.Template.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluentConsole.Template.dll"]
