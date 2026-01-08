using System;

class Animal
{
    // Methode virtual
    public virtual void Crier()
    {
        Console.WriteLine("un animal fait de bruit");
    }

}

class Chien : Animal
{
  public override void Crier()
    {
        Console.WriteLine("un chien abois!");
    } 
}

class Chat : Animal
{
    public override void Crier()
    {
        Console.WriteLine("un chat miaule");
    }
}

class Program
{
    static void Main()
    {
        Animal chat = new Chat();
        Animal chien = new Chien();
        Animal [] Animaux = {chien, chat};
        for(int i = 0; i <= Animaux.Length; i++)
        {
            Animaux[i].Crier();
        }
    }
}
