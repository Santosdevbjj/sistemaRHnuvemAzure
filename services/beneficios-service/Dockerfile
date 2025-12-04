FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/BeneficiosService.csproj", "src/"]
RUN dotnet restore "src/BeneficiosService.csproj"
COPY . .
RUN dotnet publish "src/BeneficiosService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BeneficiosService.dll"]
