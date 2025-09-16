# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files
COPY SWP391.sln ./
COPY TestServer/TestServer.csproj TestServer/

# Restore NuGet packages
RUN dotnet restore SWP391.sln

# Copy everything else and publish
COPY . ./
RUN dotnet publish TestServer/TestServer.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Railpack uses port 8080
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "TestServer.dll"]
