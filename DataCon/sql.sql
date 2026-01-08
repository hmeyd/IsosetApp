CREATE DATABASE GestionInventaire;
GO

USE GestionInventaire;
GO

CREATE TABLE Produit (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nom NVARCHAR(100) NOT NULL,
    Reference NVARCHAR(50) UNIQUE NOT NULL,
    Prix DECIMAL(10, 2) NOT NULL CHECK (Prix > 0),
    Quantite INT NOT NULL CHECK (Quantite >= 0),
    Categorie NVARCHAR(50) NOT NULL,
    DateCreation DATETIME DEFAULT GETDATE(),
    DateModification DATETIME DEFAULT GETDATE()
);
GO

-- Index pour optimiser les recherches
CREATE INDEX IX_Produit_Reference ON Produit(Reference);
CREATE INDEX IX_Produit_Categorie ON Produit(Categorie);
GO

SELECT name FROM sys.databases;

select *
from Produit

INSERT INTO Produit (Nom, Reference, Prix, Quantite, Categorie)
VALUES
('Clavier mécanique', 'REF001', 89.99, 15, 'Informatique'),
('Souris gaming', 'REF002', 49.99, 30, 'Informatique'),
('Écran 24 pouces', 'REF003', 159.99, 12, 'Informatique'),
('Chaise de bureau', 'REF004', 129.99, 8, 'Mobilier'),
('Lampe LED', 'REF005', 19.99, 50, 'Maison');

SELECT * FROM Produit WHERE Categorie = 'Informatique';

