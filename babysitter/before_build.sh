set -e

dotnet restore ./babysitter/BabySitter.sln

pushd ./babysitter/src/BabySitter.Web/client-app

yarn install

popd

pushd ./babysitter/e2e

yarn install

popd
