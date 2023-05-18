SELECT DISTINCT Products.Name
FROM Products
WHERE Products.ManufacturerId IN
	(SELECT Manufacturers.Id
	 FROM Manufacturers
	 WHERE Manufacturers.Name = A);