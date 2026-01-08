--Lister en une seule colonne les NomSociéte ainsi 
--que les ContactNom  de la table client 
 
 select 
 NomSociete + '-'+ ContactNom as NomContact

 from client