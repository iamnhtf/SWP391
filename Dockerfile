# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy solution và csproj
COPY SWP391.sln ./
COPY TestServer/TestServer.csproj TestServer/
RUN dotnet restore SWP391.sln

# copy toàn bộ source
COPY . ./

# publish project TestServer
RUN dotnet publish TestServer/TestServer.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Railway yêu cầu port 8080
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "TestServer.dll"]
