#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Container we use for final publish
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build container
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

# Copy the code into the container
WORKDIR /src
COPY ["src/Simline2/Simline2.csproj", "Simline2/"]

# NuGet restore
RUN dotnet restore "Simline2/Simline2.csproj"
COPY ["src/Simline2/", "Simline2/"]

# Build the API
WORKDIR "Simline2"
RUN dotnet build "Simline2.csproj" -c Release -o /app/build

# Publish it
FROM build AS publish
RUN dotnet publish "Simline2.csproj" -c Release -o /app/publish

# Make the final image for publishing
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Simline2.dll"]
