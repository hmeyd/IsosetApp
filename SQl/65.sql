--créer un vue représentant  le CA (chiffre d’affaire) de chaque employé 
--pour chaque annee
create view ChiffA as
select
e.Nom,
Year(co.DateCommande) as Annee,
sum(PrixUnitaire * Quantite) as ChiffreA
from LigneCommandes lc
join Commande co on Lc.CommandeId = co.CommandeId
join Employe e on e.EmployeId = co.EmployeId
group by Nom, Year(co.DateCommande)




select *
from ChiffA
order by Nom ASc, Annee desc;
