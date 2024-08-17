ARG BASE_IMAGE=mcr.microsoft.com/dotnet/sdk:8.0
FROM $BASE_IMAGE AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /workspace

COPY ["test/TtrpgCamp.App.Test/TtrpgCamp.App.Test.csproj", "test/TtrpgCamp.App.Test/"]
COPY ["test/TtrpgCamp.App.Test/packages.lock.json", "test/TtrpgCamp.App.Test/"]

RUN dotnet restore --locked-mode "test/TtrpgCamp.App.Test/TtrpgCamp.App.Test.csproj"

COPY . .
WORKDIR /workspace/test/TtrpgCamp.App.Test
RUN dotnet build "TtrpgCamp.App.Test.csproj" -c $BUILD_CONFIGURATION  --no-restore

ENTRYPOINT ["dotnet", "test", "--no-build", "TtrpgCamp.App.Test.csproj"]
