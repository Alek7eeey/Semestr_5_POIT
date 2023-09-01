@echo off
color 79
title MyLab
chcp 65001 > nul

set a=%1%
set b=%2%
set c=%3%

echo Первый параметр: %a%
echo Второй параметр: %b%
echo Третий параметр: %c%

if %c% == %+%(
echo +
)

set str1=Hello
set str2=World

if "%str1%"=="%str2%" (
    echo Строки равны
) else (
    echo Строки не равны
)

pause