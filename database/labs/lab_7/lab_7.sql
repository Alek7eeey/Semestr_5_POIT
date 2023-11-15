--1. Прочитайте задание полностью и выдайте своему пользователю необходимые
-- права.
select * from DBA_USERS;

--AS KAD_PDB C##kAD
grant create any view to C##KAD;
grant create any table to C##KAD;
GRANT CREATE SEQUENCE TO C##KAD;
GRANT UNLIMITED TABLESPACE TO C##KAD;
GRANT RESTRICTED SESSION TO C##KAD;
GRANT CREATE CLUSTER TO C##KAD;
GRANT CREATE SYNONYM TO C##KAD;
GRANT CREATE PUBLIC SYNONYM TO C##KAD;
GRANT CREATE MATERIALIZED VIEW TO C##KAD;

--2. Создайте последовательность S1 (SEQUENCE),
-- со следующими характеристиками: начальное значение 1000; приращение 10;
-- нет минимального значения; нет максимального значения; не циклическая;
-- значения не кэшируются в памяти; хронология значений не гарантируется.
-- Получите несколько значений последовательности. Получите текущее значение
-- последовательности.

--connect as C##KAD to KAD.pdb

CREATE SEQUENCE S1
  START WITH 1000
  INCREMENT BY 10
  NOMINVALUE
  NOMAXVALUE
  NOCYCLE
  NOCACHE
  NOORDER;

SELECT S1.NEXTVAL FROM DUAL;
SELECT S1.NEXTVAL FROM DUAL;
SELECT S1.NEXTVAL FROM DUAL;

SELECT S1.CURRVAL FROM DUAL; --current

drop sequence S1;

-- 3-4. Создайте последовательность S2 (SEQUENCE),
-- со следующими характеристиками: начальное значение 10;
-- приращение 10; максимальное значение 100; не циклическую.
-- Получите все значения последовательности.
-- Попытайтесь получить значение, выходящее за максимальное значение.

CREATE SEQUENCE S2
  START WITH 10
  INCREMENT BY 10
  MAXVALUE 100
  NOCYCLE;

SELECT S2.nextval FROM DUAL;

drop sequence S2;

-- 5.Создайте последовательность S3 (SEQUENCE), со следующими характеристиками:
-- начальное значение 10; приращение -10; минимальное значение -100; не циклическую;
-- гарантирующую хронологию значений. Получите все значения последовательности.
-- Попытайтесь получить значение, меньше минимального значения.

CREATE SEQUENCE S3
  START WITH 10
  INCREMENT BY -10
  MINVALUE -100
  MAXVALUE 10
  NOCYCLE
  ORDER;

drop sequence S3;

SELECT S3.NEXTVAL FROM DUAL;

-- 6.Создайте последовательность S4 (SEQUENCE), со следующими характеристиками:
-- начальное значение 1; приращение 1; минимальное значение 10; циклическая;
-- кэшируется в памяти 5 значений; хронология значений не гарантируется.
-- Продемонстрируйте цикличность генерации значений последовательностью S4.
CREATE SEQUENCE S4
  START WITH 10
  INCREMENT BY 1
  MINVALUE 10
  MAXVALUE 100
  CYCLE
  CACHE 5
  NOORDER;

SELECT S4.NEXTVAL FROM DUAL;

DROP SEQUENCE S4;

-- 7. Получите список всех последовательностей в словаре базы данных,
-- владельцем которых является пользователь XXX.

SELECT SEQUENCE_NAME FROM ALL_SEQUENCES WHERE SEQUENCE_OWNER = 'C##KAD';

-- 8. Создайте таблицу T1, имеющую столбцы N1, N2, N3, N4, типа NUMBER (20),
-- кэшируемую и расположенную в буферном пуле KEEP. С помощью оператора INSERT
-- добавьте 7 строк, вводимое значение для столбцов должно формироваться
-- с помощью последовательностей S1, S2, S3, S4.

CREATE TABLE T1 (
  N1 NUMBER(20),
  N2 NUMBER(20),
  N3 NUMBER(20),
  N4 NUMBER(20)
) CACHE STORAGE ( BUFFER_POOL KEEP );

