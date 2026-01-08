select *
from Fournisseur Fo
left join Produit P on Fo.FournisseurId = P.FournisseurId
where P.FournisseurId is Null

SELECT Fo.*
FROM Fournisseur Fo
LEFT JOIN Produit P
    ON Fo.FournisseurId = P.FournisseurId
WHERE P.FournisseurId IS NULL;
