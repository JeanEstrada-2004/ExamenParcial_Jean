# Imagen base de .NET 7 para producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen base de .NET SDK para compilar el código
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solución completa
COPY . .

# Restaurar paquetes y compilar
RUN dotnet restore "ExamenParcial_Jean.sln"
RUN dotnet publish "ExamenParcial_Jean.csproj" -c Release -o /app/publish

# Final: Copiar la app compilada a la imagen de producción
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ExamenParcial_Jean.dll"]