BEGIN
  FOR i IN 1..7 LOOP
    INSERT INTO T1 VALUES (S1.NEXTVAL, S2.NEXTVAL, S3.NEXTVAL, S4.NEXTVAL);
  END LOOP;
END;

SELECT * FROM T1;

DROP TABLE T1;

-- 9. Создайте кластер ABC, имеющий hash-тип (размер 200)
-- и содержащий 2 поля: X (NUMBER (10)), V (VARCHAR2(12)).
CREATE CLUSTER ABC (
  X NUMBER(10),
  V VARCHAR2(12)
  ) SIZE 200 HASHKEYS 200;

DROP CLUSTER ABC;

-- 10.	Создайте таблицу A, имеющую столбцы XA (NUMBER (10)) и VA (VARCHAR2(12)),
-- принадлежащие кластеру ABC, а также еще один произвольный столбец.

CREATE TABLE A (
  XA NUMBER(10),
  VA VARCHAR2(12),
  Y NUMBER(10)
) CLUSTER ABC(XA, VA);

drop table A;
-- 11.	Создайте таблицу B, имеющую столбцы XB (NUMBER (10)) и
-- VB (VARCHAR2(12)), принадлежащие
-- кластеру ABC, а также еще один произвольный столбец.
CREATE TABLE B (
  XB NUMBER(10),
  VB VARCHAR2(12),
  Z NUMBER(10)
) CLUSTER ABC(XB, VB);

drop table B;
-- 12.	Создайте таблицу С, имеющую столбцы XС (NUMBER (10)) и
-- VС (VARCHAR2(12)), принадлежащие
-- кластеру ABC, а также еще один произвольный столбец.
CREATE TABLE C (
  XC NUMBER(10),
  VC VARCHAR2(12),
  W NUMBER(10)
) CLUSTER ABC(XC, VC);

INSERT INTO C VALUES (1, '1', 1);
select * from C;

drop table C;

-- 13. Найдите созданные таблицы и кластер в представлениях словаря Oracle.
SELECT TABLE_NAME FROM USER_TABLES;
SELECT CLUSTER_NAME FROM USER_CLUSTERS;

-- 14. Создайте частный синоним для таблицы XXX.С и
-- продемонстрируйте его применение.
CREATE SYNONYM SC FOR C##KAD.C;
SELECT * FROM SC;

DROP PUBLIC SYNONYM SC;
-- 15.	Создайте публичный синоним для таблицы
-- XXX.B и продемонстрируйте его применение.
CREATE PUBLIC SYNONYM SB FOR C##KAD.B;
SELECT * FROM SB;

DROP PUBLIC SYNONYM SB;

-- 16.	Создайте две произвольные таблицы A и B (с первичным и внешним ключами),
-- заполните их данными, создайте представление V1,
-- основанное на SELECT... FOR A inner
-- join B. Продемонстрируйте его работоспособность.
CREATE TABLE A16 (
  XA NUMBER(10),
  VA VARCHAR2(12),
  Y NUMBER(10),
  CONSTRAINT PK_A16 PRIMARY KEY (XA)
);

CREATE TABLE B16 (
  XB NUMBER(10),
  VB VARCHAR2(12),
  Z NUMBER(10),
  CONSTRAINT FK_B16 FOREIGN KEY (XB) REFERENCES A16(XA)
);

DROP TABLE B16;
DROP TABLE A16;

INSERT INTO A16 VALUES (1, 'Aleksey', 2);
INSERT INTO B16 VALUES (1, 'Roman', 2);

CREATE VIEW V1 AS
  SELECT
    *
  FROM
    A16
  INNER JOIN
      B16
        ON A16.XA = B16.XB;

SELECT * FROM V1;

DROP VIEW V1;

-- 17.	На основе таблиц A и B создайте материализованное представление
-- MV, которое имеет периодичность обновления 2 минуты.
-- Продемонстрируйте его работоспособность.
CREATE MATERIALIZED VIEW MV
  REFRESH COMPLETE ON DEMAND
    START WITH SYSDATE
    NEXT SYSDATE + NUMTODSINTERVAL(2, 'MINUTE')
  AS
    SELECT
      *
    FROM
      A16
    INNER JOIN
        B16
          ON A16.XA = B16.XB;

DROP MATERIALIZED VIEW MV;

SELECT * FROM MV;


