FROM mcr.microsoft.com/dotnet/sdk:5.0 as debug
RUN mkdir video

WORKDIR /app
COPY . ./
RUN dotnet publish VideoService.API -c Release -o VideoService.API/out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as prod
WORKDIR /app
COPY --from=debug /app/VideoService.API/out .
ENTRYPOINT ["dotnet", "VideoService.API.dll"]

