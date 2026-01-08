 
 
 create table produit(
 Id int unique(id) Identity(1,1),
 Nom varchar(60),
 Reference varchar(60) unique(reference),
 Prix float,
 Quantite int,
 Categorie varchar(50),
 DateCreation date,
 DateModification date)

 select *
 From Produit