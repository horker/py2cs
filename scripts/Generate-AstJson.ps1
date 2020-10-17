Set-StrictMode -Version Latest

$SourceRootPath = "$PSScriptRoot\..\incubator-mxnet\python\"

$SourceFiles = @(
#    "mxnet"
    "mxnet\gluon\block.py"
    "mxnet\gluon\loss.py"
    "mxnet\gluon\parameter.py"
    "mxnet\gluon\nn\activations.py"
    "mxnet\gluon\nn\basic_layers.py"
    "mxnet\gluon\nn\conv_layers.py"
    "mxnet\gluon\model_zoo\vision\vgg.py"
)

$OutRootPath = "$PSScriptRoot\..\src\Horker.MXNet"

$inFiles = $SourceFiles | foreach {
    Get-Item (Join-Path $SourceRootPath $_)
}

$basePathLength = (Get-Item $SourceRootPath).FullName.Length

foreach ($inFile in $inFiles) {
    Write-Host -NoNewLine $inFile
    $path = (Split-Path -Parent $inFile).Substring($basePathLength)
    $null = mkdir $OutRootPath\$path -force
    $outFile = "$OutRootPath\$path\$($inFile.Name + ".json")"

    if ((Test-Path $outFile) -and
        $inFile.LastWriteTime -le (Get-Item $outFile).LastWriteTime) {
        Write-Host " ... skip"
        continue
    }

    Write-Host
    python.exe "$PSScriptRoot\..\scripts\print_ast.py" $inFile temp.ast
    if ($LastExitCode -ne 0) {
        break
    }
    & "$PSScriptRoot\..\scripts\Parse-Ast.ps1" temp.ast | ConvertTo-Json -Depth 99 | Set-Content -Encoding utf8 $outFile
}
