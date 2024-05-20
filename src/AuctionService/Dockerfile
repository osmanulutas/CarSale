FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80

# Copy csproj and restore as distinct layers. 
#Use of the same Comy command for every docker project teke advange of docker cashing
COPY Carsties.sln Carsties.sln
COPY src/AuctionService/AuctionService.csproj src/AuctionService/AuctionService.csproj
COPY src/SearchService/SearchService.csproj src/SearchService/SearchService.csproj
COPY src/GatewayService/GatewayService.csproj src/GatewayService/GatewayService.csproj
COPY src/Contracts/Contracts.csproj src/Contracts/Contracts.csproj
COPY src/IdentityService/IdentityService.csproj src/IdentityService/IdentityService.csproj


#Restore Package Deps
RUN dotnet restore Carsties.sln

# Copy the app folder over
COPY src/AuctionService/ src/AuctionService/
COPY src/SearchService/ src/SearchService/

WORKDIR /app/src/AuctionService

RUN dotnet build -c Release -o /app/src/out

