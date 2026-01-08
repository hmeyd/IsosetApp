
namespace TpCompteBancaire;

class CompteBancaire
{
    private string numeroCompte;
    private string titulaire;
    private double solde;

    public double Solde
        {
            get { return solde; }
            set
            {
            if (value > 0)
                solde = value;
            else
                throw new Exception("Le solde doit être supérieur à 0.");
            }
        }
    public CompteBancaire(string NumeroCompte, string Titulaire, double Solde)
    {
        numeroCompte = NumeroCompte;
        titulaire = Titulaire;
        solde = Solde;
    }

    public double deposer(double montant)
    {
        solde += montant;
        return solde;
    }

    public double retirer(double montant)
    {
        solde -= montant;
        return solde;
    } 


    public void afficherSolde(string numeroCompte, string titulaire, double solde)
    {

        
        Console.WriteLine("Numero de compte : " + numeroCompte);
        Console.WriteLine("le titulaire : " + titulaire);
        Console.WriteLine("votre solde est :\n " + solde);
    }
    

}