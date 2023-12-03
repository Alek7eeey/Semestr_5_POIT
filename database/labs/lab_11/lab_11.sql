create table AUDITORIUM_TYPE (
  AUDITORIUM_TYPE varchar(20) primary key,
  AUDIOTRIUM_TYPENAME varchar(100) unique
);

create table AUDITORIUM (
  AUDITORIUM varchar(20) primary key,
  AUDITORIUM_NAME varchar(100) unique,
  AUDITORIUM_CAPACITY int,
  AUDITORIUM_TYPE varchar(20),
  foreign key (AUDITORIUM_TYPE) references AUDITORIUM_TYPE(AUDITORIUM_TYPE)
);

create table FACULTY (
  FACULTY varchar(20) primary key,
  FACULTY_NAME varchar(100) unique
);

create table PULPIT (
  PULPIT varchar(20) primary key,
  PULPIT_NAME varchar(100) unique,
  FACULTY varchar(20),
  foreign key (FACULTY) references FACULTY(FACULTY)
);

create table TEACHER (
  TEACHER varchar(20) primary key,
  TEACHER_NAME varchar(100) unique,
  PULPIT varchar(20),
  foreign key (PULPIT) references PULPIT(PULPIT)
);

create table SUBJECT (
  SUBJECT varchar(20) primary key,
  SUBJECT_NAME varchar(100) unique,
  PULPIT varchar(20),
  foreign key (PULPIT) references PULPIT(PULPIT)
);

-- Заполняем таблицу AUDITORIUM_TYPE
INSERT INTO AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDIOTRIUM_TYPENAME)
VALUES ('Lecture', 'Лекционная аудитория');
INSERT INTO AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDIOTRIUM_TYPENAME)
VALUES ('Laboratory', 'Лаборатория');
INSERT INTO AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDIOTRIUM_TYPENAME)
VALUES ('Auditorium', 'Аудитория');
INSERT INTO AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDIOTRIUM_TYPENAME)
VALUES ('Seminar', 'Семинарская комната');
INSERT INTO AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDIOTRIUM_TYPENAME)
VALUES ('Conference', 'Конференц-зал');

-- Заполняем таблицу AUDITORIUM
-- Здесь предполагается, что у вас есть реальные данные об аудиториях
-- Пример:
INSERT INTO AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM_TYPE)
VALUES ('A101', 'Аудитория 101', 100, 'Auditorium');
INSERT INTO AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM_TYPE)
VALUES ('A102', 'Аудитория 102', 100, 'Auditorium');
INSERT INTO AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM_TYPE)
VALUES ('A103', 'Аудитория 103', 100, 'Auditorium');
INSERT INTO AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM_TYPE)
VALUES ('A104', 'Аудитория 104', 100, 'Auditorium');
-- ...

-- Заполняем таблицу FACULTY
INSERT INTO FACULTY (FACULTY, FACULTY_NAME)
VALUES ('F001', 'Факультет информатики');
INSERT INTO FACULTY (FACULTY, FACULTY_NAME)
VALUES ('F002', 'Факультет естественных наук');
INSERT INTO FACULTY (FACULTY, FACULTY_NAME)
VALUES ('F003', 'Факультет искусств');
INSERT INTO FACULTY (FACULTY, FACULTY_NAME)
VALUES ('F004', 'Факультет экономики');
INSERT INTO FACULTY (FACULTY, FACULTY_NAME)
VALUES ('F005', 'Факультет медицины');
select * from FACULTY;


-- Заполняем таблицу PULPIT
-- Здесь также предполагается, что у вас есть реальные данные о кафедрах и факультетах
-- Пример:
INSERT INTO PULPIT (PULPIT, PULPIT_NAME, FACULTY)
VALUES ('P001', 'Кафедра информационных технологий', 'F001');
-- ...

