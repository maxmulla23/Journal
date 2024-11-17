# Use the official .NET runtime image as a base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image as a build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files into the build container
COPY ["JournalBack/JournalBack.csproj", "JournalBack/"]

# Restore project dependencies
RUN dotnet restore "JournalBack/JournalBack.csproj"

# Copy all source files
COPY . .

# Build the application
WORKDIR "/src/JournalBack"
RUN dotnet build "JournalBack.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "JournalBack.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the base image to run the application
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "JournalBack.dll"]
