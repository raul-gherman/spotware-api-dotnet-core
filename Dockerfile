FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src

COPY ["spotware.csproj", "./"]

RUN dotnet restore "./spotware.csproj"

COPY . .

WORKDIR /src

RUN dotnet publish "spotware.csproj" -c Release -r linux-musl-x64 -o /app/publish

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-alpine AS final

WORKDIR /app

COPY --from=build /app/publish .