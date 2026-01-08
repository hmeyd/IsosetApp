--Afficher les clients pour
--lesquels la région n'est pas renseignée

select *
from client
where Region is null
