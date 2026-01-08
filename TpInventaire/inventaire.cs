namespace TpInvetaire
{
    // classe qui definis le Produit et ses methodes.
    class Produit
    {
        private readonly int id unique;
        private string Nom;  
        private string Reference;
        private double Prix; 
        private int Quantite; 
        private string Categorie;
        private DateTime DateCreation;
        private DateTime DateModification;
       // Le constructeur

        public Produit(string nom, string reference, double prix, int quantite, string categorie, DateTime dateCreation, DateTime dateModification)
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

        public double ValeurStock()
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
        public double prix
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
    // Methode pour afficher tout les parametres sous forme de chaine de charactere.
        public override string ToString()
        {
            return $"{Nom}|{Reference}|{Prix}|{Quantite}|{Categorie}";
        }
        // calcule de valeur de stock.
           

            }
}
    class GestionnaireProduits
    {
        //  charger
        public string[] ChargerProduits(string cheminFichier)
            {  
            try
            { 
                bool existe = cheminFichier.Any();
                if(!existe)
                {
                    File.Create(cheminFichier);
                    string [] T = [];
                    return T;
                }
                else
                {
                    string []lines = File.ReadAllLines(cheminFichier);
                    foreach(string line in lines)
                    {
                        try
                        {
                            string[] Parties = line.Split('|');
                            string Nom = Parties[0];
                            string Reference = Parties[1];
                            double Prix = double.Parse(Parties[2]);
                            int Quantite = int.Parse(Parties[3]);
                            string Categorie = Parties[4];
        
                            Produit produit = new(Nom, Reference, Prix, Quantite, Categorie);
                            GestionnaireProduits produits = new();
                            produits.AjouterProduit(produit);
                            return Parties;
                        }
                            catch (FormatException)
                            {
                                Console.WriteLine("Erreur de format dans la ligne : " + line);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Ligne invalide (pas assez de colonnes) : " + line);
                            }
                    }
                    }
                }
                
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Fichier introuvable !");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Accès refusé au fichier !");
                }
                    catch (IOException ex)
                {
                    Console.WriteLine("Erreur IO : " + ex.Message);
                }

            return [];
         }


        // sauvgarder

        public void SauvegarderProduits(string cheminFichier, Produit produit)
        {
            File.AppendAllText(cheminFichier, produit.ToString() + Environment.NewLine);
            try
            {
                string contenu = File.ReadAllText(cheminFichier);
            }
            catch (FileNotFoundException)
            {
            Console.WriteLine("Erreur : Le fichier n'existe pas.");
            }
            catch (UnauthorizedAccessException)
            {
            Console.WriteLine("Erreur : Accès refusé au fichier.");
            }
            catch (IOException ex)
            {
            Console.WriteLine("Erreur d'entrée/sortie : " + ex.Message);
            }
        }
    // Ajouter un Produit.
        List<Produit> produits = new();
        public void AjouterProduit(Produit p)
        {
            Produit resultat = produits.Find(prod => prod.reference == p.reference);

            if (resultat != null)
            {
            Console.WriteLine(" La référence existe déjà.");
            }
            else
            {
             // Ajouter dans la liste
            produits.Add(p);
            // Ajouter dans le fichier
            Console.WriteLine("saisie le chemin");
            //string cheminFichier = Console.ReadLine();
            string cheminFichier = Console.ReadLine();
            SauvegarderProduits(cheminFichier, p);
        }
    }
    // Afficher tout le produit.
        public void AfficherTousProduits()
        {
            Console.WriteLine("saisie le nom de fichier");
            string cheminFichier = Console.ReadLine();
            string[] text = ChargerProduits(cheminFichier);
            Console.WriteLine(text);
        } 

    
        public void RechercherProduit(string reference)
        {
            Console.WriteLine("saisie le nom de fichier");
            string Fichier = Console.ReadLine();
            string[] lignes = File.ReadAllLines(Fichier);

            foreach (string ligne in lignes)
            {
                string[] parties = ligne.Split('|');

                //parties[1] = Reference
                if (parties.Length >= 2 && parties[1] == reference)
                {
                    Console.WriteLine(ligne );
                }
            }
        }


        public void ModifierProduit(string reference, Produit nouveauProduit)
        {
            Console.WriteLine("le nom de fichier la au vous voulez sauvegarder");
            string Fichier = Console.ReadLine();
            string[] lines = File.ReadAllLines(Fichier);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parties = lines[i].Split('|');

                //parties[1] = Reference
                if (parties.Length >= 2 && parties[1] == reference)
                {
                    lines[i] = nouveauProduit.ToString();
                }
            }
            File.WriteAllLines(Fichier, lines);

            bool exist = produits.Any(produit => produit.reference == nouveauProduit.reference);
            Console.WriteLine(exist);
        }

        public void SupprimerProduit(string reference)
        {

            Console.WriteLine("saisie le nom de dossier");
            string Fichier = Console.ReadLine();
            string [] Lignes = File.ReadAllLines(Fichier);
            List<string> Lignes1 = new List<string>();
            int j =0;
            foreach(string ligne in Lignes)
            {
                string[] parties = ligne.Split("|");
                if (parties.Length >= 2 && parties[1] != reference)
                {
                    Lignes1.Add(ligne);
                
                }
            }
            File.WriteAllLines(Fichier, Lignes1);

            //produits.RemoveAll(produit => produit.reference == reference);

            bool exist = produits.Any(produit => produit.reference == reference);
            Console.WriteLine(exist ? true : false);

        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void AfficherStatistiques()
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
            Produit produit = new(nom, reference, prix, quantite, categorie);
            int nombreTotale = produits.Count();
            double Valeur = produit.ValeurStock();
            Console.WriteLine("La valeur est : " + Valeur + "euro.");

            double produitChere = produits.Max(produit => produit.prix);
            Console.WriteLine("le produit le plus chers est : " + produitChere);
        
        }  
    }

}
