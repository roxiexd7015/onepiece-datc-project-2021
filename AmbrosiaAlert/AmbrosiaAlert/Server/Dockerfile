#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AmbrosiaAlert/Server/AmbrosiaAlert.Server.csproj", "AmbrosiaAlert/Server/"]
COPY ["AmbrosiaAlert.Domain/AmbrosiaAlert.Domain.csproj", "AmbrosiaAlert.Domain/"]
COPY ["AmbrosiaAlert/Shared/AmbrosiaAlert.Shared.csproj", "AmbrosiaAlert/Shared/"]
COPY ["AmbrosiaAlert/Client/AmbrosiaAlert.Client.csproj", "AmbrosiaAlert/Client/"]
RUN dotnet restore "AmbrosiaAlert/Server/AmbrosiaAlert.Server.csproj"
COPY . .
WORKDIR "/src/AmbrosiaAlert/Server"
RUN dotnet build "AmbrosiaAlert.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AmbrosiaAlert.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AmbrosiaAlert.Server.dll"]