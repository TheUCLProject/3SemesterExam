#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/", "Apps/"]
RUN dotnet restore "Apps/Webapp/Webapp.csproj"

WORKDIR "/src/Apps/"
COPY . .

WORKDIR "/src/Apps/Webapp/"
RUN dotnet build "Webapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Webapp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Webapp.dll"]

WORKDIR /app
COPY ["Webapp/Database/Data", "/Database/Data"]