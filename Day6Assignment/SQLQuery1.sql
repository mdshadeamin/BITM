
CREATE TABLE Customer(

	Id int primary key identity(1,1),
	Name varchar(50),
	Contact varchar(50),
	Address varchar(100)

)


CREATE TABLE Item(

	Id int primary key identity(1,1),
	Name varchar(50),
	Price float

)

CREATE TABLE ItemOrder (

	Id int primary key identity(1,1),
	Name varchar(50),
	Quantity int,
	TotalPrice float
	
)


SELECT * FROM Customer
SELECT * FROM Item
SELECT * FROM ItemOrder





INSERT INTO ItemOrder(Name,Quantity,TotalPrice) VALUES ('Black',5,'')
INSERT INTO ItemOrder(Name,Quantity,TotalPrice) VALUES ('Hot',7,'')
INSERT INTO ItemOrder(Name,Quantity,TotalPrice) VALUES ('Regular',20,'')
INSERT INTO ItemOrder(Name,Quantity,TotalPrice) VALUES ('Cold',15,'')


SELECT * FROM Customer WHERE Name LIKE 's%'