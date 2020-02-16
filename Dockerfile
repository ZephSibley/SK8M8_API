FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-stretch AS build
WORKDIR /src
COPY ["/Sk8M8_API/Sk8M8_API.csproj", "Sk8M8_API/"]
COPY ["/Sk8M8_API.Tests/Sk8M8_API.Tests.csproj", "Sk8M8_API.Tests/"]
RUN dotnet restore "Sk8M8_API/Sk8M8_API.csproj"
COPY . .
RUN dotnet test Sk8M8_API.Tests -c Release
WORKDIR "/src/Sk8M8_API"
RUN dotnet build "Sk8M8_API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sk8M8_API.csproj" -c Release -o /app
#RUN apt update
#RUN apt -y install ffmpeg

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

HEALTHCHECK CMD curl --fail http://localhost:80/ || exit 1

ENTRYPOINT ["dotnet", "Sk8M8_API.dll"]