-- Задание 4. Создайте роль с именем RL_XXXCORE. Назначьте ей следующие системные привилегии:
-- 	разрешение на соединение с сервером;
-- 	разрешение создавать и удалять таблицы,
-- представления,
-- процедуры и функции.

ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE; --use hidden session param

CREATE ROLE RL_KADCORE;
GRANT
    CONNECT,
    CREATE TABLE,
    CREATE VIEW,
    CREATE PROCEDURE,
    DROP ANY TABLE,
    DROP ANY VIEW,
    DROP ANY PROCEDURE TO RL_KADCORE;

--DROP ROLE RL_KADCORE;

-- Задание 5. Найдите с помощью select-запроса роль в словаре.
-- Найдите с помощью select-запроса все системные привилегии, назначенные роли.

SELECT * FROM DBA_ROLES WHERE ROLE = 'RL_KADCORE';
SELECT * FROM DBA_SYS_PRIVS WHERE GRANTEE = 'RL_KADCORE';