using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Client
    {
      private int _id;
      private string _name;

      public Client(string name)
      {
          _name = name;
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
              bool isEqual = (this.GetName() == newClient.GetName());
              return (isEqual);
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

      public void SaveClient()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO clients (name) VALUES (@ClientName);";
        MySqlParameter clientName = new MySqlParameter();
        clientName.ParameterName = "@ClientName";
        clientName.Value = this._name;
        cmd.Parameters.Add(clientName);
        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;
        conn.Close();
        if(conn != null)
        {
            conn.Dispose();
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
            Client newClient = new Client(name);
            newClient._id = id;
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
          cmd.CommandText = @"SELECT * FROM `clients` WHERE id = @ThisId;";
          MySqlParameter clientId = new MySqlParameter();
          clientId.ParameterName = "@ThisId";
          clientId.Value = idToFind;
          cmd.Parameters.Add(clientId);
          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          int id = 0;
          string name = "";
          while (rdr.Read())
          {
              id = rdr.GetInt32(0);
              name = rdr.GetString(1);
          }
          Client searchedClient = new Client(name);
          searchedClient._id = id;
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
          MySqlParameter client_id = new MySqlParameter();
          client_id.ParameterName = "@ClientId";
          client_id.Value = newStylist.GetId();
          cmd.Parameters.Add(client_id);
          MySqlParameter stylist_id = new MySqlParameter();
          stylist_id.ParameterName = "@StylistId";
          stylist_id.Value = _id;
          cmd.Parameters.Add(stylist_id);
          cmd.ExecuteNonQuery();
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }

      public List<Stylist> GetStylists()
      {
        MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT stylist_id FROM clients_stylists WHERE client_id = @clientId;";

          MySqlParameter clientIdParameter = new MySqlParameter();
          clientIdParameter.ParameterName = "@clientId";
          clientIdParameter.Value = _id;
          cmd.Parameters.Add(clientIdParameter);

          var rdr = cmd.ExecuteReader() as MySqlDataReader;

          List<int> stylistIds = new List<int> {};
          while(rdr.Read())
          {
              int stylistId = rdr.GetInt32(0);
              stylistIds.Add(stylistId);
          }
          rdr.Dispose();

          List<Stylist> stylists = new List<Stylist> {};
          foreach (int stylistId in stylistIds)
          {
              var stylistQuery = conn.CreateCommand() as MySqlCommand;
              stylistQuery.CommandText = @"SELECT * FROM stylists WHERE id = @StylistId;";

              MySqlParameter stylistIdParameter = new MySqlParameter();
              stylistIdParameter.ParameterName = "@StylistId";
              stylistIdParameter.Value = stylistId;
              stylistQuery.Parameters.Add(stylistIdParameter);

              var stylistQueryRdr = stylistQuery.ExecuteReader() as MySqlDataReader;
              while(stylistQueryRdr.Read())
              {
                  int thisStylistId = stylistQueryRdr.GetInt32(0);
                  string stylistName = stylistQueryRdr.GetString(1);
                  Stylist foundStylist = new Stylist(stylistName);
                  stylists.Add(foundStylist);
              }
              stylistQueryRdr.Dispose();
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return stylists;
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
