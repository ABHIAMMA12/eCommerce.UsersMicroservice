#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 9010
EXPOSE 9011

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UsersMicroservice.API/UsersMicroservice.API.csproj", "UsersMicroservice.API/"]
RUN dotnet restore "./UsersMicroservice.API/UsersMicroservice.API.csproj"
COPY . .
WORKDIR "/src/UsersMicroservice.API"
RUN dotnet build "./UsersMicroservice.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UsersMicroservice.API.csproj"  -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV POSTGRES_HOST=localhost
ENV POSTGRES_PASSWORD=root
ENTRYPOINT ["dotnet", "UsersMicroservice.API.dll"]