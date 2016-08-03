
drop view SpecificLocations;
create view SpecificLocations as
with CteFilterLocation(Id,City,Country,Street,StreetNumber) as
	(select * 
		from Locations
		where ltrim(upper(Country)) like 'I%'
	)
select * 
 from CteFilterLocation  
 where ltrim(upper(City)) like '%A';



 select * from SpecificLocations;

 insert into Locations values (6,'Roma','Italy','Unknown',0);


 create view PersonsBokingOn2016 as
 with CteBookings(PersonId) as
	(select PersonId
			from Bookings
			where year(BookingDate) = 2016
	)
select * 
	from Bookings
	where PersonId in (select * from CteBookings);


select * from PersonsBokingOn2016;

drop proc VerifyNumberBookings
create procedure VerifyNumberBookings @number int
as
with CtePresonsMessages(PersonId,NumberBookings) as
		(select PersonId,count(PersonId) NumberBookings
			from Bookings 
			group by PersonId
		)
select 'Ok' MessagesOk 
	from CtePresonsMessages 
	where NumberBookings>=@number
union
select 'Not enough' MessagesBad
		from CtePresonsMessages 
		where NumberBookings<@number
	

exec VerifyNumberBookings 2;
				