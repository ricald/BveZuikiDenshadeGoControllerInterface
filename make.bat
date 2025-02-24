@echo off

set FRAMEWORK_PATH=%windir%\Microsoft.NET\Framework\v3.5\msbuild.exe

pushd source\Ricald.ZuikiMasconInterface

echo Cleaning project...
%FRAMEWORK_PATH% Ricald.ZuikiMasconInterface.csproj /p:Platform=x86 /target:clean /p:Configuration=Debug
if errorlevel 1 goto error
%FRAMEWORK_PATH% Ricald.ZuikiMasconInterface.csproj /p:Platform=x86 /target:clean /p:Configuration=Release
if errorlevel 1 goto error
%FRAMEWORK_PATH% Ricald.ZuikiMasconInterface.csproj /p:Platform=x64 /target:clean /p:Configuration=Debug
if errorlevel 1 goto error
%FRAMEWORK_PATH% Ricald.ZuikiMasconInterface.csproj /p:Platform=x64 /target:clean /p:Configuration=Release
if errorlevel 1 goto error

echo Building project...
%FRAMEWORK_PATH% Ricald.ZuikiMasconInterface.csproj /p:Platform=x86 /target:build /p:Configuration=Debug
if errorlevel 1 goto error
%FRAMEWORK_PATH% Ricald.ZuikiMasconInterface.csproj /p:Platform=x86 /target:build /p:Configuration=Release
if errorlevel 1 goto error
%FRAMEWORK_PATH% Ricald.ZuikiMasconInterface.csproj /p:Platform=x64 /target:build /p:Configuration=Debug
if errorlevel 1 goto error
%FRAMEWORK_PATH% Ricald.ZuikiMasconInterface.csproj /p:Platform=x64 /target:build /p:Configuration=Release
if errorlevel 1 goto error

popd

echo Build completed.
goto end

:error
echo Build failed.
exit /b 1

:end
