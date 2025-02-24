@echo off

call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"

pushd source\Ricald.ZuikiMasconInterface

echo Cleaning project...
msbuild Ricald.ZuikiMasconInterface.csproj /p:TargetFrameworkVersion=v3.5 /p:Platform=AnyCPU /target:clean /p:Configuration=Debug
if errorlevel 1 goto error
msbuild Ricald.ZuikiMasconInterface.csproj /p:TargetFrameworkVersion=v3.5 /p:Platform=AnyCPU /target:clean /p:Configuration=Release
if errorlevel 1 goto error
msbuild Ricald.ZuikiMasconInterface.csproj /p:TargetFrameworkVersion=v4.8 /p:Platform=AnyCPU /target:clean /p:Configuration=Debug
if errorlevel 1 goto error
msbuild Ricald.ZuikiMasconInterface.csproj /p:TargetFrameworkVersion=v4.8 /p:Platform=AnyCPU /target:clean /p:Configuration=Release
if errorlevel 1 goto error

echo Building project...
msbuild Ricald.ZuikiMasconInterface.csproj /p:TargetFrameworkVersion=v3.5 /p:Platform=AnyCPU /target:build /p:Configuration=Debug
if errorlevel 1 goto error
msbuild Ricald.ZuikiMasconInterface.csproj /p:TargetFrameworkVersion=v3.5 /p:Platform=AnyCPU /target:build /p:Configuration=Release
if errorlevel 1 goto error
msbuild Ricald.ZuikiMasconInterface.csproj /p:TargetFrameworkVersion=v4.8 /p:Platform=AnyCPU /target:build /p:Configuration=Debug
if errorlevel 1 goto error
msbuild Ricald.ZuikiMasconInterface.csproj /p:TargetFrameworkVersion=v4.8 /p:Platform=AnyCPU /target:build /p:Configuration=Release
if errorlevel 1 goto error

popd

echo Build completed.
goto end

:error
echo Build failed.
exit /b 1

:end
