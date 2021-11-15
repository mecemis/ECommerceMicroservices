FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/ECommerce.Shared/*csproj Shared/ECommerce.Shared/
COPY Services/PhotoStock/ECommerce.Services.PhotoStock/*.csproj Services/PhotoStock/ECommerce.Services.PhotoStock/
RUN dotnet restore Services/PhotoStock/ECommerce.Services.PhotoStock/*.csproj
COPY . .
RUN dotnet publish Services/PhotoStock/ECommerce.Services.PhotoStock/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","ECommerce.Services.PhotoStock.dll" ]