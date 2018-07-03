pushd .\babysitter

$hasErrors = $false
$testDirectories = Get-ChildItem -Path .\test -Directory
foreach($folder in $testDirectories) {
    Write-Host $folder.FullName
    $directoryName = [System.IO.Path]::GetDirectoryName($folder.FullName)
    if ($directoryName -Match "Test" -or $directoryName -Match "Specs") {
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