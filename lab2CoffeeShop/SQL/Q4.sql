SELECT Manufacturers.Name
FROM Manufacturers
WHERE Manufacturers.Id IN
	(SELECT Products.ManufacturerId
	 FROM Products
	 WHERE Products.Price != J);