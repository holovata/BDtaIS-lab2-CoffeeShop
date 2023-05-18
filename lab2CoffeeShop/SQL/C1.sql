SELECT C.LastName, C.Name, C.Email
FROM Customers C
WHERE C.Email != Z
AND NOT EXISTS
    ((SELECT Orders.ProductId
      FROM Orders
      WHERE Orders.CustomerId = C.Id)
     EXCEPT
     (SELECT Orders.ProductId
      FROM Orders
      WHERE Orders.CustomerId IN
          (SELECT Customers.Id
           FROM Customers
           WHERE Customers.Email = Z)))
AND NOT EXISTS
    ((SELECT Orders.ProductId
      FROM Orders
      WHERE Orders.CustomerId IN
  	      (SELECT Customers.Id
           FROM Customers
           WHERE Customers.Email = Z))
     EXCEPT
     (SELECT Orders.ProductId
      FROM Orders
      WHERE Orders.CustomerId = C.Id));