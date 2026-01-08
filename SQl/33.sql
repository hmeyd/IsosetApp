select *
from Client
where ClientId 
not in (select ClientId From Commande);