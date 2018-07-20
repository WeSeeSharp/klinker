set -e

pushd ./babysitter

dotnet restore

popd

pushd ./babysitter/src/BabySitter.Web/client-app

yarn install

popd

pushd ./babysitter/e2e

yarn install

popd
