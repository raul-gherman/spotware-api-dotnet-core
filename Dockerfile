FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /src

COPY ["spotware.csproj", "./"]

RUN dotnet restore "./spotware.csproj"

COPY . .

WORKDIR /src

RUN dotnet publish "spotware.csproj" -c Release -r linux-musl-x64 -o /app/publish

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-alpine AS final

# images built from this one will have to set / overwrite the following ENV variables:
ENV SPOTWARE_API_GATEWAY = ""
ENV SPOTWARE_API_PORT = 0
ENV SPOTWARE_API_CLIENT_ID = ""
ENV SPOTWARE_API_CLIENT_SECRET = ""
ENV SPOTWARE_API_ACCESS_TOKEN = ""
ENV SPOTWARE_API_REFRESH_TOKEN = ""

WORKDIR /app

COPY --from=build /app/publish .