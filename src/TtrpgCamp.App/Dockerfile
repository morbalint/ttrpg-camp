ARG BASE_IMAGE=mcr.microsoft.com/dotnet/sdk:8.0
FROM $BASE_IMAGE AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /workspace
COPY ["src/TtrpgCamp.App/TtrpgCamp.App.csproj", "src/TtrpgCamp.App/"]
COPY ["src/TtrpgCamp.App/packages.lock.json", "src/TtrpgCamp.App/"]
RUN dotnet restore --locked-mode "src/TtrpgCamp.App/TtrpgCamp.App.csproj"
COPY . .
WORKDIR /workspace/src/TtrpgCamp.App
RUN dotnet build --no-restore "TtrpgCamp.App.csproj" -c $BUILD_CONFIGURATION
