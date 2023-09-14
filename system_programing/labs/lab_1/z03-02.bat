@echo off
color 79
title MyLab
chcp 65001 > nul

rem получаем и записываем данные в переменную
rem %0 - имя файла
set ScriptName=%0
rem путь к файлу + d - диск + p - путь
set ScriptPath=%~dp0

echo имя этого bat-файла: %ScriptName%
echo этот bat-файл создан: 

rem Параметр /a-d указывает, что нужно показать только файлы и не показывать подкаталоги.
rem сортировка по дате в обратном порядке (/o-d)
rem Флаг /T:C указывает сортировать по "последнему изменению"
for /f "tokens=1,2" %%a in ('dir Z03-02.bat /a-d /o-d /T:C') do @echo %%a %%b | find ":"
echo путь bat-файла: %ScriptPath%
pause