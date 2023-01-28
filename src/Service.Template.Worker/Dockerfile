#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Service.Template.Worker/Service.Template.Worker.csproj", "Service.Template.Worker/"]
RUN dotnet restore "Service.Template.Worker/Service.Template.Worker.csproj"
COPY . .
WORKDIR "/src/Service.Template.Worker"
RUN dotnet build "Service.Template.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Service.Template.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service.Template.Worker.dll"]