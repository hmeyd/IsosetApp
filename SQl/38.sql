select count(DivisionId) as NombreEmploye, DivisionId
from Employe
group by DivisionId;
