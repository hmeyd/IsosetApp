class Afficher
{
    public void afficher()
    {
        string connectionString = @"Data Source=HMEYD\SQLEXPRESS;
                            Initial Catalog=GestionInventaire;
                            Integrated Security=True;
                            TrustServerCertificate=True;";

        DatabaseHelper dt = new DatabaseHelper(connectionString);
        GestionnaireProduits database = new (dt);
        string[] produits = database.AfficherTousProduits();
        Console.WriteLine(string.Join("\n", produits));
    }
}