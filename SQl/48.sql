UPDATE Employe
SET Prime = 350
WHERE EmployeId IN (
    SELECT co.EmployeId
    FROM Commande co
    JOIN LigneCommandes lc ON co.CommandeId = lc.CommandeId
    WHERE co.DateCommande BETWEEN '19990101' AND '19991231'
    GROUP BY co.EmployeId
    HAVING SUM(lc.PrixUnitaire * lc.Quantite) < 50000
);
