$path = Read-Host '¬ведите путь к каталогу'
cd $path
$filesList = @(Get-ChildItem -Path $path -File)

foreach ($file in $filesList)
{
    if (-not (Test-Path -LiteralPath $file.Extension))
    {
        #echo $file.Extension
        New-Item -Path $file.Extension -ItemType Directory
    }

    Move-Item -Path $file.FullName -Destination $file.Extension
}