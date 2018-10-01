using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JollyPirateBoatClub
{
public class MenuView
{
    /// <summary>
    /// a view that manages the selection of actions
    /// </summary>
    /// <returns></returns>
    public int PrintMenu()
    {
        Console.WriteLine("**** Menu ****");
        Console.WriteLine("Select item:");
        Console.WriteLine(" 0. To Exit");
        Console.WriteLine(" 1. Print Compact member list");
        Console.WriteLine(" 2. Print Verbose member list");
        Console.WriteLine(" 3. Create member");
        Console.WriteLine(" 4. Update member");
        Console.WriteLine(" 5. Delete member");
        Console.WriteLine(" 6. View member");
        Console.WriteLine(" 7. Create boat");
        Console.WriteLine(" 8. Update boat");
        Console.WriteLine(" 9. Delete boat");
        Console.WriteLine("10. View boat");
        string userInput = Console.ReadLine();
        int menuItem = 0;
        while(!Int32.TryParse(userInput, out menuItem)){
            Console.WriteLine("Please enter a valid number");
            userInput = Console.ReadLine();
        }
        return menuItem;
    }
    // manages printing messages deriving from other classes
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
    // asks the user for a name when creating new member
    public string AskForName()
    {
        Console.WriteLine("Please enter your name"); 
        return Console.ReadLine();
    }
    // asks the user for a personalnumber when creating new member
    public string PersonalNumer()
    {
        Console.WriteLine("Please enter your personal number yymmdd-xxxx");
        return Console.ReadLine();
    }
    // asks the user for a boattype when creating a new boat
    public string AskForBoatType()
    {
        Console.WriteLine("Please enter your boat type");
        return Console.ReadLine();
    }
    // asks the user for a boat length when creating a new boat and checks if it is an int
    public int AskForBoatLength()
    {
        Console.WriteLine("Please enter boat length in meter");
        string item = Console.ReadLine();
        int length = 0;
        while (!Int32.TryParse(item, out length))
        {
            Console.WriteLine("Please enter a valid number");
            item = Console.ReadLine();
        }
        return length;
    }
}
}