SELECT *
FROM Commande
JOIN Client ON Commande.ClientId = Client.ClientId
WHERE Commande.ClientId = 'OTTIK'
   OR Client.Ville = 'Paris';