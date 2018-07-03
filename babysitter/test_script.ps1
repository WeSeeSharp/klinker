pushd .\babysitter

$hasErrors = $false
$testDirectories = Get-ChildItem -Path .\test\* -Directory
foreach($folder in $testDirectories) {
    if ($folder.FullName -notcontains "Test" -or $folder.FullName -notcontains "Specs")
        continue
    
    dotnet test $folder.FullName
    
    if ($hasErrors -or $lastExitCode -ne 0) {
        $hasErrors = $true
    }
}

popd

if ($hasErrors) {
    $host.setshouldexit(1);
}