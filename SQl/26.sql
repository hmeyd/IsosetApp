select EmployeId, avg(Salaire) as Moyenne
from HistoriqueSalaires
group by EmployeId
order by EmployeId;
