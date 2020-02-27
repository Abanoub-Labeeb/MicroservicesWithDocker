#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
#Port used to expose this web api service on docker 
EXPOSE 50124   
#Port used to expose this web api service on docker using SSL
EXPOSE 44352

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY ["OcelotApiGateway.csproj", "OcelotApiGateway-ocelot/"]
RUN dotnet restore "OcelotApiGateway-ocelot/OcelotApiGateway.csproj"

# copy everything else and build
COPY . "OcelotApiGateway-ocelot/"
WORKDIR /src
RUN dotnet build "OcelotApiGateway-ocelot/OcelotApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OcelotApiGateway-ocelot/OcelotApiGateway.csproj" -c Release -o /app/publish

# build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#create the entry point for this doc file and the parameters that should passed
ENTRYPOINT ["dotnet", "OcelotApiGateway.dll"]