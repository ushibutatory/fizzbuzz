FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /
RUN mkdir /src
RUN mkdir /src/FizzBuzzSolution
WORKDIR /
COPY ./src/FizzBuzzSolution src/FizzBuzzSolution

# build
WORKDIR /src/FizzBuzzSolution
RUN dotnet restore
RUN dotnet build -c Release

# publish
WORKDIR /
RUN mkdir /release
WORKDIR /src/FizzBuzzSolution/NabeAtsu.Web
RUN dotnet publish -c Release -o /release

# deploy to heroku
WORKDIR /release
CMD ASPNETCORE_URLS=http://*:$PORT dotnet NabeAtsu.Web.dll
