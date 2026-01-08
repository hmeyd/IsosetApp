-- Afficher les clients anglais ou français

select *
from client
where Pays in ('UK', 'france')