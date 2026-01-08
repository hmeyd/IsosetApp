--Afficher la liste des clients qui 
--n’ont pas de fax en mettant indéfini sur la colonne fax
select 
fax as Indefinie
from client
where fax is null