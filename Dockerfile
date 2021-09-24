#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /src
COPY *.sln .
COPY Rocky/*csproj Rocky/
COPY Repository/*csproj Repository/
COPY Database/*csproj Database/
COPY Model/*csproj Model/


RUN dotnet restore Rocky/*.csproj

COPY . .
# #Testing
# FROM base AS testing
# WORKDIR /src/Rocky
# RUN dotnet build
# #WORKDIR /src/Rocky.Testnew
# WORKDIR /src/Rocky.Testnew
# RUN dotnet test
#Publishing
FROM base AS publish
WORKDIR /src/Rocky
RUN dotnet publish -c Release -o /src/publish
#Get the runtime into a folder called app
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
COPY --from=publish /src/Rocky/wwwroot/Json/* JSONfiles/
#ENTRYPOINT ["dotnet", "Rocky.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Rocky.dll