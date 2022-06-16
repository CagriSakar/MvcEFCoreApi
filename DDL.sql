--Veritabanı oluşturma, tabloları oluşturma ve tablolar arasındaki ilişkileri belirleme
CREATE DATABASE LinkBilgisayarHW3
GO

USE LinkBilgisayarHW3
GO

CREATE TABLE Categories(
    Id int PRIMARY KEY IDENTITY(1,1),
    Name nvarchar(MAX)
)
GO

CREATE TABLE Products(
    Id int PRIMARY KEY IDENTITY(1,1),
    Name nvarchar(MAX),
    Price decimal(18,2),
    CategoryId int,
    Stock int
)
GO

CREATE TABLE ProductFeatures(
    Id int PRIMARY KEY,
    Width int,
    Height int
)
GO


--Category-Product (one to many) ilişkisi
ALTER TABLE Products
ADD CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

--Product-ProductFeature(one to one) ilişkisi
ALTER TABLE ProductFeatures
ADD CONSTRAINT FK_ProductId FOREIGN KEY (Id) REFERENCES Products(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO