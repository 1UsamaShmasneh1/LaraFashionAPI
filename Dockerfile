# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["LaraFashionAPI.csproj", "./"]
RUN dotnet restore "LaraFashionAPI.csproj"

# Copy the rest of the code
COPY . .

# Build and publish
RUN dotnet publish "LaraFashionAPI.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Run the app
ENTRYPOINT ["dotnet", "LaraFashionAPI.dll"]# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["LaraFashionAPI.csproj", "./"]
RUN dotnet restore "LaraFashionAPI.csproj"

# Copy the rest of the code
COPY . .

# Build and publish
RUN dotnet publish "LaraFashionAPI.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Run the app
ENTRYPOINT ["dotnet", "LaraFashionAPI.dll"]
