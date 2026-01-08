using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


public class DatabaseHelper
{
    private string _connectionString;

    public DatabaseHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}

public class GestionnaireProduits
{
    private DatabaseHelper _db;

    public GestionnaireProduits(DatabaseHelper db)
    {
        _db = db;
    }


    // Vérifie si le produit existe
    public bool Existe(string reference)
    {
        string query = "SELECT COUNT(*) FROM Produits WHERE Reference = @Reference";

        using (SqlConnection con = _db.GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Reference", reference);
            con.Open();

            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }


    // Ajout d'un produit
    public int AjouterProduit(Produit produit)
    {
        if (Existe(produit.Reference))
        {
            Console.WriteLine("Le produit avec cette référence existe déjà.");
            return -1;
        }

        string query = @"
            INSERT INTO Produits(Id, Nom, Reference, Prix, Quantite, Categorie, DateCreation, DateModification)
            VALUES(@Id, @Nom, @Reference, @Prix, @Quantite, @Categorie, @DateCreation, @DateModification)";

        using (SqlConnection con = _db.GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Id", produit.Id);
            cmd.Parameters.AddWithValue("@Nom", produit.Nom);
            cmd.Parameters.AddWithValue("@Reference", produit.Reference);
            cmd.Parameters.AddWithValue("@Prix", produit.Prix);
            cmd.Parameters.AddWithValue("@Quantite", produit.Quantite);
            cmd.Parameters.AddWithValue("@Categorie", produit.Categorie);
            cmd.Parameters.AddWithValue("@DateCreation", produit.DateCreation);
            cmd.Parameters.AddWithValue("@DateModification", produit.DateModification);

            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }


    // Afficher tous les produits
    public string[] AfficherTousProduits()
    {
        List<string> produits = new List<string>();

        string query = @"
            SELECT Id, Nom, Reference, Prix, Quantite, Categorie, DateCreation, DateModification 
            FROM Produits
            ORDER BY Nom";

        using (SqlConnection con = _db.GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("Aucun produit trouvé.");
                    return Array.Empty<string>();
                }

                while (reader.Read())
                {
                    produits.Add(
                        $"{reader["Id"]} - {reader["Nom"]} - {reader["Reference"]} - {reader["Prix"]} - {reader["Quantite"]} - {reader["Categorie"]}"
                    );
                }
            }
        }

        return produits.ToArray();
    }


