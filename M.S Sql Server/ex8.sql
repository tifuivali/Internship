
drop procedure GetInfo; 
 
create procedure GetInfo @hotelName nvarchar(50)
as
declare @hotelId int ;
select top 1 @hotelId=Hotels.Id  
	from Hotels
	where rtrim(upper(Name))=rtrim(upper(@hotelName));

select 
	count(*) as 'NumberOfRooms' ,

	(select count(*) as 'Total Bookings' 
		from Bookings 
		where Bookings.HotelId=@hotelId) 
	as 'Total Bookings',

	(select top 1 Rooms.Id 
		from Rooms 
		inner join Bookings on Rooms.HotelId=Bookings.HotelId 
		where Bookings.HotelId = @hotelId 
		group by Rooms.Id 
		order by Count(Rooms.Id) desc) 
	as 'The Most Used Room',

	(select top 1 year(BookingDate)  
		from Bookings 
		group by year(BookingDate) 
		order by count(BookingDate) desc) 
	as 'Maxim period of bookings'

from Rooms where Rooms.HotelId=@hotelId;




exec GetInfo @hotelName='Hotel Europa';

