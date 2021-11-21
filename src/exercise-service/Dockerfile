FROM mcr.microsoft.com/dotnet/sdk:5.0 as debug
WORKDIR /app
COPY . ./
RUN dotnet publish ExerciseService.API -c Release -o ExerciseService.API/out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as prod
WORKDIR /app
COPY --from=debug /app/ExerciseService.API/out .
ENTRYPOINT ["dotnet", "ExerciseService.API.dll"]