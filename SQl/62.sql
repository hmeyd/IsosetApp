
--Créer une vue Typologie_client qui affiche l'identifiant client, le nom de la société et 
--nombre de commande effectuées,
--Si le client à effectuée moins de 10 commandes on mettra CLIENT OCCASIONNEL
--Si le client à effectuée entre 11 et 20  commandes on mettra CLIENT FREQUENT
--Si le client à effectuée entre 21 et 30 commandes on mettra CLIENT FIDEL
--Sinon un SUPER CLIENT.
create view TypologieClient as
select
c.ClientId,
c.NomSociete,
count(co.CommandeId) as NomCommande,
case 
	when count(co.CommandeId) between '0'and '10' then 'CLIENT OCCASIONNEL'
	when count(co.CommandeId) between '11' and '20' then 'CLIENT FREQUENT'
	when count(co.CommandeId) between '21' and '30' then 'CLIENT FIDEL'
	else 'SUPER CLIENT' 
	end as TypTopologique
From Commande co
left Join Client c on co.ClientId = c.ClientId
group by c.ClientId, c.NomSociete;

select *
from TypologieClient
