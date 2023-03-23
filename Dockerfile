#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Authentication/Authentication.API/Authentication.API.csproj", "src/Authentication/Authentication.API/"]
RUN dotnet restore "src/Authentication/Authentication.API/Authentication.API.csproj"
COPY . .
WORKDIR "/src/src/Authentication/Authentication.API"
RUN dotnet build "Authentication.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication.API.csproj" -c Release -o /app/publish -r linux-x64 --self-contained false /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionString='Server=LIYIN;Database=RecruitingDb;Integrated Security=True;TrustServerCertificate=True;'
ENTRYPOINT ["dotnet", "Authentication.API.dll"]