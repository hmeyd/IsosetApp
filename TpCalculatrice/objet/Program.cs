using System;


class Personne
{
    // La liste des Attribues
    public string Nom;
    public int Age;
    // Le constructeur
    public Personne(string nom, int age)
    {
        Nom = nom;
        Age = age;
    }
    public void sePresenter()
    {
        Console.WriteLine("Bonjour je m'appel " + Nom + "j'ai " + Age + " ans.");
    }
}

class Program
{
    static void Main()
    {
    Personne p1 = new Personne("Ahmed", 25);
    p1.sePresenter();

    Personne personne1 = new Personne("Alice", 25);

        // Appel d'une méthode de l'objet
    personne1.sePresenter();
    }
}