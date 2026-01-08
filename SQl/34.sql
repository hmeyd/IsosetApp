select *
From Client;

select cl.ClientId, cm.CommandeId, cl.NomSociete, cl.ContactNom
From Client as cl
left join Commande as cm
on cm.ClientId = cl.ClientId;
