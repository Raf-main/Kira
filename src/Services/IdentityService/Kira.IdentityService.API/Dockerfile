#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/IdentityService/Kira.IdentityService.API/Kira.IdentityService.API.csproj", "src/Services/IdentityService/Kira.IdentityService.API/"]
COPY ["src/BuildingBlocks/Kira.Domain.Shared/Kira.Domain.Shared.csproj", "src/BuildingBlocks/Kira.Domain.Shared/"]
COPY ["src/BuildingBlocks/Kira.Infrastructure.Shared/Kira.Infrastructure.Shared.csproj", "src/BuildingBlocks/Kira.Infrastructure.Shared/"]
COPY ["src/BuildingBlocks/Kira.Security.Shared/Kira.Security.Shared.csproj", "src/BuildingBlocks/Kira.Security.Shared/"]
COPY ["src/BuildingBlocks/Kira.Utils.Shared/Kira.Utils.Shared.csproj", "src/BuildingBlocks/Kira.Utils.Shared/"]
RUN dotnet restore "src/Services/IdentityService/Kira.IdentityService.API/Kira.IdentityService.API.csproj"
COPY . .
WORKDIR "/src/src/Services/IdentityService/Kira.IdentityService.API"
RUN dotnet build "Kira.IdentityService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kira.IdentityService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kira.IdentityService.API.dll"]