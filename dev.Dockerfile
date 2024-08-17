FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /workspace

COPY ["src/TtrpgCamp.App/TtrpgCamp.App.csproj", "src/TtrpgCamp.App/"]
COPY ["src/TtrpgCamp.App/packages.lock.json", "src/TtrpgCamp.App/"]

COPY ["src/TtrpgCamp.App.Client/TtrpgCamp.App.Client.csproj", "src/TtrpgCamp.App.Client/"]
COPY ["src/TtrpgCamp.App.Client/packages.lock.json", "src/TtrpgCamp.App.Client/"]

RUN dotnet restore --locked-mode "src/TtrpgCamp.App/TtrpgCamp.App.csproj"

COPY . .
WORKDIR /workspace/src/TtrpgCamp.App
RUN dotnet build --no-restore "TtrpgCamp.App.csproj" -c $BUILD_CONFIGURATION

FROM build AS publish
WORKDIR /workspace/
RUN dotnet publish --no-build "src/TtrpgCamp.App/TtrpgCamp.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TtrpgCamp.App.dll"]