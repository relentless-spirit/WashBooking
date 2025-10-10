# =========================
# 🚧 Stage 1: Build the project
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy all files and restore dependencies
COPY . .
RUN dotnet restore ./WashBooking.API/WashBooking.API.csproj

# Build and publish to folder /out
RUN dotnet publish ./WashBooking.API/WashBooking.API.csproj -c Release -o out

# =========================
# 🚀 Stage 2: Run the project
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy build output
COPY --from=build /app/out .

# Expose port (Render sẽ tự map)
EXPOSE 8080

# Tell ASP.NET to listen on all network interfaces
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "WashBooking.API.dll"]
