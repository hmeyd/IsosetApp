class Suprimer
{
    public void suprimer()
    {
        string connectionString = @"Data Source=HMEYD\SQLEXPRESS;
                            Initial Catalog=GestionInventaire;
                            Integrated Security=True;
                            TrustServerCertificate=True;";

        DatabaseHelper dt = new DatabaseHelper(connectionString);
        GestionnaireProduits database = new (dt);
        Console.WriteLine("Saisie la reference.");
        string reference = Console.ReadLine();
        database.SupprimerProduit(reference);
    }
}