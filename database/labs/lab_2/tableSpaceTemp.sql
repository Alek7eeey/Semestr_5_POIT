--Задание 2. Создайте табличное пространство для временных данных со следующими параметрами:
--	имя: TS_XXX_TEMP;
--	имя файла: TS_XXX_TEMP;
--	начальный размер: 5М;
--	автоматическое приращение: 3М;
--	максимальный размер: 30М.


create TEMPORARY TABLESPACE TS_KAD_TEMP
    TEMPFILE 'TS_KAD_TEMP'
    SIZE 5M
    AUTOEXTEND ON NEXT 3M
    MAXSIZE 30M;

DROP TABLESPACE TS_KAD_TEMP INCLUDING CONTENTS and DATAFILES;