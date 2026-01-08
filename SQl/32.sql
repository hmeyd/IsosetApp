select e.Prenom, CommandeId
from Employe e
join Commande co on e.Prenom = 'Marianne'
