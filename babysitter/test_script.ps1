pushd .\babysitter

$hasErrors = $false
$testDirectories = Get-ChildItem -Path .\test\* -Directory -Include *.Test,*.Specs
foreach($folder in $testDirectories) {
    dotnet test $folder.FullName
    
    if ($hasErrors -or $lastExitCode -ne 0) {
        $hasErrors = $true
    }
}

popd

if ($hasErrors) {
    $host.setshouldexit(1);
}