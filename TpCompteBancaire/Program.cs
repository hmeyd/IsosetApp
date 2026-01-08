namespace TpCompteBancaire;

class Program
{
    static void Main()
    {
        Console.WriteLine("saisie le Numero de compte");
        string numeroCompte = Console.ReadLine();
        Console.WriteLine("saisie le Nom de titulaire de compte");
        string titulaire = Console.ReadLine();
        Console.WriteLine("saisie le Solde initiale");
        double solde = double.Parse(Console.ReadLine());
        CompteBancaire compte1 = new(numeroCompte, titulaire, solde);
        string reponse = "oui";
        while (reponse == "oui")
        {
        Console.WriteLine("1- Deposer \n2- Retirer");
        string decision = Console.ReadLine();
        
        
            if (decision == "Deposer")
            {   
                Console.WriteLine("Quelle est le montant à deposer");
                double montant = double.Parse(Console.ReadLine());
                solde = compte1.deposer(montant);
            }
            else if(decision == "Retirer")
            {
                Console.WriteLine("Quelle est le montant à retirer");
                double montant = double.Parse(Console.ReadLine());
                solde = compte1.retirer(montant);
               if(solde < 0)
                {
                solde = solde + montant;
                Console.WriteLine("l'opperation n'a pas pu aboutir");
                }
        }
            compte1.afficherSolde(numeroCompte, titulaire, solde);
            Console.WriteLine("voulez-vous continuer oui ou non");
            reponse = Console.ReadLine();
        }
    }
}