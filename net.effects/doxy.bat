@echo off

echo Generate Documentation

IF "%DOXY_HOME%" == "" (
	echo [WARNING] Unable to generate documentation: Doxygen not found
	exit 0
)

cd "%1"
"%DOXY_HOME%\bin\doxygen.exe" %2