--Afficher le nom de société, le des ':' entre chaque champs. 
select
NomSociete + ':' + ContactNom + ':' + ContactTitre as tout
from client
