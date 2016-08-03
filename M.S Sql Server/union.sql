

drop proc SelectPersons;

create procedure SelectPersons 
as
select Id,Name,'Hotel' Type
	from Hotels
union
select Id,FirstName  ,'Persons' Type
	from Persons


exec SelectPersons;

drop proc ProcedureHotelPersonsCommon;

create procedure ProcedureHotelPersonsCommon 
as
select Name
	from Hotels
intersect
select LastName 
	from Persons;


exec ProcedureHotelPersonsCommon;


drop proc HotelsPersonsExcept;
create procedure HotelsPersonsExcept
as
select Name 
	from Hotels
except
select LastName
	from Persons

exec HotelsPersonsExcept;
