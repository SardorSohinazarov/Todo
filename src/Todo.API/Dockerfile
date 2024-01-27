#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Todo.API/Todo.API.csproj", "src/Todo.API/"]
COPY ["src/Todo.Application/Todo.Application.csproj", "src/Todo.Application/"]
COPY ["src/Todo.Domain/Todo.Domain.csproj", "src/Todo.Domain/"]
COPY ["src/Todo.Infrastructure/Todo.Infrastructure.csproj", "src/Todo.Infrastructure/"]
RUN dotnet restore "./src/Todo.API/./Todo.API.csproj"
COPY . .
WORKDIR "/src/src/Todo.API"
RUN dotnet build "./Todo.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Todo.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.API.dll"]