#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CartToCartService.API/CartToCartService.API.csproj", "CartToCartService.API/"]
COPY ["Database.ClassLibrary/Database.ClassLibrary.csproj", "Database.ClassLibrary/"]
COPY ["RabbitMQInfrastructure.ClassLibrary/RabbitMQInfrastructure.ClassLibrary.csproj", "RabbitMQInfrastructure.ClassLibrary/"]
RUN dotnet restore "CartToCartService.API/CartToCartService.API.csproj"
COPY . .
WORKDIR "/src/CartToCartService.API"
RUN dotnet build "CartToCartService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CartToCartService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CartToCartService.API.dll"]