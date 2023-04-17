#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["URLShortener.WebApi/UrlShortener.WebApi.csproj", "URLShortener.WebApi/"]
RUN dotnet restore "URLShortener.WebApi/UrlShortener.WebApi.csproj"
COPY . .
WORKDIR "/src/URLShortener.WebApi"
RUN dotnet build "UrlShortener.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UrlShortener.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UrlShortener.WebApi.dll"]