@echo off
rem a batch file for SimpleCSharp.exe
rem which captures the app's return value
.\bin\Debug\SimpleCSharpConsoleApp.exe /arg1 -arg2 -
@if %ERRORLEVEL% == "0" GOTO success

:fail
echo This app has failed
echo return value = %ERRORLEVEL%
goto end


:success
echo This app has succeeded
echo return value = %ERRORLEVEL%

:end
echo All Done