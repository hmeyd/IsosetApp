using System;
class Program
{
    public int Compteur(int n)
    {
        if (n > 1)
        {
            Console.WriteLine(n);
            return Compteur(n - 1);
        }
    return 0;
    }
}


class Test
{
    static void Main()
    {
      Program Comp1 = new();
      Comp1.Compteur(5);  
    }
}

