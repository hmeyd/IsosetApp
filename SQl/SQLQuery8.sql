select *
From Client
where Region = 'SP'
or Region <> 'SP';


select *
From Client
where Region is NULL;

Select Ville + ' ' + Isnull(Region, 'Inconnu') 
From Client;


Select *,
Year(DateCommande) as Annee,
Datediff(Day, DateCommande, DateDemandee)as[Difference],
DateAdd(Day, 30, DateCommande) as Plus30j
From Commande;


select *
From client;



Select ContactNom,
--CHARINDEX(' ', ContactNom)
Left(ContactNom, Charindex(' ', ContactNom) - 1),
SUBSTRING(ContactNom, CHARINDEX(' ', ContactNom) + 1, 100)
--SUBSTRING(ContactNom, CHARINDEX(' ', ContactNom), len(ContactNom) - Charindex(' ', ContactNom) + 1)
From Client;

Select
	CommandeId,
	Cast(CommandeId as decimal(8,2)) / 2,
	Transport,
	Coalesce(Transport, 0) * 2,
	CEILING(Transport),
	Floor(Transport),
	Round(Transport, 1)
	From Commande;


	select *
	From Commande
	Where Month(DateCommande) = 7
	and Year(DateCommande) = 1996;


	select *
	From Commande
	Where DateCommande Between '19960701' and '19960731 23:59:59';

	Select *
	From Employe
	Where Prenom In ('André', 'Anne');

	Select *
	From Employe
	Where Prenom not In ('André', 'Anne');

	Select *
	From Employe
	Where EmployeId Between 2 and 6;

	Select *
	From Employe
	Where EmployeId not Between 2 and 6;


	Select *
	From Employe
	Where EmployeId >= 2 and EmployeId <= 6;


	select *
	From Employe
	where Prenom Like 'A%'

	select *
	From Employe
	where Prenom Like '%ne'

	-- replacer les 1er lettres par "--" ou [JSP]eanne
	select *
	From Employe
	where Prenom Like '__anne'


select 
	NomSociete,
	Pays,
	-- selon le pays qu'on a reagir
	Case Pays
		when 'Germany' Then 'Tempéré'
		when 'France' then 'Tempéré'
		when 'Mexico' then 'chaud'
		when 'canada' then 'Frais'
		when 'Uk' then 'Frais'
		Else 'ne sait pas'
		End
	From Client;


select 
	NomSociete,
	Pays,
	-- selon le pays qu'on a reagir
	Case 
		when Pays IN ('Germany', 'France') or Region = 'BC' then 'Tempéré'
		when Pays In ('Mexico', 'Spain') then 'chaud'
		when Pays In ('canada', 'UK') then 'Frais'
		Else 'ne sait pas'
		End
	From Client;


select 
	NomSociete,
	Pays,
	-- selon le pays qu'on a reagir
	Region
		
	From Client
	Order BY Case Pays
			when 'France' then 1
			else 2
			end ,
		Pays;

select 
co.CommandeId, co.DateCommande,
cl.NomSociete, e.Nom, e.Prenom
from Commande As co
Join Client As cl on co.ClientId = cl.ClientId
join Employe As e On co.EmployeId = e.EmployeId;


select 
co.CommandeId, co.DateCommande,
cl.NomSociete, e.Nom, e.Prenom
from Commande As co
Join Client As cl on co.ClientId = cl.ClientId
join Employe As e On co.EmployeId = e.EmployeId
order by e.EmployeId;


select *
From Commande As co1
join Commande as co2
on co1.ClientId = co2.ClientId
and co1.EmployeId <> co2.EmployeId
where co1.CommandeId > co2.CommandeId;



select *
From Commande As co1
join Commande as co2
on co1.ClientId = co2.ClientId
and co1.EmployeId <> co2.EmployeId
join Client as c1 on co1.ClientId = c1.ClientId
join Employe As e1 On co1.EmployeId = e1.EmployeId
join Employe as e2 on co2.EmployeId = e2.EmployeId
where co1.CommandeId > co2.CommandeId;


