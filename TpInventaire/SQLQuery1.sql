 CREATE DATABASE GestionInventaire;
 GO
 USE GestionInventaire;
 GO
 CREATE TABLE Produits (
 Id INT PRIMARY KEY IDENTITY(1,1),
 Nom NVARCHAR(100) NOT NULL,
 Reference NVARCHAR(50) UNIQUE NOT NULL,
 Prix DECIMAL(10, 2) NOT NULL CHECK (Prix > 0),
 Quantite INT NOT NULL CHECK (Quantite >= 0),
 Categorie NVARCHAR(50) NOT NULL,
 DateCreation DATETIME DEFAULT GETDATE(),
 DateModification DATETIME DEFAULT GETDATE()
 );
 GO-- Index pour optimiser les recherches
 CREATE INDEX IX_Produits_Reference ON Produits(Reference);
 CREATE INDEX IX_Produits_Categorie ON Produits(Categorie);
 GO

 select *
 from Produits

DROP DATAbASE GestionInventaire;
