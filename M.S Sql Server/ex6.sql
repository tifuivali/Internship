

select distinct Name , Id
	from Hotels 
	where Id in (select HotelId from Bookings);

select distinct Hotels.Id,Name 
	from Hotels left join Bookings 
	on Bookings.HotelId=Hotels.Id;

select Hotels.Id,Hotels.Name 
	from Hotels 
	inner join Locations on (Locations.Id = Hotels.Id) 
	inner join Rooms on (Rooms.HotelId = Hotels.Id) 
	where Locations.Country='Romania' 
	group by Hotels.Id,Hotels.Name 
	having count(Rooms.HotelId)=1 ;



select  boo.HotelId,count(Rooms.Id) NumberOFRooms 
	from Bookings boo  
	inner join Rooms on (boo.RoomId = Rooms.Id) 
	group by boo.HotelId;


select top 1  Hotels.Id 
	from Hotels  
	inner join Rooms on(Hotels.Id=Rooms.HotelId) 
	group by Hotels.Id 
	order by count(Rooms.Id) desc ;