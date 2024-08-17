ARG BASE_IMAGE=mcr.microsoft.com/dotnet/sdk:8.0
FROM $BASE_IMAGE AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /workspace
COPY ["test/TtrpgCamp.App.Client.Test/TtrpgCamp.App.Client.Test.csproj", "test/TtrpgCamp.App.Client.Test/"]
COPY ["test/TtrpgCamp.App.Client.Test/packages.lock.json", "test/TtrpgCamp.App.Client.Test/"]
RUN dotnet restore --locked-mode "test/TtrpgCamp.App.Client.Test/TtrpgCamp.App.Client.Test.csproj"
COPY . .
WORKDIR "/workspace/test/TtrpgCamp.App.Client.Test"
RUN dotnet build --no-restore "TtrpgCamp.App.Client.Test.csproj" -c $BUILD_CONFIGURATION

ENTRYPOINT ["dotnet", "test", "--no-build", "TtrpgCamp.App.Client.Test.csproj"]