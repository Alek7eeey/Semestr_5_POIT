create table newTable
(
    id number(2),
    value nvarchar2(10)
);

insert into newTable values (1, 'a');
insert into newTable values (2, 'b');
insert into newTable values (3, 'c');
commit;

select * from newTable;

--drop table newTable;

--10.	Получите перечень всех сегментов,
-- владельцем которых является ваш пользователь.
select segment_name, segment_type from
                   dba_segments where owner = 'SYSTEM';

--11.	Создайте представление, в котором получите
-- количество всех сегментов,
-- количество экстентов, блоков памяти и размер
-- в килобайтах, которые они занимают

create or replace VIEW all_segments AS
    select
        owner, SEGMENT_TYPE,
        count(*) as segments_count,
        sum(extents) as total_extents,
        sum(blocks) as total_blocks,
        sum(bytes)/1024 as total_bytes
    from dba_segments
    group by owner, SEGMENT_TYPE;

select * from all_segments;
