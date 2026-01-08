using System;

class SommeTP
{
    public int Somme(int n)
    {
        if (n == 1)
            return 1;
        else
            return n + Somme(n -1);
    }


    static void Main()
    {
        SommeTP Obj = new SommeTP();
        int fac = Obj.Somme(4);
        Console.WriteLine(fac);
    }
}