-- Заполняем таблицу TEACHER
-- Примеры:
INSERT INTO TEACHER (TEACHER, TEACHER_NAME, PULPIT)
VALUES ('T001', 'Иванов Иван Иванович', 'P001');
INSERT INTO TEACHER (TEACHER, TEACHER_NAME, PULPIT)
VALUES ('T002', 'Петров Петр Петрович', 'P001');
INSERT INTO TEACHER (TEACHER, TEACHER_NAME, PULPIT)
VALUES ('T003', 'Сидорова Екатерина Владимировна', 'P001');
INSERT INTO TEACHER (TEACHER, TEACHER_NAME, PULPIT)
VALUES ('T004', 'Смирнова Анна Александровна', 'P001');
-- ...

-- Заполняем таблицу SUBJECT
-- Примеры:

INSERT INTO SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
VALUES ('S001', 'Программирование', 'P001');
INSERT INTO SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
VALUES ('S002', 'Биология', 'P001');
INSERT INTO SUBJECT (SUBJECT, SUBJECT_NAME, PULPIT)
VALUES ('S003', 'Искусствоведение', 'P001');

DECLARE
  i integer := 0;
BEGIN
  FOR i IN 1..100000
    LOOP
      INSERT INTO AUDITORIUM (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM_TYPE)
      VALUES ('A' || i, 'Аудитория ' || i, 100, 'Auditorium');
    END LOOP;
end;

--1. Разработайте локальную процедуру
--GET_TEACHERS (PCODE TEACHER.PULPIT%TYPE)
--Процедура должна выводить список преподавателей из таблицы TEACHER
-- (в стандартный серверный вывод), работающих на кафедре, заданной кодом в параметре. Разработайте анонимный блок и продемонстрируйте выполнение процедуры.

create or replace procedure GET_TEACHERS(PCODE TEACHER.PULPIT%TYPE) is
begin
  for i in (select * from TEACHER where PULPIT = PCODE)
    loop
      dbms_output.put_line(i.TEACHER_NAME);
    end loop;
end;

begin
  GET_TEACHERS('P001');
end;

-- 2. Разработайте локальную функцию GET_NUM_TEACHERS (PCODE TEACHER.PULPIT%TYPE)
-- RETURN NUMBER
-- Функция должна выводить количество преподавателей из таблицы TEACHER,
-- работающих на кафедре
-- заданной кодом в параметре. Разработайте анонимный блок и продемонстрируйте
-- выполнение процедуры.

create or replace function GET_NUM_TEACHERS(PCODE TEACHER.PULPIT%TYPE)
    return number
  is
  num number;
begin
  select count(*) into num from TEACHER where PULPIT = PCODE;
  return num;
end;

begin
  dbms_output.put_line(GET_NUM_TEACHERS('P001'));
end;

-- 4. Разработайте процедуры:
-- GET_TEACHERS (FCODE FACULTY.FACULTY%TYPE)
-- Процедура должна выводить список преподавателей из таблицы TEACHER
-- (в стандартный серверный вывод),
-- работающих на факультете,
-- заданным кодом в параметре. Разработайте анонимный блок и продемонстрируйте
-- выполнение процедуры.
-- GET_SUBJECTS (PCODE SUBJECT.PULPIT%TYPE)
-- Процедура должна выводить список дисциплин из таблицы SUBJECT, закрепленных
-- за кафедрой, заданной кодом кафедры
-- в параметре. Разработайте анонимный блок и продемонстрируйте выполнение
-- процедуры.

create or replace procedure GET_TEACHERS(FCODE FACULTY.FACULTY%TYPE) is
begin
  for i in (select * from TEACHER where PULPIT in (select PULPIT from PULPIT where FACULTY = FCODE))
    loop
      dbms_output.put_line(i.TEACHER_NAME);
    end loop;
end;

begin
  GET_TEACHERS('F001');
end;

