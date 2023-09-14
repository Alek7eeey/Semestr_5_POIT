@echo off
color 79
title MyLab
chcp 65001 > nul

set a=%1%
set b=%2%
set c=%3%

rem /a - ключ указывает на арифметическую операцию 

set /a sum = %a% + %b%
set /a mul = %a% * %b%
set /a div = %c% / %b%
set /a calcul = (%b% - %a%) * (%a% - %b%)

echo Первый параметр: %a%
echo Второй параметр: %b%
echo Третий параметр: %c%

echo %a% + %b% = %sum%
echo %a% * %b% = %mul%
echo %c% / %b% = %div%
echo (%b% - %a%) * (%a% - %b%) = %calcul%

pause