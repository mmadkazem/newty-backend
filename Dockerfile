FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Reservation/Reservation.csproj", "src/Reservation/"]
COPY ["src/Reservation.Application/Reservation.Application.csproj", "src/Reservation.Application/"]
COPY ["src/Reservation.Domain/Reservation.Domain.csproj", "src/Reservation.Domain/"]
COPY ["src/Share/Reservation.Share.Abstract/Reservation.Share.Abstract.csproj", "src/Share/Reservation.Share.Abstract/"]
COPY ["src/Share/Reservation.Share/Reservation.Share.csproj", "src/Share/Reservation.Share/"]
COPY ["src/Reservation.Infrastructure/Reservation.Infrastructure.csproj", "src/Reservation.Infrastructure/"]
RUN dotnet restore "./src/Reservation/Reservation.csproj"
COPY . .
WORKDIR "/src/src/Reservation"
RUN dotnet build "./Reservation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Reservation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reservation.dll"]