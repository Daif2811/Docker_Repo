# Base image for running the app
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2019 AS base
USER ContainerUser															   
WORKDIR /app
EXPOSE 8080
EXPOSE 443

# Build stage
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build 
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2019 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["*.sln", "./"]
COPY ["Docker_Test/Docker_Test.csproj", "Docker_Test/"]	
RUN dotnet restore "Docker_Test.sln"

# Copy all source code
COPY . ./

# Build the project
RUN dotnet build "Docker_Test.sln" -c Release  --no-restore    

# Publish stage
FROM build AS publish
RUN dotnet publish "Docker_Test/Docker_Test.csproj" -c Release   -o /app/publish --no-build /p:UseAppHost=false  


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
#RUN dotnet build Docker_Test.csproj -c Release -o /app/build
#
## Publish stage
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish Docker_Test.csproj -c Release -o /app/publish --no-build  /p:UseAppHost=false
#
#
## Final image
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Docker_Test.dll"]
#=========================================================================================





# Docker commands to build and run the container =========================================
#Remove folder
#rm -rf FolderName
#rm -f filename

#Build
#docker build -t docker-test-image .
#docker build -f Docker_Test/Dockerfile -t docker-test-image . 

#Run
#docker container run --name docker-test-container -d -p 7080:8080 -e ASPNETCORE_URLS="http://+:8080"  docker-test-image
#docker container run --name docker-test-container -d -p 7080:8080 -p 7081:443  -e ASPNETCORE_URLS="http://+:8080;https://+:443"  docker-test-image
#docker container run --name docker-test-container -v $(pwd):/app:ro -d  -p 3003:8080  -e ASPNETCORE_URLS="http://+:8080"  docker-test-image          for linux container
#docker container run --name docker-test-container -v ${PWD}:C:\src:ro -d -p 3003:8080 -e ASPNETCORE_URLS="http://+:8080" docker-test-image           for windows container

