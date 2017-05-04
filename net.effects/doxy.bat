@echo off

echo Generate Documentation

cd "%1"
"%DOXY_HOME%\bin\doxygen.exe" %2