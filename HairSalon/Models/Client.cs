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
    }
}
