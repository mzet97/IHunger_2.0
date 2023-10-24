#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IHunger.Services.Restaurant.Api/IHunger.Services.Restaurants.Api.csproj", "IHunger.Services.Restaurant.Api/"]
COPY ["IHunger.Services.Restaurant.Application/IHunger.Services.Restaurants.Application.csproj", "IHunger.Services.Restaurant.Application/"]
COPY ["IHunger.Services.Restaurant.Core/IHunger.Services.Restaurants.Core.csproj", "IHunger.Services.Restaurant.Core/"]
COPY ["IHunger.Services.Restaurant.Infrastructure/IHunger.Services.Restaurants.Infrastructure.csproj", "IHunger.Services.Restaurant.Infrastructure/"]
RUN dotnet restore "IHunger.Services.Restaurant.Api/IHunger.Services.Restaurants.Api.csproj"
COPY . .
WORKDIR "/src/IHunger.Services.Restaurant.Api"
RUN dotnet build "IHunger.Services.Restaurants.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IHunger.Services.Restaurants.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IHunger.Services.Restaurants.Api.dll"]