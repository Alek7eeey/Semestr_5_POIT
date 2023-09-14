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

if %c% == + (
set /a sum = %a% + %b%
echo result = %sum%
)

if %c% == - (
set /a dif = %a% - %b%
echo result = %dif%
)

if %c% == * (
set /a mul = %a% * %b%
echo result = %mul%
)

if %c% == / (
set /a div = %a% / %b%
echo result = %div%
)

if %c% == %% (
set /a ost = %a% %% %b%
echo result = %ost%
)

pause