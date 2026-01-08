-- Supprimer les anciennes tables si elles existent
DROP TABLE IF EXISTS facture;
DROP TABLE IF EXISTS article;
DROP TABLE IF EXISTS commande;
DROP TABLE IF EXISTS client;

-- Table client
CREATE TABLE client (
    num_client INTEGER PRIMARY KEY,
    nom VARCHAR(50),
    prenom VARCHAR(50),
    adresse VARCHAR(200),
    telephone VARCHAR(20)
);

-- Table commande
CREATE TABLE commande (
    num_commande INTEGER PRIMARY KEY,
    date_commande TEXT NOT NULL,
    num_client INTEGER NOT NULL,
    FOREIGN KEY (num_client) REFERENCES client(num_client)
);

-- Table article
CREATE TABLE article (
    numero_article INTEGER PRIMARY KEY,
    num_commande INTEGER NOT NULL,
    designation VARCHAR(100) NOT NULL,
    prix_hors_taxe FLOAT NOT NULL,
    FOREIGN KEY (num_commande) REFERENCES commande(num_commande)
);

-- Table facture
CREATE TABLE facture (
    num_facture INTEGER PRIMARY KEY,
    num_commande INTEGER NOT NULL,
    num_client INTEGER NOT NULL,
    nom_facture VARCHAR(100),
    adresse_facture VARCHAR(200),
    montant_totale FLOAT NOT NULL,
    mode_paiement VARCHAR(50),
    FOREIGN KEY (num_commande) REFERENCES commande(num_commande),
    FOREIGN KEY (num_client) REFERENCES client(num_client)
);

-- -----------------------------
-- Insertion des données exemples
-- -----------------------------

-- Clients
INSERT INTO client (num_client, nom, prenom, adresse, telephone)
VALUES
(1, 'Hmeyd', 'Ahmed', 'maison Alfort, 94000 creteil', '0701020304'),
(2, 'Saidou', 'diallo', '25 boulevard Armand duportal, 31000 toulouse', '0605060708');

-- Commandes
INSERT INTO commande (num_commande, date_commande, num_client)
VALUES
(101, '2025-11-09', 1),
(103, '2025-11-09', 1),
(102, '2025-11-10', 2);

-- Articles
INSERT INTO article (numero_article, num_commande, designation, prix_hors_taxe)
VALUES
(1001, 101, 'Ordinateur portable', 1200.50),
(1002, 101, 'Souris sans fil', 25.99),
(1004, 103, 'Écran 24 pouces', 150.00),
(1003, 102, 'Clavier mécanique', 80.00);

-- Factures
INSERT INTO facture (num_facture, num_commande, num_client, nom_facture, adresse_facture, montant_totale, mode_paiement)
VALUES
(5001, 101, 1, 'Facture Hmeyd', '10 rue de Paris, 75000 Paris', 1226.49, 'Carte bancaire'),
(5003, 103, 1, 'Facture Hmeyd', '10 rue de Paris, 75000 Paris', 150.00, 'PayPal'),
(5002, 102, 2, 'facture Diallo', '20 avenue Lyon, 69000 Lyon', 80.00, 'Virement');

