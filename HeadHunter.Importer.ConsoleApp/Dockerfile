#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HeadHunter.Importer.ConsoleApp/HeadHunter.Importer.ConsoleApp.csproj", "HeadHunter.Importer.ConsoleApp/"]
COPY ["HeadHunter.Importer/HeadHunter.Importer.csproj", "HeadHunter.Importer/"]
RUN dotnet restore "HeadHunter.Importer.ConsoleApp/HeadHunter.Importer.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/HeadHunter.Importer.ConsoleApp"
RUN dotnet build "HeadHunter.Importer.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HeadHunter.Importer.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HeadHunter.Importer.ConsoleApp.dll"]