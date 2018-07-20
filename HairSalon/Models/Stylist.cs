using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Stylist(string name, int id=0)
        {
            Name = name;
            Id = id;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool isEqual = (this.Name == newStylist.Name);
                return (isEqual);
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public void SaveStylist()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@StylistName);";
            cmd.Parameters.AddWithValue("@StylistName", this.Name);
            cmd.ExecuteNonQuery();
            Id = (int) cmd.LastInsertedId;
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }

        public void AddClient(Client newClient)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO clients_stylists (client_id, stylist_id) VALUES (@ClientId, @StylistId)";
          cmd.Parameters.AddWithValue("@ClientId", newClient.Id);
          cmd.Parameters.AddWithValue("@StylistId", this.Id);
          cmd.ExecuteNonQuery();
          conn.Close();
          if(conn != null)
          {
              conn.Dispose();
          }
        }

        public void AddService(Service newService)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO services_stylists (service_id, stylist_id) VALUES (@ServiceId, @StylistId)";
          cmd.Parameters.AddWithValue("@ServiceId", newService.Id);
          cmd.Parameters.AddWithValue("@StylistId", this.Id);
          cmd.ExecuteNonQuery();
          conn.Close();
          if(conn != null)
          {
              conn.Dispose();
          }
        }

        public void EditStylist(string newName)
                {
                    MySqlConnection conn = DB.Connection();
                    conn.Open();

                    var cmd = conn.CreateCommand() as MySqlCommand;
                    cmd.CommandText = @"UPDATE stylists SET name = @Name WHERE id = @searchId;";


                    cmd.Parameters.AddWithValue("@Name", newName);
                    cmd.Parameters.AddWithValue("@searchId", this.Id);

                    cmd.ExecuteNonQuery();
                    this.Name = newName;

                    conn.Close();
                    if (conn != null)
                    {
                        conn.Dispose();
                    }
                }
        public void DeleteStylist()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists WHERE id = @StylistId; DELETE FROM services_stylists WHERE stylist_id = @StylistId; DELETE FROM clients_stylists WHERE stylist_id = @StylistId";

            cmd.Parameters.AddWithValue("@StylistId", this.Id);

            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static Stylist FindStylist(int idToFind)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = @IdToFind;";
            cmd.Parameters.AddWithValue("@IdToFind", idToFind);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id = 0;
            string name = "";
            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
                name = rdr.GetString(1);
            }
            Stylist searchedStylist = new Stylist(name, id);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return searchedStylist;
        }

        public static List<Stylist> GetAllStylists()
        {
            List<Stylist> allStylists = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int id = rdr.GetInt32(0);
              string name = rdr.GetString(1);
              Stylist newStylist = new Stylist(name, id);
              allStylists.Add(newStylist);
            }
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public List<Client> GetClientList()
        {
            List<Client> clientList = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT clients.* FROM stylists
                              JOIN clients_stylists ON (stylists.id = clients_stylists.stylist_id)
                              JOIN clients ON (clients_stylists.client_id = clients.id) WHERE stylist_id = @StylistId;";
            cmd.Parameters.AddWithValue("@StylistId", this.Id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Client newClient = new Client(name, id);
                clientList.Add(newClient);
            }
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return clientList;
        }

        public List<Service> GetServiceList()
        {
            List<Service> serviceList = new List<Service> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT services.* FROM stylists
                              JOIN services_stylists ON (stylists.id = services_stylists.stylist_id)
                              JOIN services ON (services_stylists.service_id = services.id) WHERE stylist_id = @StylistId;";
            cmd.Parameters.AddWithValue("@StylistId", this.Id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Service newService = new Service(name, id);
                serviceList.Add(newService);
            }
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return serviceList;
        }

        public List<Client> GetAllClients()
        {
            return Client.GetAllClients();
        }

        public List<Service> GetAllServices()
        {
            return Service.GetAllServices();
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
