using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JollyPirateBoatClub
{
    /// <summary>
    /// Manages saving and reading from file.
    /// returns the list of members and boats
    /// </summary>
    public class FileManager
    {
        private const string path = @"members.txt";

        public void SaveToFile(List<Member> theList)
        {
            if (!File.Exists(path))
            {
                var myFile = File.Create(path);
                myFile.Close();
            }
            string output = "";
            foreach (Member member in theList)
            {
                output += member.ToVerboseString() + "\r\n";
                if (member.NumberOfBoats > 0)
                {
                    foreach (Boat boat in member.boats)
                    {
                        output += "   " + boat.ToFileString() + "\r\n";
                    }
                }
            }
            File.WriteAllText(path, output);
        }

        public List<Member> ReadFromFile()
        {
            List<Member> myList = new List<Member>();
            if (File.Exists(path))
            {
                Member thisMember = new Member(" member", " ", 0);
                int memberIndex = -1;
                foreach (string line in File.ReadLines(path))
                {
                    if (line.StartsWith(" "))
                    {
                        string[] boat = line.Split(',');
                        boat[0] = boat[0].Substring(3);
                        boat[1] = boat[1].Substring(1);
                        boat[2] = boat[2].Substring(1);
                        BoatType type = BoatType.KajakCanoe;
                        Enum.TryParse(boat[0], out type);
                        myList[memberIndex].boats.Add(new Boat(Int32.Parse(boat[1]), Int32.Parse(boat[2]), type));
                        myList[memberIndex].NumberOfBoats++;

                    }
                    else
                    {
                        string[] member = line.Split(',');
                        member[1] = member[1].Substring(1);
                        member[2] = member[2].Substring(1);
                        thisMember = new Member(member[0], member[1], Int32.Parse(member[2]));
                        myList.Add(thisMember);
                        memberIndex++;

                    }

                }
            }
            return myList;
        }

    }
}