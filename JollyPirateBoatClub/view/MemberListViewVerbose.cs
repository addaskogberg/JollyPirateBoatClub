using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JollyPirateBoatClub
{
public class MemberListViewVerbose
{
    /// <summary>
    ///  a view that manages the printing of the Vervobose list
    /// </summary>
    /// <param name="theList"></param>
    public void PrintVerboseList(List<Member> theList)
    {
        Console.WriteLine("Name, Personalnumber, Member ID");
        foreach (Member member in theList)
        {
            Console.WriteLine(member.ToVerboseString());
            if (member.NumberOfBoats > 0)
            {
                Console.WriteLine("   Boat type, No of Boats, Boat Id");
                foreach (Boat boat in member.boats)
                {
                    Console.WriteLine("   " + boat.ToFileString());
                }
            }
            else
            {
                Console.WriteLine("   This member has no boats");
            }
        }
    }
}
}