    // Modifier un produit
    public bool ModifierProduit(Produit produit)
    {
        string query = @"
            UPDATE Produits
            SET Nom = @Nom, 
                Prix = @Prix,
                Quantite = @Quantite,
                Categorie = @Categorie,
                DateModification = GETDATE()
            WHERE Reference = @Reference";

        using (SqlConnection con = _db.GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Nom", produit.Nom);
            cmd.Parameters.AddWithValue("@Prix", produit.Prix);
            cmd.Parameters.AddWithValue("@Quantite", produit.Quantite);
            cmd.Parameters.AddWithValue("@Categorie", produit.Categorie);
            cmd.Parameters.AddWithValue("@Reference", produit.Reference);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
    }


    // Supprimer un produit
    public bool SupprimerProduit(string reference)
    {
        string query = "DELETE FROM Produits WHERE Reference = @Reference";

        using (SqlConnection con = _db.GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Reference", reference);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            return rows > 0;
        }
    }


    // Statistiques
    public void AfficherStatistiques()
    {
        string queryCount = "SELECT COUNT(*) FROM Produits";
        string querySum = "SELECT SUM(Prix * Quantite) FROM Produits";
        string queryTop = "SELECT TOP 1 Nom, Prix FROM Produits ORDER BY Prix DESC";

        using (SqlConnection con = _db.GetConnection())
        {
            con.Open();

            using (SqlCommand cmd = new SqlCommand(queryCount, con))
            {
                int nb = (int)cmd.ExecuteScalar();
                Console.WriteLine("Nombre de produits : " + nb);
            }

            using (SqlCommand cmd = new SqlCommand(querySum, con))
            {
                object result = cmd.ExecuteScalar();
                decimal ca = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                Console.WriteLine("Chiffre d'affaires total : " + ca);
            }

            using (SqlCommand cmd = new SqlCommand(queryTop, con))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine($"Produit le plus cher : {reader["Nom"]} - {reader["Prix"]}");
                }
            }
        }
    }


    // Par catégorie
    public string[] ObtenirProduitsParCategorie(string categorie)
    {
        List<string> produits = new List<string>();

        string query = @"
            SELECT Id, Nom, Reference, Prix, Quantite, Categorie
            FROM Produits
            WHERE Categorie = @Categorie";

        using (SqlConnection con = _db.GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Categorie", categorie);

            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    produits.Add(
                        $"{reader["Id"]} | {reader["Nom"]} | {reader["Reference"]} | {reader["Prix"]} | {reader["Quantite"]}"
                    );
                }
            }
        }

        return produits.ToArray();
    }


    // Vérifier les stocks faibles
    public List<Produit> VerifierStockFaible(int seuilMinimum = 5)
    {
        List<Produit> faibles = new List<Produit>();

        string query = @"
            SELECT Id, Nom, Reference, Prix, Quantite, Categorie, DateCreation, DateModification
            FROM Produits
            WHERE Quantite < @Seuil";

        using (SqlConnection con = _db.GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Seuil", seuilMinimum);

            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Produit p = new Produit()
                    {
                        Id = (int)reader["Id"],
                        Nom = (string)reader["Nom"],
                        Reference = (string)reader["Reference"],
                        Prix = (decimal)reader["Prix"],
                        Quantite = (int)reader["Quantite"],
                        Categorie = (string)reader["Categorie"],
                        DateCreation = (DateTime)reader["DateCreation"],
                        DateModification = (DateTime)reader["DateModification"]
                    };

                    faibles.Add(p);
                    Console.WriteLine($"Stock faible : {p.Nom} ({p.Reference}) – Qté : {p.Quantite}");
                }
            }
        }

        return faibles;
    }
}


// Exemple de classe Produit
public class Produit
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Reference { get; set; }
    public decimal Prix { get; set; }
    public int Quantite { get; set; }
    public string Categorie { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateModification { get; set; }

       // Le constructeur

        public Produit(string nom, string reference, decimal prix, int quantite, string categorie, DateTime dateCreation, DateTime dateModification)
        {
            Nom = nom;
            Reference = reference;
            Prix = prix;
            Quantite = quantite;
            Categorie = categorie;
            DateCreation = dateCreation;
            DateModification = dateModification;
        }

        public override string ToString()
        {
            return $"{Nom}|{Reference}|{Prix}|{Quantite}|{Categorie}";
        }

        public decimal ValeurStock()
        {
            return Prix * Quantite;
        }

        // get et set nom.
        public string nom
        {
            get{return Nom;}
            set
            {
                if(nom is string)
                {
                    nom = value;
                }
                else
                    throw new Exception("le nom dois être une chaine de charactere");
            }
        }
    // Get et set reference.
        public string reference
        {
            get{return Reference;}
            set
            {
                if(reference is string)
                {
                    reference = value;
                }
                else
                    throw new Exception("le nom dois être une chaine de charactere");
            }
        }
    //Get et set categorie.
        public string categorie
        {
            get{return Categorie;}
            set 
            {
                if(categorie is string)
                {
                    categorie = value;
                }
                else
                    throw new Exception("categorie doit être une chaine de charactere");
            }
        }

        // Get et set prix.
        public decimal prix
        {
            get{return Prix;}
            set
            {
                if(value > 0)
                {
                    prix = value;
                } 
                else
                    throw new Exception("Le prix ne dois pas être negative");
            }
        }

        //Get et set quantite.
        public int quantite
        {
            get{return Quantite;}
            set
            {
                if(value is < 0)
                {
                    quantite = value;
                }
                else
                    throw new Exception("le quantite dois etre un entier positive");
            }
        }

}


