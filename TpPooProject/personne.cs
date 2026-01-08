
namespace TpPoo;
// classe personne
class Personne
{
    private double poids;
    private double taille;

    public double Poids
    {
        get { return poids; }
        set
        {
         if (value > 0)       // contrôle ici !
            poids = value;
         else
            throw new Exception("Le poids doit être supérieur à 0.");
         }
    }

    public double Taille
    {
        get { return taille; }
        set
        {
            if (value > 0)       // contrôle ici aussi !
                taille = value;
            else
                throw new Exception("La taille doit être supérieure à 0.");
        }
    }




    public  Personne(double poids, double taille)
    {
        Poids = poids;
        Taille = taille;
    }

    public double CalculerIMC()
    {
        double IMC = Poids / Math.Pow(Taille, 2);
        return IMC;
    }
}
