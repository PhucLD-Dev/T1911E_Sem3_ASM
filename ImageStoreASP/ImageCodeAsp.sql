CREATE DATABASE ImageCode
GO
USE ImageCode
GO
create table Customers (
	CustomerID int identity(1,1) primary key, 
	F_Name nvarchar(100) not null,
	L_Name nvarchar(100) not null,
	Phone varchar(10) not null unique,
	Email varchar(50) not null unique,
	Address1 nvarchar(200) not null,
);

create table Payments (
	PaymentID int identity(1,1) primary key, 
	Method nvarchar(100) not null,
	Status nvarchar(10) not null,
);

create table Materials (
	MaterialID int identity(1,1) primary key,
	Description nvarchar(255),
	Price float not null,
);

create table Staffs(
	StaffID int identity(1,1) primary key, 
	F_Name nvarchar(100) not null,
	L_Name nvarchar(100) not null,
	Phone varchar(20) not null unique,
	Email varchar(50) not null unique,	
);

create table Sizes (
	SizeID int identity(1,1) primary key,
	Description nvarchar(255),
	Price float not null,
);

create table CustomerPayment (
	ID int identity(1,1) primary key,
	CustomerId int foreign key references Customers(CustomerID),
	PaymentId int foreign key references Payments(PaymentID)
);

create table Orders(
	OrderID int identity(1,1) primary key,
	Status nvarchar(50) not null,
	Date datetime not null,
	StaffId int foreign key references Staffs(StaffID),
	CustomerId int foreign key references Customers(CustomerID),
);

create table OrderMaterial (
	ID int identity(1,1) primary key,
	OrderId int foreign key references Orders(OrderID),
	MaterialId int foreign key references Materials(MaterialID),
	quantity int not null,
);

create table OrderSize (
	ID int identity(1,1) primary key,
	OrderId int foreign key references Orders(OrderID),
	SizeId int foreign key references Sizes(SizeID),
	quantity int not null,
);

