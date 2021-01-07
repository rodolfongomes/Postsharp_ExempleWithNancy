FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app

# Copy everything and build
COPY . ./

RUN dotnet restore "./ExempleWithNancy.csproj"
RUN dotnet publish "ExempleWithNancy.csproj" -c Release -o out


FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ExempleWithNancy.dll"]
