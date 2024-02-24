FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ApiGateways/Kira.ApiGateway.Ocelot/Kira.ApiGateway.Ocelot.csproj", "src/ApiGateways/Kira.ApiGateway.Ocelot/"]
COPY ["src/BuildingBlocks/Kira.Security.Shared/Kira.Security.Shared.csproj", "src/BuildingBlocks/Kira.Security.Shared/"]
COPY ["src/BuildingBlocks/Kira.Utils.Shared/Kira.Utils.Shared.csproj", "src/BuildingBlocks/Kira.Utils.Shared/"]
RUN dotnet restore "src/ApiGateways/Kira.ApiGateway.Ocelot/Kira.ApiGateway.Ocelot.csproj"
COPY . .
WORKDIR "/src/src/ApiGateways/Kira.ApiGateway.Ocelot"
RUN dotnet build "Kira.ApiGateway.Ocelot.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Kira.ApiGateway.Ocelot.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kira.ApiGateway.Ocelot.dll"]
