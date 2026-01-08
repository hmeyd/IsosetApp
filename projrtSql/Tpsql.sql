-- Création des tables
CREATE TABLE Auteurs (
    AuteurID INT PRIMARY KEY,
    Nom VARCHAR(50),
    Prenom VARCHAR(50),
    DateNaissance DATE
);

CREATE TABLE Livres (
    LivreID INT PRIMARY KEY,
    Titre VARCHAR(100),
    AuteurID INT,
    DatePublication DATE,
    Prix DECIMAL(6,2),
    Stock INT,
    FOREIGN KEY (AuteurID) REFERENCES Auteurs(AuteurID)
);

CREATE TABLE Emprunteurs (
    EmprunteurID INT PRIMARY KEY,
    Nom VARCHAR(50),
    Prenom VARCHAR(50),
    Email VARCHAR(100)
);

CREATE TABLE Emprunts (
    EmpruntID INT PRIMARY KEY,
    EmprunteurID INT,
    LivreID INT,
    DateEmprunt DATE,
    DateRetour DATE,
    FOREIGN KEY (EmprunteurID) REFERENCES Emprunteurs(EmprunteurID),
    FOREIGN KEY (LivreID) REFERENCES Livres(LivreID)
);

-- Insertion des données
INSERT INTO Auteurs VALUES (1, 'Hemingway', 'Ernest', '1899-07-21');
INSERT INTO Auteurs VALUES (2, 'Orwell', 'George', '1903-06-25');

INSERT INTO Livres VALUES (1, 'Le Vieil Homme et la Mer', 1, '1952-09-01', 15.50, 5);
INSERT INTO Livres VALUES (2, '1984', 2, '1949-06-08', 12.00, 3);

INSERT INTO Emprunteurs VALUES (1, 'Dupont', 'Jean', 'jean.dupont@mail.com');
INSERT INTO Emprunteurs VALUES (2, 'Martin', 'Claire', 'claire.martin@mail.com');

INSERT INTO Emprunts VALUES (1, 1, 2, '2025-01-01', '2025-01-15');
