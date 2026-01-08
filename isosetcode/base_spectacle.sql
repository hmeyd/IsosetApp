-- Table SPECTACLE
CREATE TABLE Spectacle (
    id_spectacle INT PRIMARY KEY AUTO_INCREMENT,
    titre VARCHAR(100) NOT NULL,
    genre VARCHAR(50),
    duree INT
);

-- Table REPRESENTATION
CREATE TABLE Representation (
    id_repr INT PRIMARY KEY AUTO_INCREMENT,
    date_repr DATE NOT NULL,
    heure TIME NOT NULL,
    id_spectacle INT,
    FOREIGN KEY (id_spectacle) REFERENCES Spectacle(id_spectacle) ON DELETE CASCADE
);

-- Table UTILISATEUR
CREATE TABLE Utilisateur (
    id_user INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL
);

-- Table RESERVATION
CREATE TABLE Reservation (
    id_res INT PRIMARY KEY AUTO_INCREMENT,
    nb_places INT NOT NULL,
    id_user INT,
    id_repr INT,
    FOREIGN KEY (id_user) REFERENCES Utilisateur(id_user) ON DELETE CASCADE,
    FOREIGN KEY (id_repr) REFERENCES Representation(id_repr) ON DELETE CASCADE
);
INSERT INTO Spectacle (titre, genre, duree) VALUES
('Le Roi Lion', 'Comédie musicale', 120),
('Roméo et Juliette', 'Théâtre', 150),
('Le Cirque du Soleil', 'Spectacle', 180);

INSERT INTO Representation (date_repr, heure, id_spectacle) VALUES
('2025-11-10', '20:00:00', 1),
('2025-11-11', '18:30:00', 2),
('2025-11-12', '21:00:00', 3);

INSERT INTO Utilisateur (nom, email) VALUES
('Alice Dupont', 'alice@example.com'),
('Bob Martin', 'bob@example.com'),
('Claire Leroy', 'claire@example.com');

INSERT INTO Reservation (nb_places, id_user, id_repr) VALUES
(2, 1, 1),
(3, 2, 2),
(1, 3, 3);
