-- 1.	Создайте таблицу, имеющую несколько атрибутов, один из которых первичный ключ.

create table STUDENT
(
  STUDENT      varchar(20) primary key,
  STUDENT_NAME varchar(100) unique,
  PULPIT       varchar(20)
);

-- 2.	Заполните таблицу строками (10 шт.).
insert into STUDENT
values ('st1', 'Кравченко Алексей', 'P1');
insert into STUDENT
values ('st2', 'Адамович Алексей', 'P1');
insert into STUDENT
values ('st3', 'Новиков Роман', 'P1');
insert into STUDENT
values ('st4', 'Гайков Дмитрий', 'P3');
insert into STUDENT
values ('st5', 'Гарлукович Дарья', 'P2');
insert into STUDENT
values ('st6', 'Кришталь Максим', 'P2');
insert into STUDENT
values ('st7', 'Трубач Дмитрий', 'P3');
insert into STUDENT
values ('st8', 'Авсюкевич Полина', 'P4');
insert into STUDENT
values ('st9', 'Ломако Александр', 'P2');
insert into STUDENT
values ('st10', 'Григоренко Дарья', 'P4');

select * from STUDENT;

-- 3.	Создайте BEFORE – триггер уровня оператора на события INSERT, DELETE и UPDATE.

create or replace trigger TRIGGER_BEFORE
  before insert or delete or update
  on STUDENT
begin
  dbms_output.put_line('student BEFORE-trigger');
end;

-- 4.	Этот и все последующие триггеры должны выдавать сообщение на серверную консоль (DMS_OUTPUT)
-- со своим собственным именем.

insert into STUDENT
values ('st11', 'Скачко Илья', 'P3');

-- 5.	Создайте BEFORE-триггер уровня строки на события INSERT, DELETE и UPDATE.
create or replace trigger TRIGGER_ROW_BEFORE
  before insert or delete or update
  on STUDENT
  for each row
begin
  dbms_output.put_line('STUDENT_TRIGGER ROW BEFORE');
end;

update STUDENT
set STUDENT_NAME = STUDENT_NAME
where STUDENT.PULPIT = 'P3';

-- 6.	Примените предикаты INSERTING, UPDATING и DELETING.

create or replace trigger TRIGGER_ROW_BEFORE
  before insert or delete or update
  on STUDENT
  for each row
begin
  if inserting then
    dbms_output.put_line('ROW INSERTING BEFORE');
  elsif updating then
    dbms_output.put_line('ROW UPDATING BEFORE');
  elsif deleting then
    dbms_output.put_line('ROW DELETING BEFORE');
  end if;
end;

update STUDENT
set STUDENT_NAME = STUDENT_NAME
where STUDENT.PULPIT = 'P2';

-- 7.	Разработайте AFTER-триггеры уровня оператора на события INSERT, DELETE и UPDATE.
create or replace trigger TRIGGER_AFTER
  after insert or delete or update
  on STUDENT
begin
  dbms_output.put_line('TRIGGER AFTER');
end;

update STUDENT
set STUDENT_NAME = STUDENT_NAME
where STUDENT.PULPIT = 'P1';

-- 8.	Разработайте AFTER-триггеры уровня строки на события INSERT, DELETE и UPDATE.
create or replace trigger TRIGGER_ROW_AFTER
  after insert or delete or update
  on STUDENT
  for each row
begin
  dbms_output.put_line('STUDENT_TRIGGER ROW AFTER');
end;

update STUDENT
set STUDENT_NAME = STUDENT_NAME
where STUDENT.PULPIT = 'P1';

-- 9.	Создайте таблицу с именем AUDIT. Таблица должна содержать поля: OperationDate,
-- OperationType (операция вставки, обновления и удаления),
-- TriggerName(имя триггера),

create table AUDIT_
(
  OperationDate date,
  OperationType varchar(100),
  TriggerName   varchar(100)
);

-- 10.	Измените триггеры таким образом, чтобы они регистрировали все операции с
-- исходной таблицей в таблице AUDIT.

create or replace trigger TRIGGER_OPERATORS_BEFORE
  before insert or delete or update
  on STUDENT
begin
  insert into AUDIT_ values (sysdate, 'TRIGGER OPERATORS BEFORE', 'TRIGGER_OPERATORS_BEFORE');
end;

create or replace trigger TRIGGER_ROW_BEFORE
  before insert or delete or update
  on STUDENT
  for each row
begin
  insert into AUDIT_ values (sysdate, 'TRIGGER ROW BEFORE', 'TRIGGER_ROW_BEFORE');
end;

create or replace trigger TRIGGER_OPERATORS_AFTER
  after insert or delete or update
  on STUDENT
begin
  insert into AUDIT_ values (sysdate, 'TRIGGER OPERATORS AFTER', 'TRIGGER_OPERATORS_AFTER');
end;

create or replace trigger TRIGGER_ROW_AFTER
  after insert or delete or update
  on STUDENT
  for each row
begin
  insert into AUDIT_ values (sysdate, 'TRIGGER ROW AFTER', 'TRIGGER_ROW_AFTER');
end;

update STUDENT
set STUDENT_NAME = STUDENT_NAME
where STUDENT.PULPIT='P1';

select *
from AUDIT_;
truncate table AUDIT_;

-- 11.	Выполните операцию, нарушающую целостность таблицы по первичному ключу. Выясните, зарегистрировал
-- ли триггер это событие. Объясните результат.

insert into STUDENT
values ('st1', 'Новый студент', 'P1');

select *
from AUDIT_;

-- 12.	Удалите (drop) исходную таблицу. Объясните результат. Добавьте триггер,
-- запрещающий удаление исходной таблицы.

drop table STUDENT;

create or replace trigger BEFORE_DROP
  before drop on KAD.SCHEMA
begin
  if ORA_DICT_OBJ_NAME <> 'STUDENT' then
    return;
  end if;

  raise_application_error(-20001, 'Нельзя удалять таблицу STUDENT');
end;

-- 13.	Удалите (drop) таблицу AUDIT. Просмотрите состояние триггеров с помощью SQL-DEVELOPER.
-- Объясните результат. Измените триггеры.

drop table AUDIT_;
select TRIGGER_NAME, STATUS from USER_TRIGGERS;

-- 14.	Создайте представление над исходной таблицей. Разработайте INSTEADOF INSERT-триггер.
-- Триггер должен добавлять строку в таблицу.

create view STUDENT_VIEW
as
select *
from STUDENT;

create or replace trigger VIEW_TRIGGER
  instead of insert on STUDENT_VIEW
begin
  insert into AUDIT_ values (sysdate, 'THIS IS VIEW_TRIGGER', 'VIEW_TRIGGER');
  insert into STUDENT values (:new.STUDENT, :new.STUDENT_NAME, :new.PULPIT);
end;

-- 15.	Продемонстрируйте, в каком порядке выполняются триггеры.

delete from STUDENT where STUDENT = 'st11';
truncate table AUDIT_;

insert into STUDENT_VIEW
values ('st11', 'Песецкий Илья', 'P2');

select * from AUDIT_;
select * from STUDENT;