select Pays, count(*) as NombreClient
From Client
group by Pays
Having count(*) > 3; 
