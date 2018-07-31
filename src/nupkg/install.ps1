. $PSScriptRoot\pack.ps1
if ($LASTEXITCODE -ne 0) { exit }
if ((dotnet tool list -g | Where-Object { $_.Contains('ssrt') })) {
    dotnet tool uninstall -g ssrt
}
dotnet tool install -g ssrt
