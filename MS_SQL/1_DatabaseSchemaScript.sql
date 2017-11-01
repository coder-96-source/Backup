CREATE DATABASE MyShoppingMall;

USE MyShoppingMall

--Customer Table
CREATE TABLE Customer
(
CustomerID int NOT NULL PRIMARY KEY,
Name nvarchar(20) NOT NULL, --Unicode non-fixed char
DateOfBirth date NOT NULL,
Contact char(10) NOT NULL, --non-Unicode fixed char e.g. 00011112222
);
CREATE INDEX CIndex
ON Customer (CustomerID)
GO

--Product Table
CREATE TABLE Product
(
ProductID int NOT NULL PRIMARY KEY,
Name nvarchar(20) NOT NULL,
Category nvarchar(20) NOT NULL,
Price decimal NOT NULL,
Amount smallint NOT NULL,
)
CREATE INDEX PIndex
ON Product (ProductID)
GO

--PurchaseHistory Table
CREATE TABLE PurchaseHistory
(
ReceiptID int NOT NULL PRIMARY KEY,
CustomerID int NOT NULL FOREIGN KEY REFERENCES Customer(CustomerID),
ProductID int NOT NULL FOREIGN KEY REFERENCES Product(ProductID),
Amount smallint NOT NULL,
TotalPrice decimal NOT NULL,
)
CREATE INDEX PHIndex
ON PurchaseHistory (ReceiptID)
GO