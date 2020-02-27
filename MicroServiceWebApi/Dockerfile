#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 50320
EXPOSE 44366

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY ["MicroServiceWebAPI.WeatherForecast.csproj", "MicroServiceWebApi-forcast/"]
RUN dotnet restore "MicroServiceWebApi-forcast/MicroServiceWebAPI.WeatherForecast.csproj"

# copy everything else and build
COPY . "MicroServiceWebApi-forcast/"
WORKDIR /src
RUN dotnet build "MicroServiceWebApi-forcast/MicroServiceWebAPI.WeatherForecast.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroServiceWebApi-forcast/MicroServiceWebAPI.WeatherForecast.csproj" -c Release -o /app/publish

# build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#create the entry point for this doc file and the parameters that should passed
ENTRYPOINT ["dotnet", "MicroServiceWebAPI.WeatherForecast.dll"]