create Table LOCATAIRES
(
CODE_LOCATAIRE int Identity(1,1) primary key,
Nom varchar(50) not null,
Prenom varchar(50) not null,
Age int check (Age between 18 and 70),
Mail varchar(100),
DATE_LOCATION date default getdate(),
ADRESSE varchar(250),
DEPARTEMENT varchar(50)
)
