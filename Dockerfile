﻿ARG BASE_IMAGE=mcr.microsoft.com/dotnet/sdk:8.0
FROM $BASE_IMAGE AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /workspace
RUN dotnet publish --no-build "src/TtrpgCamp.App/TtrpgCamp.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TtrpgCamp.App.dll"]
