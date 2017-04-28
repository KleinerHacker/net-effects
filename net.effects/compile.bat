@echo off

echo Start FX compiling in %1
echo With %DXSDK_TOOLS%\fxc.exe
echo.
echo.
echo.

cd %1
for /r %%i in (*.fx) do	(@echo Compile %%i & "%DXSDK_TOOLS%\fxc.exe" /T ps_3_0 /E main "/Fo%~2\%%~ni.ps" "%%i" & echo ********************************)

cd..
cd..