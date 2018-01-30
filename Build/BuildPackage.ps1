$buildToolPath = "..\..\Site\Bin\PX.CommandLine.exe"
$vswherePath = "..\..\Demo\Build\vswhere.exe"
$webSitePath = "..\..\Site"
$outPackagePath = "..\..\Builds\YogiFon.zip"
$binSourceFolder = "..\YogiFonLib\YogiFonLib\bin\Release\*"
$projectSourceFolder = "..\YogiFon\*"
$tmpFolder = "..\..\Builds\Temp"
$tmpBinFolder = "..\..\Builds\Temp\Bin"
$solutionPath = "..\YogiFonLib\YogiFonLib.sln"

$MSBuildPath = & $vswherePath -latest -products * -requires Microsoft.Component.MSBuild -property installationPath
if ($MSBuildPath) {
  $MSBuildPath = join-path $MSBuildPath 'MSBuild\15.0\Bin\MSBuild.exe'
  if (test-path $MSBuildPath) {
    Write-Host $MSBuildPath
  }
  else
  {
    Write-Host "Failed to find MSBuild"
  }
}
else
{
    Write-Host "Failed to find MSBuild"
}

& $MSBuildPath $solutionPath /p:Configuration=Release /p:Platform="Any CPU" /verbosity:minimal


if (!(Test-Path $tmpFolder))
{
    md $tmpFolder >$null 2>&1
}
else
{
    Remove-Item $tmpFolder -recurse -Exclude "Temp"    
}

Copy-Item -Path $projectSourceFolder -Recurse -Destination $tmpFolder

if (!(Test-Path $tmpBinFolder))
{
    md $tmpBinFolder >$null 2>&1
}

Copy-Item -Path $binSourceFolder -Recurse -Destination $tmpBinFolder

& $buildToolPath /method BuildProject /website $webSitePath /in $tmpFolder /out $outPackagePath /description "Test"






