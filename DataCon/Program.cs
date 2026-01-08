using System;
    class Program
    {
        static void Main()
        { 
                Console.WriteLine("1-Ajouter\n2-Afficher\n3-Chercher\n4-Modifier\n5-Suprimer\n6-Statistique\n7-VerifierStockFaible\n8-Quitter");
                string mot = Console.ReadLine();
                while(mot != "Quiter")
                {
                    if(mot == "Ajouter")
                    {
                        Ajouter ajouter = new();
                        ajouter.ajouter();
                        
                    }
                    if (mot == "Afficher")
                    {
                        Afficher afficher = new();
                        afficher.afficher();
                    }
                    else if(mot == "Chercher")
                    {
                        Chercher chercher = new();
                        chercher.chercher();
                    }
                    else if(mot == "Modifier")
                    {
                        Modifier modifier = new();
                        modifier.modifier();
                    }
                    // Suprimer u produit
                    else if (mot == "Suprimer")
                    {
                       Suprimer suprimer =new();
                       suprimer.suprimer();
                    }
                    else if(mot == "Statistique")
                    {
                        AfficherStatistique afficherStatistique = new();
                        afficherStatistique.afficherStatique();
                    }
                    else if (mot == "VerifierStockFaible")
                    {
                        VerifierStockFaible VS = new();
                        VS.VeStockFaible();
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



