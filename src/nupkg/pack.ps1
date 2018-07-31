Push-Location $PSScriptRoot\..\ssrt
dotnet pack -c Release -o $PSScriptRoot
Pop-Location
