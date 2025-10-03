CREATE DATABASE AnalisisVentasDB;

USE AnalisisVentasDB
GO

CREATE TABLE Clientes(

	CustomerID INT PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100),
	Email VARCHAR(150),
	Phone VARCHAR(25), 
	City VARCHAR(100),
	Country VARCHAR(100)
);

CREATE TABLE Productos (
    ProductID INT PRIMARY KEY,            
    ProductName VARCHAR(150) NOT NULL,
    Category VARCHAR(100),
    Price DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0
);

CREATE TABLE Ordenes (
    OrderID INT PRIMARY KEY,             
    CustomerID INT NOT NULL,
    OrderDate DATETIME2 NOT NULL,
    Status VARCHAR(50),                  
    Total DECIMAL(18,2) NULL,           
    CONSTRAINT FK_ordenes_clientes FOREIGN KEY (CustomerID) REFERENCES Clientes(CustomerID),
);

CREATE TABLE DetalleOrdenes (
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,   
    TotalPrice DECIMAL(10,2) NOT NULL,
    CONSTRAINT PK_DetallesOrden  PRIMARY KEY (OrderID, ProductID),
    CONSTRAINT FK_DetallesOrden_ordenes FOREIGN KEY (OrderID) REFERENCES Ordenes(OrderID),
    CONSTRAINT FK_DetallesOrden_Productos FOREIGN KEY (ProductID) REFERENCES Productos(ProductID)
);

select * from Productos
select * from Ordenes
select * from Clientes
select * from DetalleOrdenes
