# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files and restore
COPY *.sln ./
COPY KanbanBoard/*.csproj ./KanbanBoard/
RUN dotnet restore ./KanbanBoard/KanbanBoard.csproj

# Copy the rest of the files and build the project
COPY KanbanBoard/. ./KanbanBoard/
WORKDIR /app/KanbanBoard
RUN dotnet publish -c Release -o out

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/KanbanBoard/out ./

# Expose port 80 for Render
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "KanbanBoard.dll"]

      