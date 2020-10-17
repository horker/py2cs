using namespace System.Collections.Generic

[CmdletBinding()]
param(
    [string]$AstFile
)

Set-StrictMode -Version Latest

class EndOfFileException : Exception {}

class Parser {

    [string[]]$Tokens
    [int]$Position
    [string]$Current

    Parser()
    {
    }

    [void] ReadAstFile([string]$AstFile) {
        $t = New-Object List[string]

        $src = Get-Content -Encoding utf8 $AstFile
        $src -split "('(?:[^\\']|\\.)*')|(`"(?:[^\\`"]|\\.)*`")" | foreach {
            if ($_[0] -ne "'" -and $_[0] -ne "`"") {
                $t.AddRange($_ -split "([\d.]+(?:e-\d+)?)|(\w+)|([\[\](),=])|\s+")
            }
            else {
                $t.Add($_)
            }
        }

        $this.Tokens = $t | where { -not [string]::IsNullOrWhitespace($_) }

        $this.Reset()
    }

    [void] Reset() {
        $this.Position = 0
        $this.Current = $this.Tokens[0]
    }

    [string] ReadToken() {
        if ($this.Position -eq $this.Tokens.Length - 1) {
            return "<eof>"
        }
        $t= $this.Current
        $this.Current = $this.Tokens[++$this.Position]
        Write-Verbose "position=$($this.Position), current='$($this.Current)'"
        return $t
    }

    [void] SkipToken([string]$C) {
        if ($null -ne $C -and $this.Current -ne $C) {
            throw "Unexpected token, '$C' expected but actually got '$($this.Current)' at position $($this.Position)"
        }
        $this.ReadToken()
    }

    [object] Parse() {
        return $this.ParseExpression()
    }

    [object] ParseObject() {
        $name = $this.ReadToken()

        $result = New-Object PSObject
        $result | Add-Member NoteProperty _Name $name

        $this.SkipToken("(")

        if ($this.Current -ne ")") {
            for (;;) {
                $key = $this.ReadToken()
                $this.SkipToken("=")
                $value = $this.ParseExpression()

                $result | Add-Member NoteProperty $key $value

                if ($this.Current -ne ",") {
                    break
                }

                $this.SkipToken(",")
            }
        }

        $this.SkipToken(")")

        return $result
    }

    [object] ParseExpression() {
        if ($this.Current -eq "[") {
            return $this.ParseBlock()
        }

        # Literals
        if ($this.Current -match "^([\d.]+(e-\d+)?|None|True|False)$" -or
            $this.Current -match "^['`"]") {
            return $this.ReadToken()
        }

        return $this.ParseObject()
    }

    [PSObject[]] ParseBlock() {
        $result = New-Object List[PSObject]

        $this.SkipToken("[")

        if ($this.Current -ne "]") {
            $expr = $this.ParseExpression()
            $result.Add($expr)
            while ($this.Current -eq ",") {
                $this.SkipToken(",")
                $expr = $this.ParseExpression()
                $result.Add($expr)
            }
        }

        $this.SkipToken("]")

        return $result.ToArray()
    }
}

############################################################

$parser = New-Object Parser
$parser.ReadAstFile($AstFile)

#set-psdebug -trace 2
try {
    $parser.Tokens > tokens.txt
    $parser.Parse()
}
finally {
    set-psdebug -off
}
