pushd .\babysitter

$testDirectories = Get-ChildItem -Path .\test -Directory -Filter *.Test,*.Specs 
foreach($folder in $testDirectories) {
    dotnet test $folder.FullName
}

popd