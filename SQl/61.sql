--Créer une vue CLIENT_ANGLAIS avec les colonnes suivante : 
--NomSociete,ContactTitre,ContactNom,Adresse,Ville,Region,CodePostal,Pays,Telephone,Fax

create view CLIENT_ANGLAIS as
select
NomSociete,
ContactTitre,
ContactNom,
Adresse,
Ville,
Region,
CodePostal,
Pays,
Telephone,
Fax
from Client
where Pays = 'UK';
