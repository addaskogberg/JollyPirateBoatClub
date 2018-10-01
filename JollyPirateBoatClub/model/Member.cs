using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JollyPirateBoatClub
{
    public class Member
    {
        /// <summary>
        /// This class manages the member and the boats of a member
        /// </summary>
        public List<Boat> boats;
        // constructor for member
        public Member(string name, string personalNumber, int memberID)
        {
            Name = name;
            PersonalNumber = personalNumber;
            MemberID = memberID;
            NumberOfBoats = 0;
            boats = new List<Boat>();
        }
        // getter and setters for the member
        public String Name { get; set; }

        public int MemberID { get; set; }

        public int NumberOfBoats { get; set; }

        public String PersonalNumber { get; set; }

        public Boat CurrentBoat { get; set; }

        public List<Boat> Boats { get; set; }

        public void AddTestBoat(int length, int boatID, BoatType type)
        {
            boats.Add(new Boat(length, boatID, type));
            NumberOfBoats++;
        }

        //method to crate the member boat checks the enum to get a correct boat and initiates length
        public Boolean CreateBoat(MenuView menuView, int boatID)
        {
            string boatType = menuView.AskForBoatType();
            BoatType type;
            while (!Enum.TryParse(boatType, out type))
            {
                menuView.PrintMessage("invalid boat type, use one of following: Sailboat, Motorsailer, KajakCanoe, Other");
                boatType = menuView.AskForBoatType();
            }
            int length = menuView.AskForBoatLength();
            Boat boat = new Boat(length, boatID, type);
            NumberOfBoats++;
            CurrentBoat = boat;
            boats.Add(boat);
            return true;
        }

        // updates the member boat
        public void UpdateBoat(MenuView menuView)
        {
            menuView.PrintMessage("Give your boat a new length (currently: " + CurrentBoat.Length + ")");
            string item = Console.ReadLine();
            int length = 0;
            while (!Int32.TryParse(item, out length))
            {
                menuView.PrintMessage("Please enter a valid number");
                item = Console.ReadLine();
            }
            CurrentBoat.Length = length;
            menuView.PrintMessage("The new length of boat is: " + CurrentBoat.Length);
        }

        // checks if member has boats
        public void ReadBoat(MenuView menuView)
        {
            if (NumberOfBoats == 0)
            {
                menuView.PrintMessage("No boats found");
            }
            else
            {
                menuView.PrintMessage(CurrentBoat.ToString());
            }

        }

        // Deletes a members boat
        public void DeleteBoat(MenuView menuView)
        {
            if (NumberOfBoats > 0)
            {
                int boat = CurrentBoat.BoatId;
                boats.Remove(CurrentBoat);
                NumberOfBoats--;
                if (NumberOfBoats > 0)
                {
                    CurrentBoat = boats.First();
                }
                else
                {
                    CurrentBoat = null;
                }
                menuView.PrintMessage("Boat " + boat + " deleted.");
            }
            else
            {
                menuView.PrintMessage("No boats left to delete");
            }
        }

        public string ToCompactString()
        {
            return Name + ", " + MemberID + ", " + NumberOfBoats;
        }

        public string ToVerboseString()
        {
            return Name + ", " + PersonalNumber + ", " + MemberID;
        }

        public override string ToString()
        {
            return Name + ", " + PersonalNumber + ", MemberID: " + MemberID + ", NumberOfBOats: " + NumberOfBoats;
        }
    }
}