select NomSociete, ContactNom
From Client;


select *
From Commande;


select NomSociete, ContactNom
From Client
Where ContactNom = 'Aria Cruz'
select 1;

Select PrixUnitaire + QuantiteEnStock
From Produit;


Select *
From Client
Where Pays = 'Uk'
or Pays = 'France';

select c.NomSociete, c.Adresse, c.Pays, c.Ville
From Client As c
Where c.Pays <= 'UK'
Order by c.Pays, c.Ville, c.Adresse;

select c.NomSociete As nom, c.Adresse + ' ' + c.Ville + ' ' +c.Pays as AdresseComplete 
From Client As c
Where c.Pays <= 'UK'
Order by c.Pays, c.Ville, c.Adresse;


Create Table Matable (MaTableId int);
Drop Table Matable;

CREATE VIEW MesClients AS
SELECT NomSociete,
       UPPER(ContactNom) AS NomMajuscule
FROM Client;
