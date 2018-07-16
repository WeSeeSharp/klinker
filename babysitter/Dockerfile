FROM microsoft/dotnet:2.1-sdk AS build

RUN curl -sL https://deb.nodesource.com/setup_8.x | bash -
RUN apt-get install -y nodejs
RUN npm install --global yarn@1.7.0

WORKDIR /app

COPY ./ ./
RUN dotnet restore

WORKDIR /app/src/BabySitter.Web
RUN cd client-app && yarn install && yarn build:prod
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/src/BabySitter.Web/out ./
ENTRYPOINT ["dotnet", "BabySitter.Web.dll"]