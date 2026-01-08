select EmployeId, Min(Salaire) as Minumum
from HistoriqueSalaires
group by EmployeId
order by Minumum Desc;
