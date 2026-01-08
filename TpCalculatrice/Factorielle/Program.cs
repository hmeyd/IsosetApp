using System;

class Program
{
    static int Factorielle(int n)
    {
        if(n == 1)
            return 1;
        else
            return n * Factorielle(n - 1);
    }



    static void Main()
    {   int n;
        n = Program.Factorielle(5);
        Console.WriteLine(n);
    }
}