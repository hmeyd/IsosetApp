namespace TpInvetaire
{
    class Program
    {
        static void Main()
        {
            GestionnaireProduits produits = new();
            GestionnaireProduits fichier = new();

                // Faire le choix.Modifier
                Console.WriteLine("saisie votre choix \n1-Ajouter\n2-Afficher\n3-Chercher\n4-Modifier5-Suprimer\n6-Quiter");
                
                string mot = Console.ReadLine();
                while(mot != "Quiter")
                {
                    if(mot == "Ajouter")
                    {
                        Console.WriteLine("saisie le nom de produit :");
                        string nom = Console.ReadLine();
                        Console.WriteLine("saisie la reference :");
                        string reference = Console.ReadLine();
                        Console.WriteLine("saisie le prix unitaire de produit :");
                        double prix = double.Parse(Console.ReadLine());
                        Console.WriteLine("saisie la Quantité :");
                        int quantite = int.Parse(Console.ReadLine());
                        Console.WriteLine("saisie la catagorie de produit :");
                        string categorie = Console.ReadLine();
                        Produit p = new(nom, reference, prix, quantite, categorie);
                        produits.AjouterProduit(p);
                    }
                    if (mot == "Afficher")
                    {
                    // Aficher tout le produit.
                    produits.AfficherTousProduits();
                    }
                    else if(mot == "Chercher")
                    {
                    // Recherche par reference.
                    Console.WriteLine("saisie la refernce");
                    string reference = Console.ReadLine();
                    produits.RechercherProduit(reference);
                    }
                    else if(mot == "Modifier")
                    {
                    // Modifier un produit.
                    Console.WriteLine("saisie le nom de produit :");
                    string nom = Console.ReadLine();
                    Console.WriteLine("saisie la reference :");
                    string reference = Console.ReadLine();
                    Console.WriteLine("saisie le prix unitaire de produit :");
                    double prix = double.Parse(Console.ReadLine());
                    Console.WriteLine("saisie la Quantité :");
                    int quantite = int.Parse(Console.ReadLine());
                    Console.WriteLine("saisie la catagorie de produit :");
                    string categorie = Console.ReadLine();
                    Produit nouveauProduit = new(nom, reference, prix, quantite, categorie);
                    produits.ModifierProduit(reference, nouveauProduit);
                    }
                    // Suprimer u produit
                    else if (mot == "Suprimer")
                    {
                        Console.WriteLine("Saisie la reference.");
                        string reference = Console.ReadLine();
                        produits.SupprimerProduit(reference);
                    }
                    else if(mot == "Aficher Statistique")
                    {
                        produits.AfficherStatistiques();
                    }

                    Console.WriteLine("Voulez vous continué ? oui non");
                    string decision = Console.ReadLine();
                    if (decision == "oui")
                    {
                        Console.WriteLine("saisie votre choix");
                        mot = Console.ReadLine();
                    }
                    else if(decision == "non")
                    {
                        mot = "Quiter";
                    }
                }
        
        }
    }
}

