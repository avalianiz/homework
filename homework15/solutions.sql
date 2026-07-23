-- STUDENTS
-- TASK 1

select * from students
where dob > '1990-12-31';

-- task 2
select Firstname, Lastname, datediff(year, DoB, getdate()) AS age
from dbo.Students
where Country = 'Georgia' or Country = 'Libya'

-- task 3

    insert into students (Lastname, Firstname, DoB, Email, Quiz1, Quiz2, MiddleTest, FinalTest, Country)
values ('avaliani', 'zurab', '2006-03-20', 'test@gmail.com', 10, 20, 30, 40, 'Georgia');

select * from students where Lastname = 'avaliani';

-- task 4
with student_ranking as (select Lastname, Firstname, MiddleTest, DENSE_RANK() over (order by MiddleTest
	desc) as rank_num from dbo.Students)

select Firstname, Lastname, MiddleTest from student_ranking where rank_num <= 5;

-- task 5
DELETE FROM dbo.Students
    OUTPUT deleted.*
WHERE FinalTest = 19;

-- task 6
update Students set FinalTest = 0
    output inserted.*
where MiddleTest = 1;




-- persons table

-- task 1
select * from Persons
where PrivateId like '163%';

-- task 2

select * from Persons
where Lastname = Country;


-- task 3
select * from Persons
where country in ('Canada', 'Monaco');


-- task 4
select Firstname, Lastname, PrivateId from Persons
where email is null;

-- task 5
select * from Persons where country in ('Spain', 'Turkey') and salary between 1000 and 3000;

-- task 6

select workplace from Persons
where workplace like '%LLC%' or workplace like '%PC%' or workplace like '%LLP%';


--- task 7
select email,
       iif((len(email) - len(replace(email, '.', ''))) > 2, 'more than 2 dots', 'less than 2 dots')
           as MAILINFO from Persons

where email is not null;


-- task 8
select * from Persons where PINcode like '%51';


-- task 9
select country, round(avg(salary), 2) as avg_salary
from Persons
group by country
order by avg_salary desc;