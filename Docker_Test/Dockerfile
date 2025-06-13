# Base image for running the app
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2019 AS base     # Windows
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER ContainerUser
WORKDIR /app
EXPOSE 8080
EXPOSE 443

# Build stage
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2019 AS build      # Windows
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project file and restore dependencies
COPY ["*.sln", "./"]
COPY ["Docker_Test/Docker_Test.csproj", "Docker_Test/"]	
#COPY Docker_Test.csproj ./

RUN dotnet restore "Docker_Test.sln"
#RUN dotnet restore Docker_Test.csproj

# Copy all source code
COPY . ./

# Build the project
RUN dotnet build "Docker_Test.sln" -c $BUILD_CONFIGURATION --no-restore
#RUN dotnet build "Docker_Test.sln" -c %BUILD_CONFIGURATION%  --no-restore    #windows
#RUN dotnet build Docker_Test.csproj -c %BUILD_CONFIGURATION% -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Docker_Test/Docker_Test.csproj" -c $BUILD_CONFIGURATION -o /app/publish --no-build /p:UseAppHost=false
#RUN dotnet publish "Docker_Test/Docker_Test.csproj" -c %BUILD_CONFIGURATION%  -o /app/publish --no-build /p:UseAppHost=false   #windows
#RUN dotnet publish Docker_Test.csproj -c %BUILD_CONFIGURATION% -o /app/publish --no-build  /p:UseAppHost=false


# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker_Test.dll"]




#=========================================================================================
## Base image for running the app
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 443
#
## Build stage
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#
## Copy project file and restore dependencies
#COPY Docker_Test.csproj ./
#RUN dotnet restore Docker_Test.csproj
#
## Copy all source code
#COPY . ./
#
## Build the project
#RUN dotnet build Docker_Test.csproj -c $BUILD_CONFIGURATION -o /app/build
#
## Publish stage
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish Docker_Test.csproj -c $BUILD_CONFIGURATION -o /app/publish --no-build  /p:UseAppHost=false
#
#
## Final image
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Docker_Test.dll"]
#=========================================================================================





#Build
#docker build -t docker-test-image .
#docker build -f Docker_Test/Dockerfile -t docker-test-image . 

#Run
#docker container run --name docker-test-container -d -p 7080:8080 -e ASPNETCORE_URLS="http://+:8080"  docker-test-image
#docker container run --name docker-test-container -d -p 7080:8080 -p 7081:443  -e ASPNETCORE_URLS="http://+:8080;https://+:443"  docker-test-image
#docker container run --name docker-test-container -v $(pwd):/app:ro -d  -p 3003:8080  -e ASPNETCORE_URLS="http://+:8080"  docker-test-image          for linux container
#docker container run --name docker-test-container -v ${PWD}:C:\src:ro -d -p 3003:8080 -e ASPNETCORE_URLS="http://+:8080" docker-test-image           for windows container

