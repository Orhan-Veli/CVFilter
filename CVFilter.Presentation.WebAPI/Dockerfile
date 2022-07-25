# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY CVFilter.Presentation.WebAPI.csproj ./

RUN dotnet restore CVFilter.Presentation.WebAPI.csproj 
COPY . .
RUN dotnet publish CVFilter.Presentation.WebAPI.csproj -c Release -o out 

FROM mcr.microsoft.com/dotnet/sdk:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS http://*:7000
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 7000
ENTRYPOINT ["dotnet","CVFilter.Presentation.WebAPI.dll"]