# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:3.1 as base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /src
COPY ["CVFilter.Presentation.WebAPI/CVFilter.Presentation.WebAPI.csproj", "CVFilter.Presentation.WebAPI/"]
COPY ["CVFilter.Application/CVFilter.Application.csproj", "CVFilter.Application/"]
COPY ["CVFilter.Infrastructure/CVFilter.Infrastructure.csproj", "CVFilter.Infrastructure/"]
COPY ["CVFilter.Domain/CVFilter.Domain.csproj", "CVFilter.Domain/"]

RUN dotnet restore "CVFilter.Presentation.WebAPI/CVFilter.Presentation.WebAPI.csproj"
COPY . .
WORKDIR "/src/CVFilter.Presentation.WebAPI"
RUN dotnet build "CVFilter.Presentation.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CVFilter.Presentation.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:7000
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 7000
ENTRYPOINT ["dotnet","CVFilter.Presentation.WebAPI.dll"]