create or replace procedure GET_SUBJECTS(PCODE SUBJECT.PULPIT%TYPE) is
begin
  for i in (select * from SUBJECT where PULPIT = PCODE)
    loop
      dbms_output.put_line(i.SUBJECT_NAME);
    end loop;
end;

begin
  GET_SUBJECTS('P001');
end;

-- 5. Разработайте локальную функцию
-- GET_NUM_TEACHERS (FCODE FACULTY.FACULTY%TYPE)
-- RETURN NUMBER
-- Функция должна выводить количество преподавателей из таблицы TEACHER, работающих
-- на факультете, заданным кодом в параметре. Разработайте анонимный блок
-- и продемонстрируйте выполнение процедуры.

create or replace function GET_NUM_TEACHERS(FCODE FACULTY.FACULTY%TYPE)
    return number
is
  num number;
begin
  select count(*) into num from TEACHER where PULPIT in
                    (select PULPIT from PULPIT where FACULTY = FCODE);
  return num;
end;

begin
  dbms_output.put_line(GET_NUM_TEACHERS('F001'));
end;

-- 6. Разработайте пакет TEACHERS, содержащий процедуры и функции:
-- GET_TEACHERS (FCODE FACULTY.FACULTY%TYPE)
-- GET_SUBJECTS (PCODE SUBJECT.PULPIT%TYPE)
-- GET_NUM_TEACHERS (FCODE FACULTY.FACULTY%TYPE) RETURN NUMBER GET_NUM_SUBJECTS
-- (PCODE SUBJECT.PULPIT%TYPE) RETURN NUMBER

 create or replace function GET_NUM_SUBJECTS(PCODE SUBJECT.PULPIT%TYPE) return number
    is
    num number;
  begin
    select count(*) into num from SUBJECT where PULPIT = PCODE;
    return num;
  end;
end GET_NUM_SUBJECTS;
    begin
    dbms_output.put_line(GET_NUM_SUBJECTS('P001'));
    end;

create or replace package TEACHERS is
  procedure GET_TEACHERS(FCODE FACULTY.FACULTY%TYPE);
  procedure GET_SUBJECTS(PCODE SUBJECT.PULPIT%TYPE);
  function GET_NUM_TEACHERS(FCODE FACULTY.FACULTY%TYPE) return number;
  function GET_NUM_SUBJECTS(PCODE SUBJECT.PULPIT%TYPE) return number;
end TEACHERS;

-- 7. Разработайте анонимный блок и продемонстрируйте
-- выполнение процедур и функций пакета TEACHERS.--

create or replace package body TEACHERS is
  procedure GET_TEACHERS(FCODE FACULTY.FACULTY%TYPE) is
  begin
    for i in (select * from TEACHER where PULPIT in (select PULPIT from PULPIT where FACULTY = FCODE))
      loop
        dbms_output.put_line(i.TEACHER_NAME);
      end loop;
  end;

  procedure GET_SUBJECTS(PCODE SUBJECT.PULPIT%TYPE) is
  begin
    for i in (select * from SUBJECT where PULPIT = PCODE)
      loop
        dbms_output.put_line(i.SUBJECT_NAME);
      end loop;
  end;

  function GET_NUM_TEACHERS(FCODE FACULTY.FACULTY%TYPE) return number
    is
    num number;
  begin
    select count(*) into num from TEACHER where PULPIT in (select PULPIT from PULPIT where FACULTY = FCODE);
    return num;
  end;

  function GET_NUM_SUBJECTS(PCODE SUBJECT.PULPIT%TYPE) return number
    is
    num number;
  begin
    select count(*) into num from SUBJECT where PULPIT = PCODE;
    return num;
  end;
end TEACHERS;

begin
  TEACHERS.GET_TEACHERS('F001');
  TEACHERS.GET_SUBJECTS('P001');
  dbms_output.put_line(TEACHERS.GET_NUM_TEACHERS('F001'));
  dbms_output.put_line(TEACHERS.GET_NUM_SUBJECTS('P001'));
end;