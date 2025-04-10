FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Fatec.Store.Orders.Api/Fatec.Store.Orders.Api.csproj", "src/Fatec.Store.Orders.Api/"]
RUN dotnet restore "./src/Fatec.Store.Orders.Api/Fatec.Store.Orders.Api.csproj"
COPY . .
WORKDIR "/src/src/Fatec.Store.Orders.Api"
RUN dotnet build "./Fatec.Store.Orders.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Fatec.Store.Orders.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fatec.Store.Orders.Api.dll"]