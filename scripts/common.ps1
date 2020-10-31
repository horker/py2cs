Set-StrictMode -Version Latest

function ConvertTo-CamelCase([string]$s, [bool]$upper = $true)
{
    if ($s -eq "_") {
        return $s
    }

    if ($s -cmatch "^[A-Z0-9_]+$") {
        return $s
    }

    $special = $false
    if ($s -match "^__(.+)__$") {
        $special = $true
        $s = $matches[1]
    }

    $s = $s -replace "^(?:__)?(.+)(?:__)?$", '$1'

    $words = $s -split "(?<=.)_"
    $result = ($words | foreach { $i = 0 } { ++$i; ($upper -or $i -gt 1) -and $_.Length -gt 1 ? [char]::ToUpper($_[0]) + $_.Substring(1) : $_ }) -join ""

    if ($special) {
        $result = "__" + $result + "__"
    }

    $result
}
