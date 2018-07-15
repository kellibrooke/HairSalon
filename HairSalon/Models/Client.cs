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
      private int _stylistId;

      public Client(string name, int stylistId)
      {
          _name = name;
          _stylistId = stylistId;
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

      public int GetStylistId()
      {
          return _stylistId;
      }

      public void SaveClient()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@ClientName, @StylistId);";
        MySqlParameter clientName = new MySqlParameter();
        clientName.ParameterName = "@ClientName";
        clientName.Value = this._name;
        cmd.Parameters.Add(clientName);
        MySqlParameter clientStylistId = new MySqlParameter();
        clientStylistId.ParameterName = "@StylistId";
        clientStylistId.Value = this._stylistId;
        cmd.Parameters.Add(clientStylistId);
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
            int stylistId = rdr.GetInt32(2);
            Client newClient = new Client(name, stylistId);
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
          int stylistId = 0;
          while (rdr.Read())
          {
              id = rdr.GetInt32(0);
              name = rdr.GetString(1);
              stylistId = rdr.GetInt32(2);
          }
          Client searchedClient = new Client(name, stylistId);
          searchedClient._id = id;
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return searchedClient;
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
