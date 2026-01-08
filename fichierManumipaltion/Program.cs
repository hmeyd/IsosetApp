using System.IO;

class Program
{
    static void Main()
    {
        Persistance fichier = new();
        fichier.SauvegarderProduits("Ecole.txt");
    }
}
