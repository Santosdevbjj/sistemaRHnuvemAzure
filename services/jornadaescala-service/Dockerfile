# Etapa base: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa build: compila o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/JornadaEscalaService.csproj", "src/"]
RUN dotnet restore "src/JornadaEscalaService.csproj"
COPY . .
RUN dotnet publish "src/JornadaEscalaService.csproj" -c Release -o /app/publish

# Etapa final: imagem pronta para rodar
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "JornadaEscalaService.dll"]
