class Chercher
{
    public void chercher()
    {
        string connectionString = @"Data Source=HMEYD\SQLEXPRESS;
                            Initial Catalog=GestionInventaire;
                            Integrated Security=True;
                            TrustServerCertificate=True;";

        DatabaseHelper dt = new DatabaseHelper(connectionString);
        GestionnaireProduits database = new (dt);
        Console.WriteLine("saisie la categorie");
        string categorie = Console.ReadLine();
        Console.WriteLine(string.Join(Environment.NewLine, database.ObtenirProduitsParCategorie(categorie)));
    }
}