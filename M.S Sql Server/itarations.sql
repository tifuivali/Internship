
-- Ex 1

create view ViewLocationsTest as

select * ,
case
	when lower(City) like 'a%' or lower(Country) like 'a%' 
		then 'Amazing'
	when len(concat(City,Country))>20 
		then 'to Infinite'
	when len(concat(City,Country))<20
		then 'to zero'
    else 'nothing'
end as 'Message'
from Locations; 


select * from ViewLocationsTest;


create procedure LocationTest 
as
declare @cityName nvarchar(20);
declare @country nvarchar(20);
declare @message nvarchar(20);

select  @cityName=City , @country=Country 
from Locations;

set @cityName = LOWER(@cityName);
set @country = LOWER(@country);

if @cityName like 'a%' or @country like 'a%'
	set @message='amazing';
else
	if len(concat(@cityName,@country))>20
		set @message = 'to infinite';
	else 
		if len(concat(@cityName,@country))<20
			set @message='to zero';
		else 
			set @message='nothing';

select * ,@message as 'Message' 
from Locations; 

exec LocationTest;


--Ex 2

select coalesce(Color,Class,Name,cast(Id as varchar)) as Display  
	from Products;


--Ex 3


drop proc Insert10Rows;
create procedure Insert10Rows 
as
declare @i int;
declare @hotelId int;
declare @personsId int;
declare @roomsId int;
declare @locationId int;
select @hotelId=max(Id) + 1
	from Hotels;
select @roomsId=max(Id) + 1
	from Rooms;
select @personsId=max(Id) + 1
	from Persons;
set @i =0;
while @i < 10
begin
	select top 1 @locationId =Id 
		from Locations order by NEWID();
    insert into Hotels
		values(@hotelId,concat('Name_' , @i)  ,@locationId);
	insert into Rooms
		values (@roomsId,2,2,@hotelId,concat('Type_' , @i));
	insert into Persons
		values (@personsId,concat('FirstName_' ,@i) ,concat('LastName_' , @i) ,'2016-08-04',1);
set @hotelId = @hotelId + 1;
set @roomsId = @roomsId + 1;
set @personsId = @personsId +1;
set @i=@i+1;
end

exec Insert10Rows;

select * from Hotels;

drop proc Insert5TestRecords;

create procedure Insert5TestRecords
as
declare @personId int;
declare @locationId int;
declare @i int;
declare @strNumber nvarchar(10);
set @i=0;

select @personId = max(Id) +1
		from Persons;
select @locationId = max(Id) +1
		from Locations;

while @i < 5
begin
if @i % 2 = 0
	set @strNumber = '_even';
else
	set @strNumber = '_odd';

declare @strConcat varchar(20);
set @strConcat = concat(@i,@strNumber);

insert into Locations
			values (@locationId,concat('City_',@strConcat),concat('Country_',@strConcat),concat('Street_',@strConcat),12);
		insert into Persons
			values (@personId,concat('FirstName_',@strConcat),concat('LastName_',@strConcat),'2016-08-04',1);

set @locationId = @locationId +1;
set @personId = @personId +1;
set @i=@i+1;
end

exec Insert5TestRecords;


select * from Locations;



exec sp_addlinkedserver @server='IASI-2814KL2',@srvproduct='';

select @@SERVERNAME;

SELECT @@servername
SELECT @@servicename;


