
--drop proc AddHotel;
create procedure AddHotel @hotelId int,@hotelName nchar(50),@hotelLocationId int , @roomId int, @roomFacilitiesId int
as
insert into [RoomsFacilities-Rooms] values(@roomId,@roomFacilitiesId);
insert into Hotels values(@hotelId,@hotelName,@hotelLocationId);

go

create procedure UpdateHotel @hotelid int,@hotelName nchar(50),@locationId int
as
update Hotels set Name=@hotelName , LocationId=@locationId where Id=@hotelid;

go

create procedure DeleteHotel @hotelId int
as
delete from Hotels where Hotels.Id=@hotelId;
delete from Bookings where HotelId=@hotelId;
delete from Rooms where HotelId=HotelId;

go

create function GetHotelNameByID (@hotelId int) returns nchar 
as
begin
declare @name nchar(50);
select @name=Name from Hotels where Id=@hotelId;
return @name;
end

go

create function GetLastBookingDate (@personId int) 
returns date
as
begin
declare @lastDate date;
select @lastDate=max(BookingDate) from Bookings where PersonId=@personId;
return @lastDate;
end;

drop function  GetPersonsRegisterBetween;

go

create function GetPersonsRegisterBetween(@date1 date,@date2 date) returns table
as
return (select CONCAT(FirstName,' ',LastName) as "Full Name" from Persons where RegisterDate between @date1 and @date2);  

select * from GetPersonsRegisterBetween('2016-01-01','2016-12-01');