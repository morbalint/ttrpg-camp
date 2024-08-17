FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TtrpgCamp.App.Client/TtrpgCamp.App.Client.csproj", "src/TtrpgCamp.App.Client/"]
COPY ["src/TtrpgCamp.App.Client/packages.lock.json", "src/TtrpgCamp.App.Client/"]
RUN dotnet restore --locked-mode "src/TtrpgCamp.App.Client/TtrpgCamp.App.Client.csproj"
COPY . .
WORKDIR "/src/src/TtrpgCamp.App.Client"
RUN dotnet build --no-restore "TtrpgCamp.App.Client.csproj" -c $BUILD_CONFIGURATION
