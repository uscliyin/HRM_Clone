#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Recruiting/Recruiting.API/Recruiting.API.csproj", "src/Recruiting/Recruiting.API/"]
COPY ["src/Recruiting/ApplicationCore/ApplicationCore.csproj", "src/Recruiting/ApplicationCore/"]
COPY ["src/Recruiting/Infrastructure/Infrastructure.csproj", "src/Recruiting/Infrastructure/"]
RUN dotnet restore "src/Recruiting/Recruiting.API/Recruiting.API.csproj"
COPY . .
WORKDIR "/src/src/Recruiting/Recruiting.API"
RUN dotnet build "Recruiting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recruiting.API.csproj" -c Release -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQYLConnectionString='Server=LIYIN;Database=RecruitingDb;Integrated Security=True;TrustServerCertificate=True;'
ENTRYPOINT ["dotnet", "Recruiting.API.dll"]