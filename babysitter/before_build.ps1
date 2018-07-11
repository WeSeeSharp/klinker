pushd .\babysitter

dotnet restore

popd

pushd .\babysitter\src\BabySitter.Web\client-app

yarn install

popd