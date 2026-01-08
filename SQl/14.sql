-- Lister les clients qui ne vivent pas en Angleterre
select *
from client
where Pays != 'UK'
