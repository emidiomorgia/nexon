# Fase 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia i file di progetto di Bff.Application e Bff.API per ripristinare le dipendenze
#COPY ../Bff.Application/Bff.Application.csproj ./src/Bff.Application/
COPY Nexon.ServiceDefaults/Nexon.ServiceDefaults.csproj ./src/Nexon.ServiceDefaults/
#COPY Bff.API.csproj ./src/Bff.API/
#RUN dotnet restore ./src/Bff.API/Bff.API.csproj
#
## Copia tutti i file sorgenti necessari
##COPY ../Bff.Application ./src/Bff.Application/
#COPY ../Nexon.ServiceDefaults ./src/Nexon.ServiceDefaults/
#COPY . ./src/Bff.API/
#
## Imposta la directory di lavoro per la build e crea l'applicazione
#WORKDIR /app/src/Bff.API
#RUN dotnet publish -c Release -o /app/publish
#
## Fase 2: Runtime
#FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
#WORKDIR /app
#
## Copia i file pubblicati dalla fase di build
#COPY --from=build /app/publish .
#
## Espone le porte predefinite di Kestrel per .NET 8+
#EXPOSE 8080 8443
#
## Avvia l'applicazione
#ENTRYPOINT ["dotnet", "Bff.API.dll"]
