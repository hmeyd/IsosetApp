--étrangère de la colonne CODE_LOCATAIRE
Alter table maison
Add constraint Fk_CODELOCATAIRE foreign key (CODE_LOCATAIRE)
REFERENCES LOCATAIRES(CODE_LOCATAIRE);
