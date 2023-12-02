FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BaseLoop.Connector/BaseLoop.Connector.csproj", "BaseLoop.Connector/"]
COPY ["BaseLoop.Identity/BaseLoop.Identity.csproj", "BaseLoop.Identity/"]
COPY ["BaseLoop.Core/BaseLoop.Core.csproj", "BaseLoop.Core/"]
COPY ["BaseLoop.Product/BaseLoop.Product.csproj", "BaseLoop.Product/"]
RUN dotnet restore "BaseLoop.Connector/BaseLoop.Connector.csproj"
COPY . .
WORKDIR "/src/BaseLoop.Connector"
RUN dotnet build "BaseLoop.Connector.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BaseLoop.Connector.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BaseLoop.Connector.dll"]
