SELECT DISTINCT m.Name
FROM Manufacturers m, Products p
WHERE m.Id = p.ManufacturerId
AND m.Id NOT IN (
  SELECT m.Id
  FROM Manufacturers m, Products p, CoffeeTypes ct
  WHERE m.Id = p.ManufacturerId
  AND p.TypeId = ct.Id
  AND ct.Name = Y
);