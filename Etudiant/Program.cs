class Etudiant
{
    // attribues et properietés.
    private string Nom;
    private float Note1;
    private float Note2;


    // constructeur.
    public Etudiant(string nom, float note1, float note2)
    {
        Nom = nom;
        Note1 = note1;
        Note2 = note2;
    }

    //Les méthodes.
    // Une methode qui calcule la Moyenne.
    public float Moyenne()
    {
        float Moy = (Note1 + Note2) / 2;
        return Moy;
    }

    // Une methode d'affichage
    public void Afficher()
    {
        float Moy = Moyenne();

        Console.WriteLine("Etudiant : " + Nom + " _____ Moyenne :" + Moy);
    }

}


class Program
{
    static void Main()
    {
    
    Etudiant Et1 = new Etudiant("Ahmed " , 13, 14);
    Et1.Afficher();
    
    Etudiant Et2 = new Etudiant("Koathar" , 10, 14);
    Et2.Afficher();
    }
}
