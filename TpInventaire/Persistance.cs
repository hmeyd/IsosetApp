using System;
using System.IO;
namespace TpInvetaire
{
    class Persistance
    {
        

            public void ChargerProduits(string cheminFichier)
            {  
            try
            { 
                bool existe = cheminFichier.Any();
                if(!existe)
                {
                    File.Create(cheminFichier);
                    File.WriteAllText(cheminFichier, "");
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


         }
    }            

}
