#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/", "MedarbejderKompetencer/"]
RUN dotnet restore "MedarbejderKompetencer/Api/MedarbejderKompetencer.Api.csproj"

WORKDIR "/src/MedarbejderKompetencer"
COPY . .

WORKDIR "/src/MedarbejderKompetencer/Api"
RUN dotnet build "MedarbejderKompetencer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MedarbejderKompetencer.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedarbejderKompetencer.Api.dll"]

WORKDIR /app
COPY ["Database/Data", "../Database/Data"]