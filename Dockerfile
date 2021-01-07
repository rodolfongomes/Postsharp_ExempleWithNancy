FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app
COPY ./ ./
RUN dotnet restore "./ExempleWithNancy/ExempleWithNancy.csproj"
RUN dotnet publish "ExempleWithNancy/ExempleWithNancy.csproj" -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ExempleWithNancy.dll", "--urls", "http://*:80"]
