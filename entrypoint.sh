#!/bin/bash
echo "Ejecutando migraciones..."
export PATH="$PATH:/root/.dotnet/tools"
dotnet ef database update --project juego-impostor-backend.csproj --startup-project juego-impostor-backend.csproj

echo "Iniciando aplicaci�n..."
dotnet juego-impostor-backend.dll
