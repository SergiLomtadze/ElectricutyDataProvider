FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . .
WORKDIR "/src/ElectrcutyDataProvider.WebApi"
RUN dotnet publish "ElectrcutyDataProvider.WebApi.csproj" -c Release -o /app/publish 

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ElectrcutyDataProvider.WebApi.dll"]