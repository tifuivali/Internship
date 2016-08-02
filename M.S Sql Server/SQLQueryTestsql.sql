

select min(BookingDate) , max(BookingDate) from Bookings;

select count(*) from RoomFacilities where HasTv = 1 and HasAirConditioning = 1;

select PersonId from Bookings where BookingDate = '2016-07-12';

select * from hotels where Id in (select HotelId from Bookings);

select count(HotelId) "Number of Bookings",HotelId from Bookings group by HotelId;

