[![Build status](https://ci.appveyor.com/api/projects/status/bwdlestcykb6vrkq/branch/master?svg=true)](https://ci.appveyor.com/project/bryce-klinker/klinker/branch/master)

# Babysitter Kata

## Background

This kata simulates a babysitter working and getting paid for one night. The rules are pretty straight forward.

The babysitter:

- starts no earlier than 5:00PM
- leaves no later than 4:00AM
- gets paid $12/hour from start-time to bedtime
- gets paid $8/hour from bedtime to midnight
- gets paid $16/hour from midnight to end of job
- gets paid for full hours (no fractional hours)

## Feature

_As a babysitter<br>
In order to get paid for 1 night of work<br>
I want to calculate my nightly charge<br>_

# NOTE:

This version has been blown up in terms of scope. The goal of starting this was to create a sample of how an application could be built using ASP.NET Core and React.

## Required Software

- Node >= 8.0.0
- dotnet-sdk >= 2.1.0
- yarn >= 1.7.0
- npm >= 6.0.0

## Running the Application

Running the "production" version of the app can be done using:

```bash
docker-compose build # Prepares the docker image for use in the next command
docker-compose up # Runs a docker container for postgres and one for the ASP.NET Core site.
```

## Running Tests

### Dotnet Tests

The dotnet tests can be run using the command:

```bash
dotnet test # This will output some errors because the projects in ./src don't have tests.
```

### Front-end Tests

The front-end tests can be run with the following:

```bash
cd ./src/BabySitter.Web/client-app
yarn install
yarn test
```

### End-to-End Tests

The end-to-end tests ensure the entire system works together, honestly right now they need a little love, they can be run with the following:

```bash
cd e2e
yarn test
```
