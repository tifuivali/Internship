
--drop procedure GetInfo; 
 
create procedure GetInfo @hotelName nchar(50)
as
declare @hotelId int;
select top 1 @hotelId=COUNT(*) from Hotels where Name=@hotelName;
select count(*) "NumberOfRooms" from Rooms where Rooms.HotelId=@hotelId;
select count(*) "Total Bookings" from Bookings where Bookings.HotelId=@hotelId;
select top 1 Rooms.Id,Count(Rooms.Id) from Rooms inner join Bookings on (Rooms.HotelId=Bookings.HotelId) 
where Bookings.HotelId = @hotelId group by Rooms.Id order by Count(Rooms.Id) desc; 
select top 1 year(BookingDate) from Bookings group by year(BookingDate) order by count(BookingDate) desc ;
