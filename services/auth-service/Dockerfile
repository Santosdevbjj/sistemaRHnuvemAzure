FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ./src/Auth.Domain/ ./src/Auth.Domain/
COPY ./src/Auth.Infrastructure/ ./src/Auth.Infrastructure/
COPY ./src/Auth.Api/ ./src/Auth.Api/
RUN dotnet restore ./src/Auth.Api/Auth.Api.csproj
RUN dotnet publish ./src/Auth.Api/Auth.Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Auth.Api.dll"]
