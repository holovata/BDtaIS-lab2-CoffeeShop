SELECT Customers.Name, Customers.LastName, Customers.Email
FROM Customers
WHERE Customers.Id IN
	(SELECT Orders.CustomerId
	 FROM Orders
	 WHERE Orders.ProductId IN
	 	(SELECT Products.Id
		 FROM Products
		 WHERE Products.RoastId IN
		 	(SELECT CoffeeRoasts.Id
			 FROM CoffeeRoasts
			 WHERE CoffeeRoasts.Name = B)));