# Air Quality App
A simple app that displays data from the [OpenAQ API](https://docs.openaq.org/docs). The project intends to showcase software design approaches as well as various design patterns. 

The application has been implemented as a hosted Blazor application (client-server pair). I have approached this as a commercial (enterprise) level project and therefore I have included a hosted backend architected with DDD. Some basic patterns I have included are DI, Factory, CQRS.

## Running
I have developed this using JetBrains Rider 2022.2 on Ubuntu 20.04 LTS. As such I have not tested it on any other environment.
It should be as simple as running both the AirQualityApp.Client and AirQualityApp.Server projects simultaneously from your IDE. 

## Features
- Filter by country and city
- Order by date or location
- Sort by asc/desc
- Change OpenAQ radius and max date range in [appsettings.json](./src/Server/appsettings.json)

## Notes
- The the app uses Flurl.Http as a http-client for the OpenAQ API
- The AirQualityApp.Shared project contains some domain models to be shared between client/server for the sake of simplicity.
- I scaffolded the project using `blazorwasm` template and the command: `dotnet new blazorwasm --hosted -n AirQualityApp -o src`