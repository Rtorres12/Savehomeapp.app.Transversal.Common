FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Savehomeapp.app.Services.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /src/Savehomeapp.app.Services.WebApi/out ./

ENTRYPOINT ["dotnet","Savehomeapp.app.Services.WebApi.dll"]