using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Client
    {
      public int Id { get; set; }
      public string Name { get; set; }

      public Client(string name, int id=0)
      {
          Name = name;
          Id = id;
      }

      public override bool Equals(System.Object otherClient)
      {
          if (!(otherClient is Client))
          {
              return false;
          }
          else
          {
              Client newClient = (Client) otherClient;
              bool isEqual = (this.Name == newClient.Name);
              return (isEqual);
          }
      }

      public void SaveClient()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO clients (name) VALUES (@ClientName);";
        cmd.Parameters.AddWithValue("@ClientName", this.Name);
        cmd.ExecuteNonQuery();
        Id = (int) cmd.LastInsertedId;
        conn.Close();
        if(conn != null)
        {
            conn.Dispose();
        }
      }

      public void EditClient(string newName)
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"UPDATE clients SET name = @Name WHERE id = @searchId;";


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

      public void DeleteClient()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"DELETE FROM clients WHERE id = @ClientId; DELETE FROM clients_stylists WHERE client_id = @ClientId;";

          cmd.Parameters.AddWithValue("@ClientId", this.Id);

          cmd.ExecuteNonQuery();
          if (conn != null)
          {
              conn.Close();
          }
      }

      public static List<Client> GetAllClients()
      {
          List<Client> allClients = new List<Client> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM clients;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int id = rdr.GetInt32(0);
            string name = rdr.GetString(1);
            Client newClient = new Client(name, id);
            allClients.Add(newClient);
          }
          conn.Close();
          if(conn != null)
          {
              conn.Dispose();
          }
          return allClients;
      }

      public static Client FindClient(int idToFind)
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM clients WHERE id = @IdToFind;";
          cmd.Parameters.AddWithValue("@IdToFind", idToFind);
          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          int id = 0;
          string name = "";
          while (rdr.Read())
          {
              id = rdr.GetInt32(0);
              name = rdr.GetString(1);
          }
          Client searchedClient = new Client(name, id);
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return searchedClient;
      }

      public void AddStylist(Stylist newStylist)
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO clients_stylists (client_id, stylist_id) VALUES (@ClientId, @StylistId);";
          cmd.Parameters.AddWithValue("@ClientId", this.Id);
          cmd.Parameters.AddWithValue("@StylistId", newStylist.Id);
          cmd.ExecuteNonQuery();
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }

      public List<Stylist> GetStylistList()
      {
        MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT stylists.* FROM clients
                            JOIN clients_stylists ON (clients.id = clients_stylists.client_id)
                            JOIN stylists ON (clients_stylists.stylist_id = stylists.id) WHERE client_id = @ClientId";
          cmd.Parameters.AddWithValue("@ClientId", this.Id);
          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          List<Stylist> allStylists = new List<Stylist> {};
          while(rdr.Read())
          {
              int stylistId = rdr.GetInt32(0);
              string stylistName = rdr.GetString(1);
              Stylist newStylist = new Stylist(stylistName, stylistId);
              allStylists.Add(newStylist);
          }

          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allStylists;
      }

      public List<Stylist> GetAllStylists()
      {
          return Stylist.GetAllStylists();
      }

      public static void DeleteAll()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"DELETE FROM clients;";
          cmd.ExecuteNonQuery();
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }
    }
}
