FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["/Sk8M8_API_Sk8M8_API.csproj", "Sk8M8_API/"]
RUN dotnet restore "Sk8M8_API/Sk8M8_API.csproj"
COPY . .
WORKDIR "/src/Sk8M8_API"
RUN dotnet build "Sk8M8_API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sk8M8_API.csproj" -c Release -o /app
RUN apt update
RUN apt -y install ffmpeg

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sk8M8_API.dll"]