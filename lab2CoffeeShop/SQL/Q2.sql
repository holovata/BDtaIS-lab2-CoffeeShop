SELECT AVG(p.Price)
FROM Products p, Manufacturers m
WHERE p.ManufacturerId = m.Id
AND m.Name = X;
