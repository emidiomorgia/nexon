# Use the official .NET SDK base image for the build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the referenced project files (Nexon.ServiceDefaults)
COPY Nexon.ServiceDefaults/Nexon.ServiceDefaults.csproj ./Nexon.ServiceDefaults/

# Copy the main project files (Bff.API)
COPY Bff.API/Bff.API.csproj ./Bff.API/

# Restore dependencies
RUN dotnet restore ./Bff.API/Bff.API.csproj

# Copy the rest of the code
COPY . .

# Compile and publish in Release mode
WORKDIR /src/Bff.API
RUN dotnet publish -c Release -o /app/publish

# Use the official ASP.NET Core base image for execution
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Set the environment variable to force Kestrel on port 80
ENV ASPNETCORE_URLS=http://+:80

# Expose port 80
EXPOSE 80

# Set the entry point to start the application
ENTRYPOINT ["dotnet", "Bff.API.dll"]
