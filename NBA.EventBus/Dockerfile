FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NBA.EventBus/NBA.EventBus.csproj", "NBA.EventBus/"]
RUN dotnet restore "./NBA.EventBus/NBA.EventBus.csproj"
COPY . .
WORKDIR "/src/NBA.EventBus"
RUN dotnet build "./NBA.EventBus.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NBA.EventBus.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NBA.EventBus.dll"]