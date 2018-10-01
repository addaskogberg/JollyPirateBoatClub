using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JollyPirateBoatClub
{
    /// <summary>
    /// a class containing the consturctor, getters and setters for a boat.
    /// returns the boat
    /// </summary>
    public class Boat
    {
        private BoatType boatType;
        private int length;
        private int boatID = 1;


        public Boat(int length, int boatID, BoatType boatType)
        {
            Length = length;
            BoatId = boatID;
            BoatType = boatType;
        }

        public BoatType BoatType
        {
            get => boatType;
            set => boatType = value;
        }

        public int Length
        {
            get => length;
            set => length = value;
        }

        public int BoatId
        {
            get => boatID;
            set => boatID = value;
        }

        #region testMethods
        /*  public override string ToString()
          {
              return BoatType + ", Length: " + Length + ", BoatID: " + BoatId ;
          }
     */
        #endregion

        public string ToFileString()
        {
            return BoatType + ", " + Length + ", " + BoatId;
        }
    }
}