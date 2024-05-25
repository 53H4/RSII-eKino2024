#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eKino.WebAPI/eKino.WebAPI.csproj", "eKino.WebAPI/"]
RUN dotnet restore "eKino.WebAPI/eKino.WebAPI.csproj"
COPY . .
WORKDIR "/src/eKino.WebAPI"
RUN dotnet build "eKino.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eKino.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eKino.WebAPI.dll"]