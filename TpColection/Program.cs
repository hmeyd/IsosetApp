using System;

class Tableau
{
    public void Tab()
    {
        int [] nombres = new int[5];
        for (int i = 0; i <= 5; i++)
        {   
            Console.WriteLine("saisie un nombre");
           int nombre = int.Parse(Console.ReadLine()); 
            nombres[i] = nombre; 
        }

    }
}


class Liste()
{
    public static void ListeT()
    {
        List <string> T = new List <string>();
        for (int i = 0; i <= 3; i++)
        {
            Console.WriteLine("saisie un nom");
            string nom = Console.ReadLine();
            T[i] = nom;
        }
        Console.WriteLine(T);

        Console.WriteLine("saisie le nom que tu veux suprimer");
        string nom = Console.ReadLine();
       for (int i = 0; i <= 3; i++)
        {
            if(nom == T[i])
            {
            T[i] = nom;
            
        } 
    }
}



class Program
{

    static void  Main()
    {
        Tableau T1 = new Tableau();
        T1.Tab();
    }
}