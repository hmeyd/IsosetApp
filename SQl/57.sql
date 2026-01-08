--NUM_MAISON : Non nul  / CODE_LOCATAIRE : non nul
--CODE_LOCATAIRE : non nul 
--NBR_CHAMBRE Non Nul / SURFACE INTEGER : Non nul 

Create Table maison
(
NUM_MAISON VARCHAR(50) NOT NULL,
CODE_LOCATAIRE Varchar(50) not Null,
NBR_CHAMBRE Varchar(50) not null,
SURFACE INT not null
)