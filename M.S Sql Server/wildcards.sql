

create procedure SearchHotel @key nvarchar(200) 
as
select * 
	from Hotels 
	where rtrim(ltrim(upper(Name))) like upper('%' + @key + '%');


create procedure SearchPersonEndWithOrBegin @key nvarchar(200)
as
select * 
	from Persons
	where upper(CONCAT(rtrim(FirstName),' ',rtrim(LastName))) like upper('%' + @key)
	or upper(CONCAT(rtrim(FirstName),' ',rtrim(LastName))) like upper(@key + '%');


exec SearchPersonEndWithOrBegin 'ache';

drop proc SearchPersonByChar;

create procedure SearchPersonByChar @char char
as
select * 
	from Persons 
	where len(rtrim(concat(FirstName,' ',Lastname))) - len(replace(rtrim(concat(FirstName,' ',Lastname)),@char,'')) =1;



exec SearchPersonByChar 'n';

create procedure SearchPersonsByTwoChars @char1 char, @char2 char
as 
select * 
	from Persons
	where upper(CONCAT(rtrim(FirstName),' ',rtrim(LastName))) like upper('_' + @char1 + '_' + @char2 + '%'); 



select * from Persons;
exec SearchPersonsByTwoChars 'o' ,'e';



create procedure SearchPersonsNotBegianAOrL
as
select * 
	from Persons
	where upper(CONCAT(rtrim(FirstName),' ',rtrim(LastName))) like upper('[^AL]%');

exec SearchPersonsNotBegianAOrL;

