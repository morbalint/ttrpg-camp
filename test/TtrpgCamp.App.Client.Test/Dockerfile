ARG BASE_IMAGE=mcr.microsoft.com/dotnet/sdk:8.0
FROM $BASE_IMAGE AS build

WORKDIR /workspace

COPY ["test/TtrpgCamp.App.Client.Test/TtrpgCamp.App.Client.Test.csproj", "test/TtrpgCamp.App.Client.Test/"]
COPY ["test/TtrpgCamp.App.Client.Test/packages.lock.json", "test/TtrpgCamp.App.Client.Test/"]
RUN dotnet restore --locked-mode "test/TtrpgCamp.App.Client.Test/TtrpgCamp.App.Client.Test.csproj"

COPY . .
WORKDIR "/workspace/test/TtrpgCamp.App.Client.Test"

ARG BUILD_CONFIGURATION=Release
RUN dotnet build --no-restore "TtrpgCamp.App.Client.Test.csproj" -c $BUILD_CONFIGURATION

ENV BUILD_CONFIGURATION=$BUILD_CONFIGURATION
CMD dotnet test --no-build -c $BUILD_CONFIGURATION TtrpgCamp.App.Client.Test.csproj