--все табличные пространства, все  файлы
SELECT * FROM dba_tablespaces;
SELECT * FROM dba_data_files
         UNION
select * from DBA_TEMP_FILES;

--все роли
SELECT * FROM DBA_ROLES;
SELECT * FROM DBA_SYS_PRIVS;

--профили безопасности
SELECT * FROM DBA_PROFILES;

--всех пользователей
SELECT * FROM all_users;
SELECT grantee, granted_role FROM dba_role_privs;

