select *
From Employe as e
join Division as div on e.DivisionId = div.DivisionId
where div.NomDivision = 'Europe';
