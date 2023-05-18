SELECT MAX(p.Price) as MaxPrice
FROM Products p
JOIN Orders o ON p.Id = o.ProductId
JOIN Customers c ON o.CustomerId = c.Id
WHERE c.LastName = Z;
