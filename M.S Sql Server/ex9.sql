
--drop proc AddHotel;
create procedure AddHotel 
@hotelName nchar(50),
@hotelLocationId int ,
@floorNumber int,
@numberOfBeds int,
@roomType nchar(20)
as
declare @hotelId int;
declare @roomId int;
select @hotelId = max(Id)+1 from Hotels; 
insert into Hotels values(@hotelId,@hotelName,@hotelLocationId);
select @roomId = max(Id)+1 from Rooms;
insert into Rooms values(@roomId,@floorNumber,@numberOfBeds,@hotelId,@roomType);

go

create procedure UpdateHotel 
@hotelid int,@hotelName nchar(50),
@locationId int,
@floorNumber int,
@numberOfBeds int,
@roomType nchar(20)
as
update Hotels set Name=@hotelName , LocationId=@locationId where Id=@hotelid;
update Rooms set FloorNumber=@floorNumber,NumberOfBeds=@numberOfBeds,Type=@roomType where HotelId=@hotelid;

go

create procedure DeleteHotel @hotelId int
as
delete from Bookings 
where HotelId=@hotelId;

delete from Rooms 
where HotelId=HotelId;

delete from Hotels 
where Hotels.Id=@hotelId;

go

create function GetHotelNameById (@hotelId int) 
returns nchar 
as
begin
declare @name nchar(50);
select @name=Name 
from Hotels 
where Id=@hotelId;

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

create function GetPersonsRegisterBetween(@date1 date,@date2 date) 
returns table
as
return (select CONCAT(FirstName,' ',LastName) as "Full Name"
from Persons where RegisterDate between @date1 and @date2);  

select * 
from GetPersonsRegisterBetween('2016-01-01','2016-12-01');