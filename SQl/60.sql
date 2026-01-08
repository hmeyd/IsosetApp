--Ajouter la contrainte sur la surface qui sera entre 30 et 150
Alter Table SURFACE
Add constraint ct_Surface check ( SURFACE between 30 and 150)
