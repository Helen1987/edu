CREATE DATABASE WebPartsTest

GO

USE WebPartsTest

GO

CREATE TABLE Customer
(
  CustomerID char(5) PRIMARY KEY,
  CompanyName varchar(80),
  ContactFirstname varchar(80),
  ContactLastname varchar(100),
  PhoneNumber varchar(20),
  EmailAddress varchar(250),
  Address varchar(200),
  ZipCode varchar(6),
  City varchar(80),
  Country varchar(60),
  WebSite varchar(250)
)

GO

CREATE TABLE CustomerNotes
(
  NoteID int IDENTITY PRIMARY KEY,
  CustomerID char(5),
  NoteDate datetime,
  NoteContent text
)

GO

CREATE TABLE Orders
(
  OrderID int IDENTITY PRIMARY KEY,
  CustomerId char(5),
  OrderDate datetime,
  ShipmentDate datetime,
  ShipmentAddress varchar(200) NULL,
  ShipmentZipCode varchar(6) NULL,
  ShipmentCity varchar(80) NULL,
  ShipmentCountry varchar(60) NULL
)

GO

INSERT INTO Customer VALUES('C001', 'Company 1', 'First 1', 'Last 1', '1111', 'first@apress.com', 'Address 1', '1111', 'City 1', 'Country 1', 'www.apress.com')
INSERT INTO Customer VALUES('C002', 'Company 2', 'First 2', 'Last 2', '2222', 'second@apress.com', 'Address 2', '2222', 'City 1', 'Country 1', 'www.apress.com')
INSERT INTO Customer VALUES('C003', 'Company 3', 'First 3', 'Last 3', '3333', 'third@apress.com', 'Address 3', '3333', 'City 2', 'Country 2', 'www.apress.com')
INSERT INTO Customer VALUES('C004', 'Company 4', 'First 4', 'Last 4', '4444', 'fourth@apress.com', 'Address 4', '4444', 'City 2', 'Country 2', 'www.apress.com')
INSERT INTO Customer VALUES('C005', 'Company 5', 'First 5', 'Last 5', '5555', 'fifth@apress.com', 'Address 5', '5555', 'City 3', 'Country 3', 'www.apress.com')

GO

INSERT INTO CustomerNotes(CustomerID, NoteDate, NoteContent) VALUES('C001', '1.1.2005', 'This is a good customer')
INSERT INTO CustomerNotes(CustomerID, NoteDate, NoteContent) VALUES('C001', '5.6.2005', 'You got the problem')
INSERT INTO CustomerNotes(CustomerID, NoteDate, NoteContent) VALUES('C001', '9.6.2005', 'It is not easy')
INSERT INTO CustomerNotes(CustomerID, NoteDate, NoteContent) VALUES('C001', '3.6.2005', 'Working really hard')
INSERT INTO CustomerNotes(CustomerID, NoteDate, NoteContent) VALUES('C002', '1.1.2005', 'New Customer')
INSERT INTO CustomerNotes(CustomerID, NoteDate, NoteContent) VALUES('C002', '8.7.2005', 'First business completed')
INSERT INTO CustomerNotes(CustomerID, NoteDate, NoteContent) VALUES('C004', '1.1.2005', 'Last business, they dont pay')
INSERT INTO CustomerNotes(CustomerID, NoteDate, NoteContent) VALUES('C004', '11.12.2005', 'Got the money')