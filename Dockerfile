# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Sửa dòng này để copy đúng file .csproj
COPY TestServer.csproj ./

# Sửa dòng này để restore đúng file .csproj
RUN dotnet restore TestServer.csproj

# ... các dòng khác giữ nguyên

COPY . ./
RUN dotnet publish TestServer.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "TestServer.dll"]