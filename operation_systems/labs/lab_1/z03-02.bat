@echo off
color 79
title MyLab
chcp 65001 > nul

rem получаем и записываем данные в переменную
rem %0 - имя файла
set ScriptName=%0
rem путь к файлу + d - диск + p - путь
set ScriptPath=%~dp0

rem for %%A in (...): Это начало цикла for, где %%A - это временная переменная
rem "%~dp0%~nx0": Это выражение представляет собой полный путь к текущему bat
rem do set "FileDateTime=%%~tA" Она берет значение, полученное из %~dp0%~nx0 (полный путь к bat-файлу),
rem извлекает дату и время создания файла (%%~tA), 
for %%A in ("%~dp0%~nx0") do set "FileDateTime=%%~tA"

echo имя этого bat-файла: %ScriptName%
echo этот bat-файл создан: %FileDateTime%
echo путь bat-файла: %ScriptPath%
pause