select *
From Client c1
Join Commande co On c1.ClientId = co.ClientId
Where c1.ClientId In ('OTTIK', 'PARIS');

select *
From Client c1
left outer Join Commande co On c1.ClientId = co.ClientId
Where c1.ClientId In ('OTTIK', 'PARIS');


select NomSociete, ContactNom From Client
union All
select NomSociete, ContactNom from Fournisseur;

select NomSociete, ContactNom From Client
intersect
select NomSociete, ContactNom from Fournisseur;

select NomSociete, ContactNom From Client
except
select NomSociete, ContactNom from Fournisseur;
select *
from
	(select * from Client) as t;

select CommandeId,
(select NomSociete From Client As c1  Where c1.ClientId = co.ClientId) as NomClient
from Commande as co;

Select *
From Employe e1 
Where SalaireActuel In (
select SalaireActuel
	From Employe e2 where e1.EmployeId <> e2.EmployeId);

Select *
From Client c1
where not exists(
	select *
	from Commande co
	where co.ClientId = c1.ClientId);

Select *
from Client cl
where ClientId
Not In (
select ClientId
From Commande co);

select *
From Commande
where DateCommande >= All (select DateCommande From Commande);


select *
From Commande c1
where Not exists(select * From commande c2 where c2.DateCommande > c1.DateCommande);


select *
from Client
Where ClientId not in (select ClientId from Commande);


select *
from Client
where ClientId <> All (select  ClientId From Commande);

select *
From Employe as e 
where SalaireActuel > Any (select SalaireActuel From Employe where Titre = 'Commercial');

select *
From Employe as e 
where SalaireActuel > All (select SalaireActuel From Employe where Titre = 'Commercial');

select count (*) As NombreDeLinges,
max(DateCommande) As MaxDates,
min(DateCommande) as minDate,
sum(Transport) as Somme,
avg(Transport) as Moyenne,
count(distinct ClientId) as NombreDeClientId
From Commande;

select count(*)
from Client
where Region is null;

select 
	--ClientId,
	Sum(Transport) Totale,
	count(*) Nombre,
	min(DateCommande) PremierDate,
	max(DateCommande) DerenierDate
From Commande
Group By ClientId
order by Nombre Desc;

select Transport

From Commande;

-- insert
insert into Client(ClientId, NomSociete, Ville, Pays)
Values ('doura', 'video2Brain1', 'Paris', 'France'),
		('Ahmed', 'AhmedSociete', 'nouakchott', 'Mauritanie'),
		('carot', 'patatSublim', 'Toulouse', 'France'),
		('tomat', 'video2Brain2', 'Madrid', 'Spain');

select * from Transporteur;

insert into Transporteur (NomSociete, Telephone)
values ('Speedy Delivery', Null);

insert into dbo.Transporteur
select NomSociete, Telephone
from Fournisseur
where FournisseurId <= 5;

select * from Transporteur;


select * from Client where clientId = 'Paris';
update Client
set Ville = Upper(Ville);
Update Client
set Adresse = '12, rue du commerce',
	Region = 'IDF',
	CodePostal = '67788',
	Telephone = Null,
	Fax = Null
where ClientId = 'Paris';


Update Employe
set Civilite =
 case Civilite 
		when 'MS.' then 'MMe'
		when 'Mlle.' then 'Mll'
		when 'Mr.' then 'M.'
		Else Civilite
	End
select * from Employe

delete From Client
where ClientId = 'Paris';

delete from LigneCommandes
where CommandeId in (
	Select CommandeId
	from commande
	where ClientId= 'ALFKI');

Delete from Commande
where ClientId = 'ALFKI';

Delete from Client
where ClientId = 'ALFKI';

select count(*)
from Commande;
select *
from Client
where ClientId = 'Paris';


Merge into Client c
using (Select 'Paris' as ClientId, 'Paris Boisson' as NomSociete, 'Paris' as Ville, 'France' as Pays) source
On (c.ClientId = source.ClientId)
when Matched then
Update set NomSociete = source.NomSociete
when not Matched then
insert (ClientId, NomSociete, Ville , Pays)
values(source.ClientId, source.NomSociete, source.Ville, source.Pays);

