#!/bin/bash
echo "Ejecutando migraciones..."
export PATH="$PATH:/root/.dotnet/tools"
dotnet ef database update

echo "Iniciando aplicación..."
dotnet juego-impostor-backend.dll
