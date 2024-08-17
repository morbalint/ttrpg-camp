FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /workspace
COPY ["src/TtrpgCamp.App/TtrpgCamp.App.csproj", "src/TtrpgCamp.App/"]
COPY ["src/TtrpgCamp.App.Client/TtrpgCamp.App.Client.csproj", "src/TtrpgCamp.App.Client/"]
RUN dotnet restore "src/TtrpgCamp.App/TtrpgCamp.App.csproj"
COPY . .
WORKDIR "/workspace/src/TtrpgCamp.App"
RUN dotnet build "TtrpgCamp.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TtrpgCamp.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TtrpgCamp.App.dll"]
