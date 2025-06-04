## Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.
#
## Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
## SDK (para build y para ejecutar ef)
##FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#
## Esta fase se usa para compilar el proyecto de servicio
## Build project
##FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#FROM base AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["juego-impostor-backend.csproj", "."]
#RUN dotnet restore "./juego-impostor-backend.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "./juego-impostor-backend.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
## Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./juego-impostor-backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
## Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
#FROM base AS final
#WORKDIR /app
##COPY --from=publish /app/publish .
##ENTRYPOINT ["dotnet", "juego-impostor-backend.dll"]

















FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar csproj y restaurar
COPY ["juego-impostor-backend.csproj", "."]
RUN dotnet restore

# Copiar todo y compilar
COPY . .
RUN dotnet build -c Release -o out
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false


ENV PATH="$PATH:/root/.dotnet/tools"

# Dentro de FROM build AS build o FROM publish AS publish (mejor aquí):
RUN dotnet tool install --global dotnet-ef \
    && export PATH="$PATH:/root/.dotnet/tools" \
    && dotnet ef database update --project juego-impostor-backend.csproj



# Imagen final
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

# ✅ Instalar dotnet-ef y asegurar el PATH
#RUN dotnet tool install --global dotnet-ef
#ENV PATH="$PATH:/root/.dotnet/tools"

# Copiar publicación y script de entrada
COPY --from=build /app/publish .
COPY entrypoint.sh .

# ✅ Hacer que se ejecute el script
ENTRYPOINT ["bash", "entrypoint.sh"]
