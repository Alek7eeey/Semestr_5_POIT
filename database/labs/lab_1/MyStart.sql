--9
create table KAD_t(
    x number(3),
    s varchar2(50),
    primary key (x)
);

drop table KAD_t;

--11
insert into KAD_t(x,s) values (100, 'First stroke');
insert into KAD_t(x,s) values (200, 'Second stroke');
insert into KAD_t(x,s) values (300, 'Third stroke');

commit;

--12
update KAD_t
set s = 'This is modified stroke' where x like 100;

commit;

--13
select COUNT(*) as countStroke from KAD_t;
select sum(x) as sumOfX from KAD_t;
select POWER(x,2) as squareOfX from KAD_t;
select * from KAD_t;

--14
delete
from KAD_t
where power(x,2) like 90000;

commit;

--15
create table KAD_t1 (
    x number(3),
    s varchar2(50) default 'no text',
    foreign key(x) references KAD_t(x)
);

insert into KAD_t1 (x, s)
values (100, 'This is one more stroke');
insert into KAD_t1 (x)
values (300);

commit;

--16
select *
from KAD_t inner join KAD_T1 on KAD_t.x = KAD_t1.x;

select *
from KAD_t left outer join KAD_T1 on KAD_t.x = KAD_t1.x;

select *
from KAD_t right outer join KAD_T1 on KAD_t.x = KAD_t1.x;

select *
from KAD_t full outer join KAD_T1 on KAD_t.x = KAD_t1.x;

--18
drop table KAD_T1;
drop table KAD_t;
