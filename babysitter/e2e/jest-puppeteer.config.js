const path = require('path');

const webServerPath = path.resolve(
  __dirname,
  '..',
  'src',
  'BabySitter.Web',
  'BabySitter.Web.csproj'
);
module.exports = {
  launch: {
    ignoreHTTPSErrors: true,
  },
  server: {
    command: `dotnet run --project ${webServerPath}`,
    port: 5001,
    launchTimeout: 60000,
    debug: true,
  },
};
