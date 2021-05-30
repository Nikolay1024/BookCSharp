@echo off
rem Пакетный файл для приложения SimpleCSharpApp.exe,
rem в котором захватывается возвращаемое им значение.
.\bin\debug\SimpleCSharpApp.exe
if "%ERRORLEVEL%" == "0" goto success
:fail
rem Приложение потерпело неудачу,
echo This application has failed!
echo return value %ERRORLEVEL%
goto end
:success
rem Приложение успешно завершено
echo This application has succeeded!
echo return value %ERRORLEVEL%
:end
rem Работа сделана
echo All Done.
