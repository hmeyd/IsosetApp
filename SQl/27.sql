select EmployeId, sum(Salaire) as MaximumSalaire
from HistoriqueSalaires
group by EmployeId
order by EmployeId Desc;
