FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY . .
RUN dotnet restore Api.Web/Api.Web.csproj
WORKDIR /src/GhostNetwork.Publications.Api
RUN dotnet build Api.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Api.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Api.Web.dll"]