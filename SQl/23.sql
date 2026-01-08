select NomSociete, Pays,
case Pays
	when 'Germany' then 'tempéré'
	when 'France' then 'moyen tempéré'
	when 'Mexico' then 'chaud'
	when 'Canda' then 'frais'
	Else 'ne sais pas'
	end as Climat
from Client;


--Germany --> tempéré, 
--> tempéré,  
--France--> moyen tempéré, 
--> moyen tempéré,  
--Mexico--> chaud, 
--> chaud,  
--Canada --> frais, 
--> frais,  
--Autres pays ----> ne sait pas
 --> ne sait pas  