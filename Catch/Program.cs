class Program
{
    public void Execp()
    {
        Console.WriteLine("saisie un nombre");
        int nombre = int.Parse(Console.ReadLine());

        try
        {
            if(nombre == 0)
            {
                throw new DivideByZeroException("le noùbre que vous avez saisie est zero"); 
            }
            else
            Console.WriteLine("le resultat de la dicision est 10 / nobre" + 10 / nombre);
        }
        catch(FormatException)
        {
            Console.WriteLine("le nombre saisie n'est pa sun entier");
        }
        catch(DivideByZeroException ex)
        {
            Console.WriteLine("Exception :" + ex.Message);
        }
        finally
        {
            Console.WriteLine("le cod ea été bien executé");
        }
    }
}
