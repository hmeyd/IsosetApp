using System;
class Vehicule
{
    public virtual void Demarer()
    {
        Console.WriteLine("une voiture demare");
    }
}

class Moto : Vehicule
{
    public override void Demarer()
    {
        Console.WriteLine("une moto Vrrrrrr");
    }
}

class Program
{
    public void Main()
    {
    Vehicule M = new Moto();
    M.Demarer();
    }
}