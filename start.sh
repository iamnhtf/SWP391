#!/bin/bash
# Dừng script nếu gặp lỗi
set -e

# 1️⃣ Restore toàn bộ solution
dotnet restore SWP391.sln

# 2️⃣ Build solution ở chế độ Release
dotnet build SWP391.sln -c Release

# 3️⃣ Chạy project TestServer
# --urls để Railpack có thể truy cập từ bên ngoài
dotnet run --project TestServer/TestServer.csproj --configuration Release --urls http://0.0.0.0:8080
