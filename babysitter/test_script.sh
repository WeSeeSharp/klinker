set -e

pushd ./babysitter

for dir in `ls ./test`;
do
    if [[ $dir = *Test* ]] 
    then
        pushd "./test/$dir"
        dotnet test
        popd
    fi
done
popd

pushd ./babysitter/src/BabySitter.Web/client-app

yarn test

popd

pushd ./babysitter/e2e

yarn test

popd
