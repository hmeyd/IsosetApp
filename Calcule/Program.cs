using System;

interface ICalcul
{
    public int  Calculer(int a, int b);
}

class Addition : ICalcul
{
    public int Calculer(int a, int b)
    {
        return a +b;
    }
}
class Multiplication : ICalcul
{
    public int Calculer(int a, int b)
    {
        return a * b;
    }
}

class Program
{
    static void Main()
    {
        ICalcul op1 = new Addition();
        ICalcul Op2 = new Multiplication();

        Console.WriteLine("Addition :" + op1.Calculer(5, 2));
        Console.WriteLine("Multiplication" + Op2.Calculer(3, 7));
    }
}



