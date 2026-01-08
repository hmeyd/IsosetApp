
namespace TpPoo;
// IMC service
class ImcService
{
    public void InterpreterImc(double IMC)
    {
     if (IMC < 18.5)
    {
        Console.WriteLine("Maigreur");
    }
    else if (IMC >= 18.5 && IMC < 25)
    {
        Console.WriteLine("Corpulence normale");
    }
    else if (IMC >= 25 && IMC < 30)
    {
        Console.WriteLine("Surpoids");
    }
    else if (IMC >= 30 && IMC < 35)
    {
        Console.WriteLine("Obésité modérée");
    }
    else if (IMC >= 35 && IMC < 40)
    {
        Console.WriteLine("Obésité sévère");
    }
    else
    {
        Console.WriteLine("Obésité morbide");
    }
    }
}
