public class CompteBancaire
{
    public String numero;
    public double solde;
    public Depot(double montant)
    {
        solde += montant;
        console.writeline("Dépot de " + montant + "effectué. Nouveau solde " + solde);
    }
    public Retait(double montant)
    {
        solde = -montant;
        console.writeline("retrait de " + montant + "est effectué" + "Nouveau solde " + solde);
    }
}


public class CompteEpargne : CompteBancaire
{
    public double tauxinteresse;
    public void CalculerInteret()
    {
        double interet = solde * tauxinteresse / 100;
        solde += interet;
        console.writeline("Intérêt de " + interet + "ajouté. Nouveau solde " + solde);
    }
}