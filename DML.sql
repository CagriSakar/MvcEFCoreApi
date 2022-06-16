--Veri Gerişi (INSERT KOMUTU)
INSERT Categories Values
('Computers'),
('CellPhones'),
('Tablets')
GO

INSERT Products Values
('Iphone11', 899.99, 2, 10),
('Ipad3', 299.99, 3, 10),
('SamsungS3', 79.99, 2, 20),
('MsiNotebook', 1499.99, 1, 5),
('Ssd', 99.99, 1, 20)
GO

INSERT ProductFeatures Values
(1, 5, 10),
(2, 20, 7),
(3, 3, 8),
(5, 20, 18),
(6, 2, 5)
GO


--Veri Sorgulama (SELECT KOMUTU)
SELECT * From Computers


--Veri Güncelleme (UPDATE KOMUTU)
UPDATE Products SET Price = 89.99 WHERE Name = 'Ssd'
GO


--Veri Silme (DELETE KOMUTU)
DELETE FROM ProductFeatures WHERE Id = (SELECT Id FROM Products WHERE Name = 'Ipad3')
GO

DELETE FROM Categories WHERE Name = 'Tablets'
GO