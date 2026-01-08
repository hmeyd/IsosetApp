class Ajouter
{
  
    public void ajouter()
    {
         string connectionString = @"Data Source=HMEYD\SQLEXPRESS;
                            Initial Catalog=GestionInventaire;
                            Integrated Security=True;
                            TrustServerCertificate=True;";

        DatabaseHelper dt = new DatabaseHelper(connectionString);
        GestionnaireProduits database = new (dt);
    Console.WriteLine("saisie le nom de produit :");
    string nom = Console.ReadLine();
    Console.WriteLine("saisie la reference :");
    string reference = Console.ReadLine();
    Console.WriteLine("saisie le prix unitaire de produit :");
    decimal prix = decimal.Parse(Console.ReadLine());
    Console.WriteLine("saisie la Quantité :");
    int quantite = int.Parse(Console.ReadLine());
    Console.WriteLine("saisie la catagorie de produit :");
    string categorie = Console.ReadLine();

    Produit p = new Produit(nom, reference, prix, quantite, categorie);
    database.AjouterProduit(p);
    }
}