#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PersonApi.Api/PersonApi.Api.csproj", "PersonApi.Api/"]
COPY ["PersonApi.Domain/PersonApi.Domain.csproj", "PersonApi.Domain/"]
COPY ["PersonApi.Service/PersonApi.Service.csproj", "PersonApi.Service/"]
RUN dotnet restore "PersonApi.Api/PersonApi.Api.csproj"
COPY . .
WORKDIR "/src/PersonApi.Api"
RUN dotnet build "PersonApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonApi.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonApi.Api.dll"]