#In Dockerfile, we provide commands to build images

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY . .

RUN dotnet clean ./StoreApp.sln
RUN dotnet publish WebAPI --configuration Release -o ./publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS run

WORKDIR /app

COPY --from=build /app/publish .

CMD ["dotnet", "WebAPI.dll"]

#docker build . -t chainofazns/storeapp:x.x
#docker run -p 5000:80 -d chainofazns/storeapp
