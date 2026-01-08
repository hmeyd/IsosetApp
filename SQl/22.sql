SELECT ClientId AS cl,
       SUM(Transport) AS CA
FROM Commande
GROUP BY ClientId
HAVING SUM(Transport) > 1000
order by ClientId Asc;
