FROM mcr.microsoft.com/dotnet/sdk:5.0 as debug
WORKDIR /app
COPY . ./
RUN dotnet publish UserService.API -c Release -o UserService.API/out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as prod
WORKDIR /app
COPY --from=debug /app/UserService.API/out .
ENTRYPOINT ["dotnet", "UserService.API.dll"]