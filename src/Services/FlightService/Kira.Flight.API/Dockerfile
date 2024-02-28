FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/FlightService/Kira.Flight.API/Kira.Flight.API.csproj", "src/Services/FlightService/Kira.Flight.API/"]
COPY ["src/BuildingBlocks/Kira.API.Shared/Kira.API.Shared.csproj", "src/BuildingBlocks/Kira.API.Shared/"]
COPY ["src/Services/FlightService/Kira.Flight.Application/Kira.Flight.Application.csproj", "src/Services/FlightService/Kira.Flight.Application/"]
COPY ["src/BuildingBlocks/Light-Extensions/Light.Infrastructure.Extensions/Light.Infrastructure.Extensions.csproj", "src/BuildingBlocks/Light-Extensions/Light.Infrastructure.Extensions/"]
COPY ["src/BuildingBlocks/Light-Extensions/Light.Core.Extensions/Light.Core.Extensions.csproj", "src/BuildingBlocks/Light-Extensions/Light.Core.Extensions/"]
COPY ["src/Services/FlightService/Kira.Flight.Domain/Kira.Flight.Domain.csproj", "src/Services/FlightService/Kira.Flight.Domain/"]
COPY ["src/BuildingBlocks/Kira.Domain.Shared/Kira.Domain.Shared.csproj", "src/BuildingBlocks/Kira.Domain.Shared/"]
COPY ["src/BuildingBlocks/Kira.Application.Shared/Kira.Application.Shared.csproj", "src/BuildingBlocks/Kira.Application.Shared/"]
COPY ["src/Services/FlightService/Kira.Flight.Extensions/Kira.Flight.Extensions.csproj", "src/Services/FlightService/Kira.Flight.Extensions/"]
COPY ["src/BuildingBlocks/Light-Extensions/Light.Infrastructure.EfCore.SqlServer/Light.Infrastructure.EfCore.csproj", "src/BuildingBlocks/Light-Extensions/Light.Infrastructure.EfCore.SqlServer/"]
COPY ["src/Services/FlightService/Kira.Flight.Infrastructure/Kira.Flight.Infrastructure.csproj", "src/Services/FlightService/Kira.Flight.Infrastructure/"]
RUN dotnet restore "src/Services/FlightService/Kira.Flight.API/Kira.Flight.API.csproj"
COPY . .
WORKDIR "/src/src/Services/FlightService/Kira.Flight.API"
RUN dotnet build "Kira.Flight.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Kira.Flight.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kira.Flight.API.dll"]
