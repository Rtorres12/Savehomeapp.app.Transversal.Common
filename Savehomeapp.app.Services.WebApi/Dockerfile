#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Savehomeapp.app.Services.WebApi/Savehomeapp.app.Services.WebApi.csproj", "Savehomeapp.app.Services.WebApi/"]
COPY ["Savehomeapp.app.Transversal.Mapper/Savehomeapp.app.Transversal.Mapper.csproj", "Savehomeapp.app.Transversal.Mapper/"]
COPY ["Savehomeapp.app.Application.DTO/Savehomeapp.app.Application.DTO.csproj", "Savehomeapp.app.Application.DTO/"]
COPY ["Savehome.app.Domain.Entity/Savehomeapp.app.Domain.Entity.csproj", "Savehome.app.Domain.Entity/"]
COPY ["Savehomeapp.app.Domain.Interface/Savehomeapp.app.Domain.Interface.csproj", "Savehomeapp.app.Domain.Interface/"]
COPY ["Savehome.app.Infrastructure.Repository/Savehomeapp.app.Infrastructure.Repository.csproj", "Savehome.app.Infrastructure.Repository/"]
COPY ["Savehomeapp.app.Transversal.Common/Savehomeapp.app.Transversal.Common.csproj", "Savehomeapp.app.Transversal.Common/"]
COPY ["Savehomeapp.app.Infrastructure.Interface/Savehomeapp.app.Infrastructure.Interface.csproj", "Savehomeapp.app.Infrastructure.Interface/"]
COPY ["Savehomeapp.app.Infrastructure.Data/Savehomeapp.app.Infrastructure.Data.csproj", "Savehomeapp.app.Infrastructure.Data/"]
COPY ["Savehomeapp.app.Aplication.Main/Savehomeapp.app.Application.Main.csproj", "Savehomeapp.app.Aplication.Main/"]
COPY ["Savehomeapp.app.Application.Interface/Savehomeapp.app.Application.Interface.csproj", "Savehomeapp.app.Application.Interface/"]
COPY ["Savehomeapp.app.Domain.Core/Savehomeapp.app.Domain.Core.csproj", "Savehomeapp.app.Domain.Core/"]
RUN dotnet restore "Savehomeapp.app.Services.WebApi/Savehomeapp.app.Services.WebApi.csproj"
COPY . .
WORKDIR "/src/Savehomeapp.app.Services.WebApi"
RUN dotnet build "Savehomeapp.app.Services.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Savehomeapp.app.Services.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Savehomeapp.app.Services.WebApi.dll"]
