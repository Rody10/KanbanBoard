# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution file
COPY KanbanBoard/KanbanBoard.sln ./

# Copy the project folder and .csproj
COPY KanbanBoard/KanbanBoard/ ./KanbanBoard/

# Restore dependencies
RUN dotnet restore ./KanbanBoard/KanbanBoard.csproj

# Build and publish the application
WORKDIR /app/KanbanBoard
RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/KanbanBoard/out ./

# Expose port 80 (Render default)
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "KanbanBoard.dll"]