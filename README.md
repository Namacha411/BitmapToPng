# BMP to PNG

## Use

```powershell
bpm2png.exe [folderpath]
```

## Build option 

build single binary
```powershell
dotnet publish -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
```