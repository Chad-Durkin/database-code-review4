using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Bandtracker
{
    public class Venue
    {
        private int _id;
        private string _name;

        public Venue(string name, int id = 0)
        {
            _name = name;
            _id = id;
        }

        public override bool Equals(System.Object otherVenue)
        {
            if(!(otherVenue is Venue))
            {
                return false;
            }
            else
            {
                Venue newVenue = (Venue) otherVenue;
                bool idEquality = this.GetId() == newVenue.GetId();
                bool nameEquality = this.GetName() == newVenue.GetName();
                return (idEquality && nameEquality);
            }
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public static void DeleteAll()
        {
            DB.TableDeleteAll("venue")
        }
    }
}
