#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
ENV PATH="/root/.dotnet/tools:${PATH}"
RUN dotnet tool install --global dotnet-ef --version 8.0.1

COPY ["src/Services/IdentityService/Kira.IdentityService.API/Kira.IdentityService.API.csproj", "src/Services/IdentityService/Kira.IdentityService.API/"]
COPY ["src/BuildingBlocks/Kira.Security.Shared/Kira.Security.Shared.csproj", "src/BuildingBlocks/Kira.Security.Shared/"]
COPY ["src/BuildingBlocks/Kira.Utils.Shared/Kira.Utils.Shared.csproj", "src/BuildingBlocks/Kira.Utils.Shared/"]
COPY ["src/BuildingBlocks/Light-Extensions/Light.Infrastructure.EfCore.SqlServer/Light.Infrastructure.EfCore.csproj", "src/BuildingBlocks/Light-Extensions/Light.Infrastructure.EfCore.SqlServer/"]
COPY ["src/BuildingBlocks/Light-Extensions/Light.Core.Extensions/Light.Core.Extensions.csproj", "src/BuildingBlocks/Light-Extensions/Light.Core.Extensions/"]
COPY ["src/BuildingBlocks/Light-Extensions/Light.Infrastructure.Extensions/Light.Infrastructure.Extensions.csproj", "src/BuildingBlocks/Light-Extensions/Light.Infrastructure.Extensions/"]
RUN dotnet restore "./src/Services/IdentityService/Kira.IdentityService.API/./Kira.IdentityService.API.csproj"
COPY . .
WORKDIR "/src/src/Services/IdentityService/Kira.IdentityService.API"
RUN dotnet build "./Kira.IdentityService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

CMD ["dotnet-ef", "database","update"]
#RUN dotnet-ef database update

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Kira.IdentityService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kira.IdentityService.API.dll"]