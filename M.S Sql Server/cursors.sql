
--EX 1

drop proc UpdateTable;

create procedure UpdateTable @stringParam varchar(100) 
as   
declare db_cursor cursor local for
	select Name	
		FROM Hotels;

declare @index int;
set @index =0;
declare @hotelname nvarchar(100);

open db_cursor;
fetch next from db_cursor into @hotelName;
print @hotelName;
while @@FETCH_STATUS = 0
begin
   update Hotels set Name=concat(rtrim(@hotelname),' ',@stringParam,'_',@index)
   where Name=@hotelname;
   set @index = @index +1;
   fetch next from db_cursor into @hotelName;
end
close db_cursor;
deallocate db_cursor;

exec UpdateTable 'ceva';

select * from hotels;


--ex 2

drop procedure CreateInfo;

create procedure CreateInfo @stringParam varchar(100)
as
declare @temp table
		(Name nvarchar(200),
		 Indexx int
		 )

declare hotels_cursor cursor local  for
		select Name 
			from Hotels;

declare @index int;
set @index =1;
declare @hotelName nvarchar(100);

open hotels_cursor;
fetch next from hotels_cursor into @hotelName;

while @@FETCH_STATUS =0
begin
   insert into @temp values(concat(ltrim(@hotelName),' - ',@stringParam),@index);
   set @index = @index + 1
   fetch next from hotels_cursor into @hotelName;
end
close hotels_cursor;
deallocate hotels_cursor;
select Name,Indexx from @temp where Indexx % 2 != 0 order by Name desc;


exec CreateInfo 'hotel';


--ex 3

drop proc TwoCursors;

create procedure TwoCursors
as
declare @cityName nvarchar(50);
declare @countryName nvarchar(50);
declare @locationId int;
declare @hotelName nvarchar(50);
declare @index1 int;
declare @index2 int;
set @index1 =1;
set @index2=1;

declare location_cursor cursor local for
		select Id,City,Country
		from Locations;


open location_cursor ;
fetch next from location_cursor into @locationId,@cityName,@countryName;
while @@FETCH_STATUS =0
	begin
	print concat(rtrim(@cityName),' - ',rtrim(@countryName),' - first cursor - ',@index1);
	declare hotel_cursor cursor local for
			select Name 
			from Hotels
			where LocationId = @locationId;
	set @index1 = @index1 +1;
	open hotel_cursor;
	fetch next from hotel_cursor into @hotelName;
	while @@FETCH_STATUS =0
	begin
		print concat('     ',rtrim(@hotelName),' - second cursor - ',@index2);
		set @index2 = @index2 +1;
		fetch next from hotel_cursor into @hotelName; 
	end
	close hotel_cursor;
	deallocate hotel_cursor;
	fetch next from location_cursor into @locationId,@cityName,@countryName;
end
close location_cursor;
deallocate location_cursor;


exec TwoCursors;