using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;



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
        string query = "SELECT COUNT(*) FROM Produit WHERE Reference = @Reference";

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
            INSERT INTO Produit(Nom, Reference, Prix, Quantite, Categorie)
            VALUES(@Nom, @Reference, @Prix, @Quantite, @Categorie)";

        using (SqlConnection con = _db.GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Nom", produit.Nom);
            cmd.Parameters.AddWithValue("@Reference", produit.Reference);
            cmd.Parameters.AddWithValue("@Prix", produit.Prix);
            cmd.Parameters.AddWithValue("@Quantite", produit.Quantite);
            cmd.Parameters.AddWithValue("@Categorie", produit.Categorie);

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
            FROM Produit
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
            UPDATE Produit
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
        string query = "DELETE FROM Produit WHERE Reference = @Reference";

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
        string queryCount = "SELECT COUNT(*) FROM Produit";
        string querySum = "SELECT SUM(Prix * Quantite) FROM Produit";
        string queryTop = "SELECT TOP 1 Nom, Prix FROM Produit ORDER BY Prix DESC";

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
                if (!reader.Read())
                {
                    return;
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
            FROM Produit
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
    public string[] VerifierStockFaible(int seuilMinimum = 5)
    {
        
        List<string> produits = new List<string>();
        string query = @"
            SELECT Id, Nom, Reference, Prix, Quantite, Categorie, DateCreation, DateModification
            FROM Produit
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
                    produits.Add(
                        $"{reader["Id"]} | {reader["Nom"]} | {reader["Reference"]} | {reader["Prix"]} | {reader["Quantite"]}"
                    );
                }
            }
        }
        int i = produits.Count();
        if (i == 0)
        {
            Console.WriteLine("aucun produit est inferieur au " + seuilMinimum + ".");
        }
        else
        {
            Console.WriteLine("voici la liste de produits inferieur au seuil");
            Console.WriteLine(string.Join("\n", produits));
        }
      
            return produits.ToArray();
    }
}


