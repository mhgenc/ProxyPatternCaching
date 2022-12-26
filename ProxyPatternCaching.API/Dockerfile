FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProxyPatternCaching.API/ProxyPatternCaching.API.csproj", "ProxyPatternCaching.API/"]
RUN dotnet restore "ProxyPatternCaching.API/ProxyPatternCaching.API.csproj"
COPY . .
WORKDIR "/src/ProxyPatternCaching.API"
RUN dotnet build "ProxyPatternCaching.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProxyPatternCaching.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProxyPatternCaching.API.dll"]
