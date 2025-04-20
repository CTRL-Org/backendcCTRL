# Use the official .NET SDK image to build the app (explicit version)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies (cached better this way)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build and publish the app to the /app directory
RUN dotnet publish -c Release -o /app

# Use the official ASP.NET runtime image with a fixed digest for stability
FROM mcr.microsoft.com/dotnet/aspnet@sha256:c3aee4ea4f51369d1f906b4dbd19b0f74fd34399e5ef59f91b70fcd332f36566 AS runtime
WORKDIR /app
COPY --from=build /app ./

# Expose the port your app listens on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "backendcCTRL.dll"]
