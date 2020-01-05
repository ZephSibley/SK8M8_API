FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["Sk8M8_API.csproj", "Sk8M8_API/"]

RUN dotnet restore "Sk8M8_API/Sk8M8_API.csproj"
COPY . .
WORKDIR "/src/Sk8M8_API"
RUN dotnet build "Sk8M8_API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sk8M8_API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sk8M8_API.dll"]