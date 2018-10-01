using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JollyPirateBoatClub
{
public class MemberListViewCompact
{
    /// <summary>
    ///  a view that manages the printing of the compact list
    /// </summary>
    /// <param name="theList"></param>
    public void PrintCompactList(List<Member> theList)
    {
        Console.WriteLine("Name, Member ID, No of Boats");
        foreach (Member member in theList)
        {
            Console.WriteLine(member.ToCompactString());
        }
    }

}
}