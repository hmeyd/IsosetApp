--- grouper par transporteurId 

select TransporteurId,
sum(Transport) as chiffreAffiare
from Commande
group by TransporteurId;
