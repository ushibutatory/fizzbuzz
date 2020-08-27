FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /
RUN mkdir /src
RUN mkdir /src/FizzBuzzSolution
WORKDIR /
COPY ./src/FizzBuzzSolution src/FizzBuzzSolution

# build
WORKDIR /src/FizzBuzzSolution
ARG MY_NUGET_SOURCE
RUN echo ${MY_NUGET_SOURCE}
RUN dotnet restore -s https://api.nuget.org/v3/index.json -s ${MY_NUGET_SOURCE}
RUN dotnet build

# publish
WORKDIR /
RUN mkdir /release
WORKDIR /src/FizzBuzzSolution/NabeAtsu.Web
RUN dotnet publish -c Release -o /release

# deploy to heroku
WORKDIR /release
CMD ASPNETCORE_URLS=http://*:$PORT dotnet NabeAtsu.Web.dll
