
drop view BookingsView;
create view BookingsView as select Bookings.BookingDate,Hotels.Name,Persons.FirstName,Persons.LastName 
from Bookings inner join Hotels on(Hotels.Id = Bookings.HotelId) 
inner join Persons on (Persons.Id = Bookings.PersonId);


drop view BookingsOfCurrentYear;
create view BookingsOfCurrentYear as select * from BookingsView where YEAR(BookingDate) = YEAR(GETDATE());

create view GetPersons as select distinct Persons.FirstName from Persons inner join Bookings on (Bookings.PersonId = Persons.Id)
where DATEDIFF(year,RegisterDate,BookingDate)<3 ;