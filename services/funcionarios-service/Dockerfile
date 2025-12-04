FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/FuncionariosService.csproj", "src/"]
RUN dotnet restore "src/FuncionariosService.csproj"
COPY . .
RUN dotnet publish "src/FuncionariosService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FuncionariosService.dll"]
