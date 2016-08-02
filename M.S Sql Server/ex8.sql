
--drop procedure GetInfo; 
 
create procedure GetInfo @hotelName nchar(50)
as
declare @hotelId int;
select top 1 @hotelId=Hotels.Id  from Hotels where ltrim(rtrim(upper(Name)))=ltrim(rtrim(upper(@hotelName)));
select count(*) as 'NumberOfRooms' ,
(select count(*) as 'Total Bookings' from Bookings where Bookings.HotelId=@hotelId),
(select top 1 Rooms.Id from Rooms inner join Bookings on Rooms.HotelId=Bookings.HotelId 
where Bookings.HotelId = @hotelId group by Rooms.Id order by Count(Rooms.Id) desc),
(select top 1 year(BookingDate) as 'Maxim period of bookings' from Bookings group by year(BookingDate) order by count(BookingDate) desc)
from Rooms where Rooms.HotelId=@hotelId;

exec GetInfo @hotelName='Hotel ';
