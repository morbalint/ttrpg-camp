ARG BASE_IMAGE=mcr.microsoft.com/dotnet/sdk:8.0
FROM $BASE_IMAGE AS build
WORKDIR /workspace

COPY ["test/Directory.Build.props", "test/"]
COPY ["test/TtrpgCamp.App.Test/TtrpgCamp.App.Test.csproj", "test/TtrpgCamp.App.Test/"]
COPY ["test/TtrpgCamp.App.Test/packages.lock.json", "test/TtrpgCamp.App.Test/"]

RUN dotnet restore --locked-mode "test/TtrpgCamp.App.Test/TtrpgCamp.App.Test.csproj"

COPY . .
WORKDIR /workspace/test/TtrpgCamp.App.Test
ARG BUILD_CONFIGURATION=Release
RUN dotnet build "TtrpgCamp.App.Test.csproj" -c $BUILD_CONFIGURATION  --no-restore

CMD dotnet test --no-build -c $BUILD_CONFIGURATION TtrpgCamp.App.Test.csproj
