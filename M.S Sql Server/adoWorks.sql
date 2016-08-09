

select @@SERVERNAME;

select * from Hotels;

select * from Rooms;

select * from Bookings;

select * from Persons;

delete from Persons where Id >50;

delete from hotels where Id>50;



delete from Rooms where HotelId>50;

go
create procedure AddNewHotel 
@id int, @name nvarchar(50),
@description nvarchar(500)
,@city nvarchar(50),
 @roomsCount int,
 @rating int
 as
 declare @idLocation int;
 select @idLocation = max(Id)+1 from Locations;
 insert into Locations values(@idLocation,@city,'Romania','Unknown',0);
 insert Hotels values(@id,@name,@idLocation,@description,@roomsCount,@rating);

 go
 create procedure UpdateHotel
 @id int, @name nvarchar(50),
@description nvarchar(500)
,@city nvarchar(50),
 @roomsCount int,
 @rating int
 as
 declare @idLocation int;
 select @idLocation = max(Id) from Locations;
 update Locations 
	set City=@city 
	where Id=@idLocation;
 update Hotels 
	set Description=@description ,Name=@name,RoomsCount =@roomsCount,Rating=@rating
	where Id =@id;


go


create proc GetHotelsByCity
@cityName nvarchar(50)
as
select h.Id as 'Id',h.Name as 'Name',h.Description as 'Description',l.City as 'City',h.RoomsCount as 'RoomsCount',h.Rating as 'Rating'
		from Hotels h join Locations l 
		on (h.LocationId = l.Id)
		where LTRIM(RTRIM(upper(l.City))) like upper('%' +LTRIM(RTRIM( @cityName)) +'%')

go

create proc GetHotelsByRooms
@minRooms int,
@maxRooms int
as
select h.Id as 'Id',h.Name as 'Name',h.Description as 'Description',l.City as 'City',h.RoomsCount as 'RoomsCount',h.Rating as 'Rating'
		from Hotels h join Locations l 
		on (h.LocationId = l.Id)
		where h.RoomsCount>= @minRooms and h.RoomsCount<= @maxRooms;


go

create proc GetHotelsByRating
@minRating int,
@maxRating int
as
select h.Id as 'Id',h.Name as 'Name',h.Description as 'Description',l.City as 'City',h.RoomsCount as 'RoomsCount',h.Rating as 'Rating'
		from Hotels h join Locations l 
		on (h.LocationId = l.Id)
		where h.Rating>= @minRating and h.Rating<= @maxRating;

go


create proc GetHotelsByName
@name nvarchar(50)
as
select h.Id as 'Id',h.Name as 'Name',h.Description as 'Description',l.City as 'City',h.RoomsCount as 'RoomsCount',h.Rating as 'Rating'
		from Hotels h join Locations l 
		on (h.LocationId = l.Id)
		where LTRIM(RTRIM(h.Name)) like upper('%' + LTRIM(rtrim(@name)) + '%');


go


create proc GetHotelsPage
@page int,
@pageSize int
as
select h.Id as 'Id',h.Name as 'Name',h.Description as 'Description',l.City as 'City',h.RoomsCount as 'RoomsCount',h.Rating as 'Rating'
		from Hotels h join Locations l 
		on (h.LocationId = l.Id)
		order by h.Id
		offset (( @page - 1) * @pageSize) ROWS
		fetch next @pageSize rows only;

go

drop proc FilterHotels;

go

create proc FilterHotels
@page int,
@pageSize int,
@name nvarchar(50),
@city nvarchar(50),
@minRooms int,
@maxRooms int,
@minRating int,
@maxRating int
as
declare @maxCurentRooms int;
declare @maxCurrentRating int;
if(@maxRating <=0)
	begin
	  select @maxCurrentRating = max(Rating) from Hotels;
	  set @maxRating = @maxCurrentRating;
	end
if(@maxRooms <=0)
	begin
	  select @maxCurentRooms = max(RoomsCount) from Hotels;
	  set @maxRooms = @maxCurentRooms;
	end;

select h.Id as 'Id',h.Name as 'Name',h.Description as 'Description',l.City as 'City',h.RoomsCount as 'RoomsCount',h.Rating as 'Rating'
		from Hotels h join Locations l 
		on (h.LocationId = l.Id)
		where ltrim(rtrim(upper(h.Name))) like ltrim(rtrim(upper('%' + @name +'%'))) 
			   and h.RoomsCount >= @minRooms and h.RoomsCount <= @maxRooms 
			   and ltrim(rtrim(upper(l.City))) like upper('%' + ltrim(rtrim(@city)) + '%')
			   and h.Rating >= @minRating and h.Rating <= @maxrating 
		order by h.Id
		offset (( @page - 1) * @pageSize) ROWS
		fetch next @pageSize rows only;

go

drop proc DeleteHotel;
go

drop proc DeleteHotel;

create procedure DeleteHotel
@id int
as
delete from Bookings where HotelId = @id;
delete from Rooms where HotelId = @id;
delete from Hotels where Id = @id;

exec DeleteHotel 50;