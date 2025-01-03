# Usa l'immagine base ufficiale di .NET SDK per il build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia i file del progetto referenziato (Nexon.ServiceDefaults)
COPY Nexon.ServiceDefaults/Nexon.ServiceDefaults.csproj ./Nexon.ServiceDefaults/

# Copia i file del progetto principale (Bff.API)
COPY Bff.API/Bff.API.csproj ./Bff.API/

# Ripristina le dipendenze
RUN dotnet restore ./Bff.API/Bff.API.csproj

# Copia tutto il resto del codice
COPY . .

# Compila e pubblica in modalità Release
WORKDIR /src/Bff.API
RUN dotnet publish -c Release -o /app/publish

# Usa l'immagine base ufficiale di ASP.NET Core per l'esecuzione
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Imposta la variabile d'ambiente per forzare Kestrel sulla porta 80
ENV ASPNETCORE_URLS=http://+:80

# Espone la porta 80
EXPOSE 80

# Imposta l'entrypoint per avviare l'applicazione
ENTRYPOINT ["dotnet", "Bff.API.dll"]
