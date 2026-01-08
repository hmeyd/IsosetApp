-- Ajouter la contrainte clés 
-- primaire pour la colonne NUM_MAISON
ALTER TABLE maison
ADD CONSTRAINT PK_NumMaison PRIMARY KEY (NUM_MAISON);
