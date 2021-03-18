create table Users(
UserId int primary key identity (1,1),
FirstName varchar (50),
LastName varchar (50),
Email varchar(50),
Password varchar (15)
);

create table Customers(
CustomerId int primary key identity (1,1),
UserId int,
CompanyName varchar (50),
foreign key (UserId) references Users(UserId)
);

create table Rentals(
RenatalId int primary key identity (1,1),
CarID int,
CustomerId int,
RentDate datetime,
ReturnDate datetime null,
foreign key (CarId) references Cars(Id),
foreign key (CustomerId) references Customers(CustomerId)
);
select * from Rentals;