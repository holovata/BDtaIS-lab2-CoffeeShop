SELECT C.LastName, C.Email
FROM Customers C
WHERE C.LastName = Z
AND NOT EXISTS
	((SELECT Orders.ProductId
	  FROM Orders
	  WHERE Orders.CustomerId = C.Id)
	 EXCEPT
	 (SELECT Products.Id
	  FROM Products))
AND NOT EXISTS
	((SELECT Products.Id
	  FROM Products)
	 EXCEPT
	 (SELECT Orders.ProductId
	  FROM Orders
	  WHERE Orders.CustomerId = C.Id));