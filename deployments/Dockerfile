FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["nuget.config", "Api/"]
COPY ["Api/Fatec.Store.Orders.Api.csproj", "Api/"]
COPY ["Application/Fatec.Store.Orders.Application.csproj", "Application/"]
COPY ["CrossCutting/Fatec.Store.Orders.Infrastructure.CrossCutting.csproj", "CrossCutting/"]
COPY ["Domain/Fatec.Store.Orders.Domain.csproj", "Domain/"]
COPY ["Data/Fatec.Store.Orders.Infrastructure.Data.csproj", "Data/"]
RUN dotnet restore --configfile ./Api/nuget.config "./Api/Fatec.Store.Orders.Api.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "./Fatec.Store.Orders.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Fatec.Store.Orders.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fatec.Store.Orders.Api.dll"]