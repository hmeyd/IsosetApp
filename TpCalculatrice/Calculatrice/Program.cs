using System;
class Program
{
    static void Main(string[] args)
    {
        // switch = an effeceiennt alternative to many else if statements
        Console.WriteLine("what day is to day?");
        string day = Console.ReadLine();
        switch (day)
        {
            case "Monday":
                Console.WriteLine("it is Monday");
                break;
            case "Tuesday":
                Console.WriteLine("it is Tuesday");
                break;
            case "Wenesday":
                Console.WriteLine("it is Wenesday");
                break;
            case "Thursday":
            Console.WriteLine("it is Thursday");
                break;
            default:
                Console.WriteLine(day + " is not a day");
             break;
        }
    }
}
 