class Program
{
    public void Catch1()
    {
        try
        {
            Console.WriteLine("saisie un entier");
            int nombre = int.Parse(Console.ReadLine());
            Console.WriteLine(nombre);
        }
        catch(FormatException)
        {
            Console.WriteLine("Eurreur, vous devez saisir un entier!");
        }
    }


    public void catch2()
    {
        try
        {
            Console.WriteLine("saisie deux nombre");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if (b == 0)
            {
                throw new DivideByZeroException("impossible de divider pas Zéro");
            }
            else
                Console.WriteLine("a / b" + a/b);

        }
        catch(DivideByZeroException ex)
        {
            Console.WriteLine("Exception " + ex.Message);
        }
        finally
        {
            Console.WriteLine("le code est bien executé");
        }
    }

    public void Catch3()
    {
        try
        {
            Console.WriteLine("saisie un nombre");
            int nombre = int.Parse(Console.ReadLine());
            if (nombre == 0)
            {
                throw new DivideByZeroException("Imossible : division pae Zéro");
            }
            else
                Console.WriteLine(nombre);
        }
        catch(FormatException)
        {
            Console.WriteLine("le nombre n'est pas un entier");
        }
        catch(DivideByZeroException ex)
        {
            Console.WriteLine("Exption : " + ex.Message);
        }
        finally
        {
            Console.WriteLine("le code étais bien executé");
        }

    }

}


class AgeNegatifException : Exception
{
    public AgeNegatifException(string Message) : base(Message)
    {
        
    }
}
class AgeCatch
{
    public void Catch3()
    {
        try
        {
        Console.WriteLine("saisie ton age ");
        int age = int.Parse(Console.ReadLine());
        if (age < 0)
            {
                throw new AgeNegatifException ("Erreur : l'age ne peut pas être négatif");
                
            }
        else
            Console.WriteLine("ton age est : " + age); 
        }
        catch (AgeNegatifException ex)
        {
            Console.WriteLine("Exception :" + ex.Message);

        }
        finally
        {
            Console.WriteLine("le code est bien executé");
        }


    }
}

class Programm
{
    static void Main()
    {
        AgeCatch Age1 = new();
        Age1.Catch3();
    }
}