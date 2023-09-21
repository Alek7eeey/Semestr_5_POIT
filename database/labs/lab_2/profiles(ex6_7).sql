-- Задание 6. Создайте профиль безопасности с именем PF_XXXCORE,
-- имеющий опции, аналогичные примеру из лекции.

CREATE PROFILE PF_KADCORE LIMIT
    FAILED_LOGIN_ATTEMPTS 7 --count of login attempts
    SESSIONS_PER_USER 3 --count session for user
    PASSWORD_LIFE_TIME 60 --password living time
    PASSWORD_REUSE_TIME 365 --time to reuse password
    PASSWORD_LOCK_TIME 1 --password blocking time
    CONNECT_TIME 180 --time for connection
    IDLE_TIME 30; -- downtime [время простоя]

drop profile PF_KADCORE;
    -- Задание 7. Получите список всех профилей БД.
    -- Получите значения всех параметров профиля PF_XXXCORE.
-- Получите значения всех параметров профиля DEFAULT.

SELECT * FROM DBA_PROFILES;
SELECT * FROM DBA_PROFILES WHERE PROFILE = 'PF_KADCORE';
SELECT * FROM DBA_PROFILES WHERE PROFILE = 'DEFAULT';
