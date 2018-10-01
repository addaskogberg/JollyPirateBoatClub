using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JollyPirateBoatClub
{
    public class MemberManager
    {
        private List<Member> memberList;
        private Member currentMember;
        private MemberListViewCompact memberListViewCompact;
        private MemberListViewVerbose memberListViewVerbose;
        private MenuView menuView;
        private int memberID = 1;
        private int boatID = 1;
        private FileManager fileManager;

        public MemberManager()
        {
            menuView = new MenuView();
            memberList = new List<Member>();
            memberListViewCompact = new MemberListViewCompact();
            memberListViewVerbose = new MemberListViewVerbose();
            fileManager = new FileManager();

            List<Member> members = fileManager.ReadFromFile();
            memberList = members;
            if(memberList.Count > 0)
            {
                currentMember = memberList.First();
            }

        }

        #region testMethods
        private void AddTestMembers()
        {
            // Adding default members
            memberList.Add(new Member("Adda", "710702-1234", memberID));
            memberID++;
            memberList.Add(new Member("Benny", "680429-1234", memberID));
            memberID++;
            memberList.Add(new Member("Alexandra", "030114-1234", memberID));
            memberID++;
            memberList.Add(new Member("Hanna", "050621-1234", memberID));
            memberID++;
            currentMember = memberList[3];

            memberList[0].AddTestBoat(12, boatID, BoatType.KajakCanoe);
            boatID++;
            memberList[0].AddTestBoat(15, boatID, BoatType.Motorsailer);
            boatID++;
            memberList[0].AddTestBoat(5, boatID, BoatType.Other);
            boatID++;
            memberList[0].AddTestBoat(100, boatID, BoatType.Sailboat);
            boatID++;
            memberList[0].CurrentBoat = memberList[0].boats[3];

            memberList[1].AddTestBoat(20, boatID, BoatType.KajakCanoe);
            boatID++;
            memberList[1].CurrentBoat = memberList[1].boats[0];

            memberList[2].AddTestBoat(18, boatID, BoatType.Sailboat);
            boatID++;
            memberList[2].AddTestBoat(29, boatID, BoatType.Other);
            boatID++;
            memberList[2].CurrentBoat = memberList[2].boats[1];
        }
        #endregion

        internal void PrintMenu()
        {
            int menuItem = menuView.PrintMenu();
            if(menuItem == 1) // compact list
            {
                Console.WriteLine("returned value " + menuItem);
                memberListViewCompact.PrintCompactList(memberList);
            }
            else if (menuItem == 2) // verbose list
            {
                Console.WriteLine("returned value " + menuItem);
                memberListViewVerbose.PrintVerboseList(memberList);
            }
            else if (menuItem == 3) // Create member
            {
                Console.WriteLine("returned value " + menuItem);
                CreateMember();
                Console.WriteLine(memberList.First().Name);
                //memberList.First().CreateBoat(menuView);
            }
            else if (menuItem == 4) // Update member
            {
                Console.WriteLine("returned value " + menuItem);
                UpdateMember();
            }
            else if (menuItem == 5) // Delete member
            {
                Console.WriteLine("returned value " + menuItem);
                DeleteMember();
            }
            else if (menuItem == 6) // View member
            {
                Console.WriteLine("returned value " + menuItem);
                ReadMember();
            }
            else if (menuItem == 7) // Create boat
            {
                Console.WriteLine("returned value " + menuItem);
                CreateBoat();
            }
            else if (menuItem == 8) // Update boat
            {
                Console.WriteLine("returned value " + menuItem);
                UpdateBoat();
            }
            else if (menuItem == 9) // Delete boat
            {
                Console.WriteLine("returned value " + menuItem);
                DeleteBoat();
            }
            else if (menuItem == 10) // View boat
            {
                Console.WriteLine("returned value " + menuItem);
                ReadBoat();
            }
            else
            {
                fileManager.SaveToFile(memberList);
                System.Environment.Exit(1);
            }
            Console.WriteLine();
            PrintMenu();
        }

        public void CreateMember()
        {
            string name = menuView.AskForName();
            string pNumber = menuView.PersonalNumer();
            Member member = new Member(name, pNumber, memberID);
            currentMember = member;
            memberList.Add(member);
            memberID++;
        }

        public void ReadMember()
        {
            try
            {
                Console.WriteLine(currentMember.ToString());
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Please create member first");
            }
        }

        public void UpdateMember()
        {
            menuView.PrintMessage("Give your member " + currentMember.Name + " a new name:");
            currentMember.Name = Console.ReadLine();
            menuView.PrintMessage("The new name of member is: " + currentMember.Name);
        }

        public void DeleteMember()
        {
            if(memberList.Count > 0)
            {
                string name = currentMember.Name;
                memberList.Remove(currentMember);
                if (memberList.Count > 0)
                {
                    currentMember = memberList.First();
                }
                else
                {
                    currentMember = null;
                }
                menuView.PrintMessage("Member " + name + " deleted.");
            }
            else
            {
                menuView.PrintMessage("No members left to delete");
            }
        }

        private void CreateBoat()
        {
            try
            {
                bool newBoatCreated = currentMember.CreateBoat(menuView, boatID);
                if (newBoatCreated)
                {
                    boatID++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("please create member firts");
            }

        }

        private void ReadBoat()
        {
            try
            {
                currentMember.ReadBoat(menuView);
            }
            catch (NullReferenceException e)
            {
                menuView.PrintMessage("please add a member: ");
            }
        }

        private void UpdateBoat()
        {
            currentMember.UpdateBoat(menuView);
        }

        private void DeleteBoat()
        {
            currentMember.DeleteBoat(menuView);
        }
    }
}