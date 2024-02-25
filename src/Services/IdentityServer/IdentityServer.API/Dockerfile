FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/IdentityServer/IdentityServer.API/IdentityServer.API.csproj", "Services/IdentityServer/IdentityServer.API/"]
COPY ["Services/IdentityServer/IdentityServer.Application/IdentityServer.Application.csproj", "Services/IdentityServer/IdentityServer.Application/"]
COPY ["Services/IdentityServer/IdentityServer.Domain/IdentityServer.Domain.csproj", "Services/IdentityServer/IdentityServer.Domain/"]
COPY ["Services/IdentityServer/IdentityServer.Infrastructure/IdentityServer.Infrastructure.csproj", "Services/IdentityServer/IdentityServer.Infrastructure/"]
RUN dotnet restore "Services/IdentityServer/IdentityServer.API/IdentityServer.API.csproj"
COPY . .
WORKDIR "/src/Services/IdentityServer/IdentityServer.API"
RUN dotnet build "IdentityServer.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "IdentityServer.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer.API.dll"]
