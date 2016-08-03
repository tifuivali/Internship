

select min(BookingDate) MinBookingDate , max(BookingDate) as MaxBookingDate
	from Bookings;

select count(*) RoomsWithFacilities
	from RoomFacilities 
	where HasTv = 1 and HasAirConditioning = 1;

select PersonId 
	from Bookings 
	where BookingDate = '2016-07-12';

select * 
	from hotels 
	where Id in (select HotelId from Bookings);

select count(HotelId) as 'Number of Bookings',HotelId 
	from Bookings 
	group by HotelId;


