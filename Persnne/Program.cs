using System;

class Personne
{
    // attribues et properieté.
    string Nom;
    int Age;


    // constructeur
    public Personne(string nom, int age)
    {
        Nom = nom;
        Age = age;
    }

    // Methode 

    public void SePerenter()
    {
        Console.WriteLine("je m'appel " + Nom + " j'ai " + Age + " ans.");
    }
}

class Program
{
    static void Main()
    {
    Personne personne1 = new Personne("Ahmed", 25);
    personne1.SePerenter();

    Personne personne2 = new Personne("Jack", 30);
    personne2.SePerenter();
    }
}
