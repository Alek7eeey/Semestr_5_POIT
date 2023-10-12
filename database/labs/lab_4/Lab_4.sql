--ex1. Получите список всех файлов табличных
-- пространств (перманентных  и временных)
        select tablespace_name, file_name from dba_data_files;
        select tablespace_name, file_name from dba_temp_files;

--ex2. Создайте табличное пространство с именем XXX_QDATA (10m).
-- При создании установите его в состояние offline.
-- Затем переведите табличное пространство в состояние online.
-- Выделите пользователю XXX квоту 2m в пространстве XXX_QDATA.
-- От имени XXX в  пространстве XXX_T1создайте таблицу из двух столбцов,
-- один из которых будет являться первичным ключом.
-- В таблицу добавьте 3 строки.
        create tablespace KAD_QDATA
        datafile 'KAD_QDATA'
        size 10m
        extent management local
        offline;

        alter tablespace KAD_QDATA online;

        create user KAD identified by 123
        DEFAULT TABLESPACE KAD_QDATA quota unlimited on KAD_QDATA
        ACCOUNT UNLOCK
        PASSWORD EXPIRE;

        grant create session,create table, create view,
        create procedure,drop any table,drop any view,
        drop any procedure to KAD;

        alter user KAD quota 2m on KAD_QDATA;
        --DROP USER KAD CASCADE;

        -- ->KAD user
        create table KAD_T1(
        x number(20) primary key,
        y number(20)) tablespace KAD_QDATA;

        insert into KAD_T1 values (1, 1);
        insert into KAD_T1 values (2, 2);
        insert into KAD_T1 values (3, 3);
        select * from KAD_T1;

--ex3. Получите список сегментов табличного пространства  XXX_QDATA.
-- Определите сегмент таблицы XXX_T1. Определите остальные сегменты.
    -- ->SYS
        select * from dba_segments where tablespace_name = 'KAD_QDATA';
        select * from dba_segments;

--ex4. Удалите (DROP) таблицу XXX_T1.
-- Получите список сегментов табличного пространства  XXX_QDATA.
-- Определите сегмент таблицы XXX_T1.
-- Выполните SELECT-запрос к представлению USER_RECYCLEBIN,
-- поясните результат.
        -- ->KAD user
    drop table KAD_T1;
        -- ->SYS
    select * from dba_segments where tablespace_name = 'KAD_QDATA';

        -- ->KAD user
    select * from user_recyclebin;

--ex5. Восстановите (FLASHBACK) удаленную таблицу
    flashback table KAD_T1 to before drop;

    SELECT * FROM KAD_T1;

--ex6. Выполните PL/SQL-скрипт,
-- заполняющий таблицу XXX_T1 данными (10000 строк).
    begin
    for x in 4..10000
    loop
    insert into KAD_T1 values(x, x);
    end loop;
    commit;
    end;

    select count(*) from KAD_T1;
    SELECT * from KAD_T1;

--ex7. Определите сколько в сегменте таблицы XXX_T1 экстентов,
-- их размер в блоках и байтах. Получите перечень всех экстентов.
    select * from user_segments where tablespace_name like 'KAD_QDATA';
    select extents, blocks, bytes from user_segments where tablespace_name like 'KAD_QDATA';

--ex8. Удалите табличное пространство XXX_QDATA и его файл
    -- ->SYS
    drop tablespace KAD_QDATA including contents and datafiles;
    --select * from SYS.DBA_TABLESPACES

--ex9. Получите перечень всех групп журналов повтора.
-- Определите текущую группу журналов повтора.
    select GROUP# from v$log;
    select GROUP# from v$log where STATUS = 'CURRENT';

--ex10. Получите перечень файлов всех журналов повтора инстанса.
    select MEMBER from v$logfile;

--ex11 EX. С помощью переключения журналов повтора
-- пройдите полный цикл переключений.
-- Запишите серверное время в момент вашего первого переключения
-- (оно понадобится для выполнения следующих заданий).
    alter system switch logfile;
    select GROUP# from v$log where STATUS = 'CURRENT';
    select current_timestamp from SYS.DUAL;

