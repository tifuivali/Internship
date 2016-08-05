BEGIN TRY
 PRINT 10/2;
 PRINT 'No error';
END TRY
BEGIN CATCH
 PRINT 'Error';
END CATCH;




BEGIN TRY
 PRINT 10/0;
 PRINT 'No error';
END TRY
BEGIN CATCH
 PRINT 'Error';
END CATCH;


begin transaction t1

insert into Persons
		values(34,'Antonecu','Mihai',GETDATE(),1);
insert into  Persons
		values(32,'Berghea','Andreea',GETDATE(),1);


rollback transaction t1;



begin transaction t2

insert into Persons
		values(32,'Zamfir','Grigore',GETDATE(),1);
insert into Hotels
		values(18,'Hotel Sunrise',2);


select * from persons;

commit transaction t2;

select * from hotels;


begin transaction t3
insert into Persons 
		values(35,'Condrea','Laureantiu',GETDATE(),1);
save transaction t3;
insert into Persons
			values(36,'Ivanut','Andreea',GETDATE(),1);

insert into Persons
		values(37,'Andros','Razvan',getdate(),1);

rollback transaction t3;




delete from Persons where Id>30;

select * from Hotels;



