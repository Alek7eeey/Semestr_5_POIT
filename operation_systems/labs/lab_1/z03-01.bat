@echo off
color 79
title MyLab
chcp 65001 > nul
@echo off
echo текущий пользователь: %USERNAME%
echo текущие даты и время: %date%, %time%
echo имя компьютера: %COMPUTERNAME%
pause