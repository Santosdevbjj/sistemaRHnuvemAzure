FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ./src/Funcionarios.Domain/ ./src/Funcionarios.Domain/
COPY ./src/Funcionarios.Infrastructure/ ./src/Funcionarios.Infrastructure/
COPY ./src/Funcionarios.Api/ ./src/Funcionarios.Api/
RUN dotnet restore ./src/Funcionarios.Api/Funcionarios.Api.csproj
RUN dotnet publish ./src/Funcionarios.Api/Funcionarios.Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Funcionarios.Api.dll"]
