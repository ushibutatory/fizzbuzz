FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
RUN mkdir /src
RUN mkdir /src/FizzBuzzSolution
WORKDIR /
COPY ./src/FizzBuzzSolution src/FizzBuzzSolution

# build
WORKDIR /src/FizzBuzzSolution
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

# publish
FROM build AS publish
WORKDIR /src/FizzBuzzSolution/NabeAtsu.Web
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# run
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NabeAtsu.Web.dll"]
