#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["ApiDocker.csproj", "ApiDocker/"]
#RUN dotnet restore "ApiDocker/ApiDocker.csproj"
#COPY . .
#WORKDIR "/app/ApiDocker"
#RUN dotnet build "ApiDocker/ApiDocker.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "ApiDocker.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ApiDocker.dll"]

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "ApiDocker.dll" ]