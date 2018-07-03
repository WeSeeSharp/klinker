pushd .\babysitter

$hasErrors = $false
$testDirectories = Get-ChildItem -Path .\test -Directory
foreach($folder in $testDirectories) {
    Write-Host $folder.FullName

    if ($folder.FullName -Match "Test" -or $folder.FullName -Match "Specs") {
        dotnet test $folder.FullName    
    }
    
    if ($hasErrors -or $lastExitCode -ne 0) {
        $hasErrors = $true
    }
}

popd

if ($hasErrors) {
    $host.setshouldexit(1);
}