--ex12 EX. Создайте дополнительную группу журналов повтора
-- с тремя файлами журнала. Убедитесь в наличии группы и файлов,
-- а также в работоспособности группы (переключением).
-- Проследите последовательность SCN.
    alter database add logfile group 4 'C:\OracleDB\oradata\ORCL\REDO04.LOG' size 50m blocksize 512;
    alter database add logfile member 'C:\OracleDB\oradata\ORCL\REDO041.LOG'  to group 4;
    alter database add logfile member 'C:\OracleDB\oradata\ORCL\REDO042.LOG'  to group 4;

    select GROUP#, MEMBER, STATUS from v$logfile;

    -- swith to 4th group
    alter system switch logfile;
    select GROUP#, STATUS from v$log;

--ex13 EX. Удалите созданную группу журналов повтора.
-- Удалите созданные вами файлы журналов на сервере.
    alter database drop logfile member 'C:\OracleDB\oradata\ORCL\REDO041.LOG';
    alter database drop logfile member 'C:\OracleDB\oradata\ORCL\REDO042.LOG';
    alter database clear unarchived logfile group 4;
    alter database drop logfile group 4;

    select * from v$logfile;

--ex14 Определите, выполняется или нет архивирование журналов
-- повтора (архивирование должно быть отключено).
    select instance_name, archiver from v$instance;
    select LOG_MODE from V_$DATABASE;

--ex15 Определите номер последнего архива.
    select MAX(SEQUENCE#) from v$archived_log;

--ex16 EX. Включите архивирование.
    -- *make it in SQL PLUS*
    -- connect / as sysdba;
    -- shutdown immediate;
    -- startup mount;
    -- alter database archivelog;
    -- archive log list;
    -- alter database open;

    select instance_name, archiver from v$instance;
    select LOG_MODE from V_$DATABASE;

--ex17 EX. Принудительно создайте архивный файл.
-- Определите его номер. Определите его местоположение и убедитесь
-- в его наличии.
-- Проследите последовательность SCN в архивах и журналах повтора.
    ALTER SYSTEM SET LOG_ARCHIVE_DEST_1 ='LOCATION=C:\OracleDB\oradata\ORCL\archive1.arc';
    alter system switch logfile;
    select * from v$archived_log;

--ex18 EX. Отключите архивирование. Убедитесь, что архивирование отключено
    -- *make it in SQL PLUS*
    -- connect / as sysdba;
    -- shutdown immediate;
    -- startup mount;
    -- alter database noarchivelog;
    -- archive log list;
    -- alter database open;

    select instance_name, archiver from v$instance;
    select LOG_MODE from V_$DATABASE;

--ex19. Получите список управляющих файлов.
    select * from V_$CONTROLFILE

--ex20. Получите и исследуйте содержимое управляющего файла.
    -- Поясните известные вам параметры в файле.
    --Show parameter control (make it in SQL PLUS)

--ex21. Определите местоположение файла параметров инстанса.
-- Убедитесь в наличии этого файла.
    select * from v$parameter where name = 'spfile';

--ex22. Сформируйте PFILE с именем XXX_PFILE.ORA.
-- Исследуйте его содержимое.
-- Поясните известные вам параметры в файле.
    create pfile = 'KAD_PFILE.ora' from spfile;
    --path to file: WINDOWSX64_19300...//database//KAD_PFILE.ora

--ex23. Определите местоположение файла паролей инстанса.
-- Убедитесь в наличии этого файла.
    select * from v$pwfile_users;
    --show parameter password;

--ex24. Получите перечень директориев для файлов сообщений и диагностики.
    select * from v$diag_info;
    --show parameter background_dump_dest;

--ex25. Найдите и исследуйте содержимое протокола работы инстанса (LOG.XML),
-- найдите в нем команды переключения журналов которые вы выполняли.
    --file path: oracleDB//diag//rdbms//orcl//orcl//alert//log.xml

--ex26.
    select * from V_$LOG