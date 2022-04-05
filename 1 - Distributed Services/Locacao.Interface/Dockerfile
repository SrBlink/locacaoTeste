#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["1 - Distributed Services/Locacao.Interface/Locacao.Interface.csproj", "1 - Distributed Services/Locacao.Interface/"]
COPY ["2 - Application/Locacao.Application/Locacao.Application.csproj", "2 - Application/Locacao.Application/"]
COPY ["3 - Domain/Locacao.Domain/Locacao.Domain.csproj", "3 - Domain/Locacao.Domain/"]
COPY ["4 - Infrastructure/4.2 - Cross Cuting/Locacao.Infrastructure.CrossCuting/Locacao.Infrastructure.CrossCuting.csproj", "4 - Infrastructure/4.2 - Cross Cuting/Locacao.Infrastructure.CrossCuting/"]
COPY ["4 - Infrastructure/4.2 - Cross Cuting/Locacao.Infrastructure.CrossCuting.IoC/Locacao.Infrastructure.CrossCuting.IoC.csproj", "4 - Infrastructure/4.2 - Cross Cuting/Locacao.Infrastructure.CrossCuting.IoC/"]
COPY ["4 - Infrastructure/4.1 - Data Access/Locacao.Infrastructure.DataAccess/Locacao.Infrastructure.DataAccess.csproj", "4 - Infrastructure/4.1 - Data Access/Locacao.Infrastructure.DataAccess/"]
RUN dotnet restore "1 - Distributed Services/Locacao.Interface/Locacao.Interface.csproj"
COPY . .
WORKDIR "/src/1 - Distributed Services/Locacao.Interface"
RUN dotnet build "Locacao.Interface.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Locacao.Interface.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Locacao.Interface.dll"]