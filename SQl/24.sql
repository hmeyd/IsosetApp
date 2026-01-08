select EmployeId, Max(Salaire) as MaximumSalaire
from HistoriqueSalaires
group by EmployeId
order by EmployeId;
