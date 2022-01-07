#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AmbrosiaAlert.Dashboard/AmbrosiaAlert.Dashboard.csproj", "AmbrosiaAlert.Dashboard/"]
COPY ["AmbrosiaAlert/Shared/AmbrosiaAlert.Shared.csproj", "AmbrosiaAlert/Shared/"]
COPY ["AmbrosiaAlert.Domain/AmbrosiaAlert.Domain.csproj", "AmbrosiaAlert.Domain/"]
RUN dotnet restore "AmbrosiaAlert.Dashboard/AmbrosiaAlert.Dashboard.csproj"
COPY . .
WORKDIR "/src/AmbrosiaAlert.Dashboard"
RUN dotnet build "AmbrosiaAlert.Dashboard.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AmbrosiaAlert.Dashboard.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AmbrosiaAlert.Dashboard.dll"]