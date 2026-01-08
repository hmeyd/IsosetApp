select Distinct(cl.ClientId)
From Client cl
join Commande co on cl.ClientId = co.ClientId
join LigneCommandes lc on lc.CommandeId = co.CommandeId
JOIN Produit AS P ON lc.ProduitId = P.ProduitId
where P.CategorieId in (4, 5);
