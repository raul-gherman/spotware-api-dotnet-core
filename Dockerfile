FROM mcr.microsoft.com/dotnet/core/runtime:3.1-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["spotware.csproj", "./"]
RUN dotnet restore "./spotware.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "spotware.csproj" -c Release -r linux-musl-x64 -o /app/build

FROM build AS publish
RUN dotnet publish "spotware.csproj" -c Release -r linux-musl-x64 -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "spotware.dll"]
