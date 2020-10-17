Set-StrictMode -Version Latest

$SourceRootPath = "$PSScriptRoot\..\src\Horker.MXNet"

$SourceFiles = @(
#    "mxnet\gluon\block.py.json"
#    "mxnet\gluon\loss.py.json"
#    "mxnet\gluon\parameter.py.json"
#    "mxnet\gluon\nn\activations.py.json"
#    "mxnet\gluon\nn\basic_layers.py.json"
#    "mxnet\gluon\nn\conv_layers.py.json"
    "mxnet\gluon\model_zoo\vision\vgg.py.json"
)

$OutRootPath = "$PSScriptRoot\..\src\Horker.MXNet"

$inFiles = $SourceFiles | foreach {
    Get-Item (Join-Path $SourceRootPath $_)
}

foreach ($inFile in $inFiles) {
    Write-Host -NoNewLine $inFile
    $configFile = $inFile -replace "\.json$", ".config.json"
    $outFile = $inFile -replace "\.py\.json$", ".cs"

    if ((Test-Path $outFile) -and
        ($configFile.LastWriteTime -le (Get-Item $outFile).LastWriteTime) -and
        ($inFile.LastWriteTime -le (Get-Item $outFile).LastWriteTime)) {
        Write-Host " ... skip"
        continue
    }

    Write-Host
    & "$PSScriptRoot\..\src\Python2CSharp\bin\Debug\netcoreapp3.1\Python2CSharp.exe" $inFile $configFile $outFile
    if ($LastExitCode -ne 0) {
        break
    }
}
