using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Bandtracker
{
    public class Band
    {
        private int _id;
        private string _name;

        public Band(string name, int id = 0)
        {
            _name = name;
            _id = id;
        }

        public override bool Equals(System.Object otherBand)
        {
            if(!(otherBand is Band))
            {
                return false;
            }
            else
            {
                Band newBand = (Band) otherBand;
                bool idEquality = this.GetId() == newBand.GetId();
                bool nameEquality = this.GetName() == newBand.GetName();
                return (idEquality && nameEquality);
            }
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO bands (name) OUTPUT INSERTED.id VALUES (@Name);", conn);

            cmd.Parameters.Add(new SqlParameter("@Name", this.GetName()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            DB.CloseSqlConnection(rdr, conn);
        }

        public static Band FindBand(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM bands WHERE id = @BandsId;", conn);

            cmd.Parameters.Add(new SqlParameter("@BandsId", id));

            SqlDataReader rdr = cmd.ExecuteReader();

            int bandId = 0;
            string bandName = null;

            while(rdr.Read())
            {
                bandId = rdr.GetInt32(0);
                bandName = rdr.GetString(1);
            }

            Band foundBand = new Band(bandName, bandId);

            DB.CloseSqlConnection(rdr, conn);

            return foundBand;
        }

        public void UpdateBand(string newName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE bands SET name = @Name WHERE id = @BandId", conn);

            cmd.Parameters.Add(new SqlParameter("@Name", newName));
            cmd.Parameters.Add(new SqlParameter("@BandId", this.GetId()));

            cmd.ExecuteNonQuery();

            if(conn != null)
            {
                conn.Close();
            }
        }

        public void DeleteBand()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM bands WHERE id = @BandId; DELETE FROM bands_venues WHERE bands_id = @BandId;", conn);

            cmd.Parameters.Add(new SqlParameter("@BandId", this.GetId()));

            cmd.ExecuteNonQuery();

            if(conn != null)
            {
                conn.Close();
            }

        }

        public static List<Band> GetAll()
        {
            List<Band> allBands = new List<Band> {};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM bands", conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int bandId = rdr.GetInt32(0);
                string bandName = rdr.GetString(1);
                Band newBand = new Band(bandName, bandId);
                allBands.Add(newBand);
            }

            DB.CloseSqlConnection(rdr, conn);

            return allBands;
        }

        public List<Venue> GetVenues()
        {
            List<Venue> allVenues = new List<Venue>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT venues.* FROM bands JOIN bands_venues ON (bands.id = bands_venues.bands_id) JOIN venues ON (bands_venues.venues_id = venues.id) WHERE bands_id = @BandsId;", conn);

            cmd.Parameters.Add(new SqlParameter("@BandsId", this.GetId()));

            SqlDataReader rdr = cmd.ExecuteReader();

            int venueId = 0;
            string venueName = null;

            while(rdr.Read())
            {
                venueId = rdr.GetInt32(0);
                venueName = rdr.GetString(1);
                Venue newVenue = new Venue(venueName, venueId);
                allVenues.Add(newVenue);
            }

            DB.CloseSqlConnection(rdr, conn);

            return allVenues;
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
            DB.TableDeleteAll("bands");
        }
    }
}
