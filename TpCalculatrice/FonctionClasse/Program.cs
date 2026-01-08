using System;

class Program
{
    static int AddtionAhmed()
    {
        Console.WriteLine("saisie le 1 er nombre");
        int nb1 = int.Parse(Console.ReadLine());
        Console.WriteLine("saisie le 1 er nombre");
        int nb2 = int.Parse(Console.ReadLine());
        return nb1 + nb2;
    }

    static int AddtionAhmed(int nb1, int nb2)
    {
        return nb1 + nb2;
    }


    static void Main()
    {
        int n = AddtionAhmed();
        int m = AddtionAhmed(5, 6);
        Console.WriteLine(n);
        Console.WriteLine(m);
    }
}
