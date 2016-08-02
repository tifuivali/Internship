

select distinct Name , HotelId from Hotels inner join Bookings on (Hotels.Id=Bookings.HotelId);

select distinct Hotels.Id,Name from Hotels full join Bookings on (Hotels.Id=Bookings.HotelId);

select Hotels.Id,Hotels.Name from Hotels inner join Locations on (Locations.Id = Hotels.Id) 
                                       inner join Rooms on (Rooms.HotelId = Hotels.Id) 
									   where Locations.Country='Romania' group by Hotels.Id,Hotels.Name having count(Rooms.HotelId)=1 ;



select  Bookings.HotelId,count(Rooms.Id) NumberOFRooms from Bookings inner join Rooms on (Bookings.RoomId = Rooms.Id) group by Bookings.HotelId;


select top 1  Hotels.Id from Hotels  inner join Rooms on(Hotels.Id=Rooms.HotelId) group by Hotels.Id order by count(Rooms.Id) ;