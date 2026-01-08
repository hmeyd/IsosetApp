

using TpPoo;
class Program
{
    static void Main()
    {
        Console.WriteLine("entrer le poids :");
        double poids = double.Parse(Console.ReadLine());
        Console.WriteLine("entrer la taille :");
        double taille = double.Parse(Console.ReadLine());

        Personne P1 = new(poids, taille);
        double imc = P1.CalculerIMC();
        double imcArrondi = Math.Round(imc, 2);

        ImcService IMC = new();

        Console.WriteLine("Le poids : " + poids + " KG.");
        Console.WriteLine("La taille : " + taille + " m.");

        Console.WriteLine("La IMC : " + imcArrondi);
        Console.WriteLine("L'interpretation : ");
        IMC.InterpreterImc(imc);
    }
}

