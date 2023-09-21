--Задание 1. Создайте табличное пространство для постоянных данных со следующими параметрами:
-- - имя: TS_XXX;
-- - имя файла: TS_XXX;
-- - начальный размер: 7М;
-- - автоматическое приращение: 5М;
-- - максимальный размер: 20М.

CREATE TABLESPACE TS_KAD
        DATAFILE 'TS_KAD'
        SIZE 7M
        AUTOEXTEND ON NEXT 5M
        MAXSIZE 100 M;

DROP TABLESPACE TS_KAD2 INCLUDING CONTENTS and DATAFILES;

--словари данных:
--DBA - SYSTEM (все объекты данных)
--ALL - объекты, к которым пользователь имеет доступ
--USER - объекты принадлежающие пользователю
--V$ -производительность сервера

--sys sysaux