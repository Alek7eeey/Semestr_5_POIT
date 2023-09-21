-- Задание 11. Создайте табличное пространство с именем XXX_QDATA (10m).
-- При создании установите его в состояние offline.
-- Затем переведите табличное пространство в состояние online.
-- Выделите пользователю XXX квоту 2m в пространстве XXX_QDATA.
-- От имени пользователя XXX создайте таблицу в пространстве XXX_T1.
-- В таблицу добавьте 3 строки.

create tablespace KAD_QDATA
    DATAFILE 'KAD_QDATA'
    SIZE 10M
    OFFLINE;

SELECT TABLESPACE_NAME, STATUS, CONTENTS FROM DBA_TABLESPACES;

ALTER TABLESPACE KAD_QDATA ONLINE;

ALTER USER KADCORE QUOTA 2M ON KAD_QDATA;

--DROP TABLESPACE KAD_QDATA INCLUDING CONTENTS;

--KADCORE user:

CREATE TABLE KAD_T1
(
    ID NUMBER,
    NAME VARCHAR2(10)
) TABLESPACE KAD_QDATA;

INSERT INTO KAD_T1 VALUES (11, 'D');
INSERT INTO KAD_T1 VALUES (22, 'B');
INSERT INTO KAD_T1 VALUES (33, 'C');

SELECT * FROM KAD_T1;

DROP TABLE KAD_T1;