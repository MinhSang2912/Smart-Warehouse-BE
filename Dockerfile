FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Smart Warehouse.csproj", "."]
RUN dotnet restore "Smart Warehouse.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Smart Warehouse.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Smart Warehouse.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Smart Warehouse.dll"]