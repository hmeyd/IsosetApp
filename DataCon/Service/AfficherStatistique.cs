class AfficherStatistique
{
    public void afficherStatique()

    {
        string connectionString = @"Data Source=HMEYD\SQLEXPRESS;
                            Initial Catalog=GestionInventaire;
                            Integrated Security=True;
                            TrustServerCertificate=True;";

        DatabaseHelper dt = new DatabaseHelper(connectionString);
        GestionnaireProduits database = new (dt);
        database.AfficherStatistiques();
    }
}