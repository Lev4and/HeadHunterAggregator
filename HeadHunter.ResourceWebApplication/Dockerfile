#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HeadHunter.ResourceWebApplication/HeadHunter.ResourceWebApplication.csproj", "HeadHunter.ResourceWebApplication/"]
COPY ["HeadHunter.Infrastructure/HeadHunter.Infrastructure.csproj", "HeadHunter.Infrastructure/"]
COPY ["HeadHunter.HttpClients/HeadHunter.HttpClients.csproj", "HeadHunter.HttpClients/"]
COPY ["HeadHunter.Core/HeadHunter.Core.csproj", "HeadHunter.Core/"]
COPY ["HeadHunter.HttpClients.Core/HeadHunter.HttpClients.Core.csproj", "HeadHunter.HttpClients.Core/"]
RUN dotnet restore "HeadHunter.ResourceWebApplication/HeadHunter.ResourceWebApplication.csproj"
COPY . .
WORKDIR "/src/HeadHunter.ResourceWebApplication"
RUN dotnet build "HeadHunter.ResourceWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HeadHunter.ResourceWebApplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HeadHunter.ResourceWebApplication.dll"]