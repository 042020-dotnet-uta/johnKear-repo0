use JoinPractice;
create table Country(
CountryID int not null IDENTITY(1,1) Primary Key,
Country varchar(50) not null,
);
GO
create table State(
StateID int not null IDENTITY(1,1) Primary Key,
CountryID int foreign key references Country,
State varchar(50) not null,
);
GO

insert into Country(Country)
Values('India'), ('China'), ('USA'), ('France'), ('England'), ('Philippines'),
('Sri Lanka');

insert into State(CountryID, State)
values ((select CountryID from Country where Country='USA'), 'Vermont'),
((select CountryID from Country where Country='USA'), 'Montana'),
((select CountryID from Country where Country='USA'), 'Vermont'),
((select CountryID from Country where Country='England'), 'Bedfordshire'),
((select CountryID from Country where Country='England'), 'Bristol'),
((select CountryID from Country where Country='England'), 'Buckinghamshire'),
((select CountryID from Country where Country='Sri Lanka'), 'Colombo'),
((select CountryID from Country where Country='Sri Lanka'), 'Badulla'),
((select CountryID from Country where Country='Philippines'), 'Cebu'),
((select CountryID from Country where Country='Philippines'), 'Bohol'),
((select CountryID from Country where Country='Philippines'), 'Tacloban')


select * from Country
select * from State
	
--Cross Join
select * from Country
cross join State
	
--inner join (old method as per SQL ANSI 89)
select * from Country as c, State as s
where c.CountryId=s.CountryId
	
--inner join (as per new standard SQL ANSI 92 onwards)
select * from Country as c
join State as s
on s.CountryId=c.CountryId
	
--left join 
select * from Country as c
left outer join State as s
on c.CountryId=s.CountryId
		
--right join
select * from Country as c
right outer join State as s
on c.CountryId=s.CountryId

--right join
select * from Country as c
right join State as s
on c.CountryId=s.CountryId
order by Country asc
	
-- full outer join
select * from Country as c
full outer join State as s
on c.CountryId=s.CountryId
order by Country asc
