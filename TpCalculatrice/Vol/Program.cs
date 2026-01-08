interface Ivoler
{
    public void voler();
}

class Oiseau : Ivoler
{
    public void voler()
    {
        Console.WriteLine("l'Oiseau vole");
    }
}

class Avion : Ivoler
{
    public void voler()
    {
        Console.WriteLine("l'avion voile");
    }
}

class Program
{
    public void Main()
    {
       Ivoler V;
       V = new Avion();
       V.voler();

       V = new Oiseau();
       V.voler();
    }
}
