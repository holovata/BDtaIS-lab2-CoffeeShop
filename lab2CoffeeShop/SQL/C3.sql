SELECT Countries.Name
FROM Countries
WHERE Countries.Id IN
	(SELECT Manufacturers.CountryId
	 FROM Manufacturers
	 WHERE Manufacturers.Id IN
		(SELECT M.Id
		 FROM Manufacturers M
		 WHERE NOT EXISTS
	 		((SELECT Products.RoastId
			  FROM Products
		      WHERE Products.ManufacturerId = Z)
		     EXCEPT
		     (SELECT Products.RoastId
		      FROM Products
		      WHERE Products.ManufacturerId = M.Id AND Products.ManufacturerId != Z))));