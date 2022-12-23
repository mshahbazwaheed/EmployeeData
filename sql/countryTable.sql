create database country_data

create table Countries(
country_id int primary key,
country_name varchar (20) not null,
created_by varchar(20)

);

select * from Countries


create procedure sp_addCountry
(
@country_id as int,
@country_name as varchar(20),
@created_by as varchar (20)
)
as
begin
insert into Countries
values(@country_id,@country_name,@created_by)
end

sp_addCountry '4','UK','Muzammil';
