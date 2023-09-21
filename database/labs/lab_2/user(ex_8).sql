-- Задание 8. Создайте пользователя с именем XXXCORE со следующими параметрами:
-- - табличное пространство по умолчанию: TS_XXX;
-- - табличное пространство для временных данных: TS_XXX_TEMP;
-- - профиль безопасности PF_XXXCORE;
-- - учетная запись разблокирована;
-- - срок действия пароля истек

CREATE USER KADCORE IDENTIFIED BY 123123
    DEFAULT TABLESPACE TS_KAD
    TEMPORARY TABLESPACE TS_KAD_TEMP
    PROFILE PF_KADCORE
    ACCOUNT UNLOCK
    PASSWORD EXPIRE;

GRANT CREATE SESSION TO KADCORE;
GRANT
    CREATE TABLE,
    CREATE VIEW,
    DROP ANY TABLE,
    DROP ANY VIEW TO KADCORE;

--DROP USER KADCORE