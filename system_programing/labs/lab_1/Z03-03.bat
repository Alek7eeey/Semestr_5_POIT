@echo off
color 79
title MyLab
chcp 65001 > nul

echo Строка параметров: %*
echo Первый параметр: %1
echo Второй параметр: %2
echo Третий параметр: %3
echo Четвёртый параметр: %4

pause