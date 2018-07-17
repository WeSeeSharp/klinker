pushd .\babysitter

dotnet restore

popd

pushd .\babysitter\src\BabySitter.Web\client-app

yarn install

popd

pushd .\e2e

yarn install

popd
