#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ApiGateways/Kira.ApiGateway.Ocelot/Kira.ApiGateway.Ocelot.csproj", "src/ApiGateways/Kira.ApiGateway.Ocelot/"]
COPY ["src/BuildingBlocks/Kira.Security.Shared/Kira.Security.Shared.csproj", "src/BuildingBlocks/Kira.Security.Shared/"]
COPY ["src/BuildingBlocks/Kira.Utils.Shared/Kira.Utils.Shared.csproj", "src/BuildingBlocks/Kira.Utils.Shared/"]
RUN dotnet restore "src/ApiGateways/Kira.ApiGateway.Ocelot/Kira.ApiGateway.Ocelot.csproj"
COPY . .
WORKDIR "/src/src/ApiGateways/Kira.ApiGateway.Ocelot"

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet build "Kira.ApiGateway.Ocelot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kira.ApiGateway.Ocelot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kira.ApiGateway.Ocelot.dll"]