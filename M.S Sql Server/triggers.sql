
--Ex 1
drop trigger OnInsertHotels;
go
create trigger  OnInsertHotels on Hotels
for insert
as
declare @detail nvarchar(500);
select @detail = concat('Inserted ',i.Id,' ',i.Name,' ',i.LocationId)
	from inserted i;
insert into Logs values('Hotels',@detail,GETDATE());

go
drop trigger OnInsertRooms;
go
create trigger OnInsertRooms on Rooms
for insert
as
declare @detail nvarchar(500);
select @detail = concat('Inserted ',i.Id,' ',i.FloorNumber,' ',i.NumberOfBeds,' ',i.HotelId,' ',i.Type)
	from inserted i;
insert into Logs values('Rooms',@detail,GETDATE());

go
drop trigger OnInsertPersons;
go
create trigger OnInsertPersons on Persons
for insert
as
declare @detail nvarchar(500);
select @detail = concat('Inserted ',i.Id,' ',i.FirstName,' ',i.LastName,' ',i.RegisterDate,' ',i.HasMoneyToSpend)
	from inserted i;
insert into Logs values('Persons',@detail,GETDATE());


go

--Ex 2
drop trigger OnUpdateHotels;
go
create trigger OnUpdateHotels on Hotels
for update
as
declare @detailsOld nvarchar(200);
declare @detailsNew nvarchar(200);
declare @detail nvarchar(500);
select @detailsOld = concat('Old values: ',d.Id,' ',d.Name,' ',d.LocationId)
	from deleted d;
select @detailsNew = concat('New values: ',i.Id,' ',i.Name,' ',i.LocationId)
	from inserted i;
set @detail = concat('Update ',@detailsOld,' -> ',@detailsNew);
insert into Logs values('Hotels',@detail,GETDATE());

go
drop trigger OnUpdateRooms;
go
create trigger OnUpdateRooms on Rooms
for update
as
declare @detailsOld nvarchar(200);
declare @detailsNew nvarchar(200);
declare @detail nvarchar(500);
select @detailsOld = concat('Old values: ',d.Id,' ',d.FloorNumber,' ',d.HotelId,' ',d.NumberOfBeds,' ',d.Type)
	from deleted d;
select @detailsNew = concat('New values: ',i.Id,' ',i.FloorNumber,' ',i.HotelId,' ',i.NumberOfBeds,' ',i.Type)
	from inserted i;
set @detail = concat('Update ',@detailsOld,' -> ',@detailsNew);
insert into Logs values('Rooms',@detail,GETDATE());

go
drop trigger OnUpdatePersons;
go
create trigger OnUpdatePersons on Persons
for update
as
declare @detailsOld nvarchar(200);
declare @detailsNew nvarchar(200);
declare @detail nvarchar(500);
select @detailsOld = concat('Old values: ',d.Id,' ',d.FirstName,' ',d.LastName,' ',d.RegisterDate,' ',d.HasMoneyToSpend)
	from deleted d;
select @detailsNew = concat('New values: ',i.Id,' ',i.FirstName,' ',i.LastName,' ',i.RegisterDate,' ',i.HasMoneyToSpend)
	from inserted i;
set @detail = concat('Update ',@detailsOld,' -> ',@detailsNew);
insert into Logs values('Persons',@detail,GETDATE());

go


insert into Persons values(32,'Ionica','Alex',GETDATE(),1);

go

update Persons set LastName='Alex2' where LastName='Alex';

go

select * from Logs;


--Ex 3
go

create trigger OnDeleteHotels on Hotels
for delete
as
declare @detail nvarchar(300);
select @detail = concat(d.Id,' ',d.Name,' ',d.LocationId)
	from deleted d;
insert into Logs values('Deleted ','Hotels',@detail,GETDATE());

go

create trigger OnDeleteRooms on Rooms
for delete
as
declare @detail nvarchar(300);
select @detail = concat('Deleted ',d.Id,' ',d.FloorNumber,' ',d.HotelId,' ',d.NumberOfBeds,' ',d.Type)
	from deleted d;
insert into Logs values('Rooms',@detail,GETDATE());

go

drop trigger OnDeletePersons;
go
create trigger OnDeletePersons on Persons
for delete
as
declare @detail nvarchar(300);
select @detail = concat('Deleted ',d.Id,' ',d.FirstName,' ',d.LastName,' ',d.RegisterDate,' ',d.HasMoneyToSpend)
	from deleted d;
insert into Logs values('Persons',@detail,GETDATE());


delete from Persons where FirstName ='Ionica';

select * from Logs;

delete from Logs;
