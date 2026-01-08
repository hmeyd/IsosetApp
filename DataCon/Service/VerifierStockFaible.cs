class VerifierStockFaible
{
    public void VeStockFaible()
    {
        
        string connectionString = @"Data Source=HMEYD\SQLEXPRESS;
                            Initial Catalog=GestionInventaire;
                            Integrated Security=True;
                            TrustServerCertificate=True;";

        DatabaseHelper dt = new DatabaseHelper(connectionString);
        GestionnaireProduits database = new (dt);
        Console.WriteLine("la seuil");
        int seuil = int.Parse(Console.ReadLine()); 
        database.VerifierStockFaible(seuil);
    }
}