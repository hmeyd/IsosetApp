--Créer la vue catalogue_produit avec les champs suivants 
--NomCategorie, nomFournisseur ,NomProduit, 
--UniteContionnement 
--PrixUnitaire

Create view catalogue_produit as 
select 
NomCategorie,
NomSociete,
NomProduit,
UniteContionnement,
PrixUnitaire

from Produit P
join Categorie ca on ca.CategorieId = P.CategorieId
join Fournisseur F on P.FournisseurId = F.FournisseurId


select *
from catalogue_produit
