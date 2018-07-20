using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Service
    {
      public int Id { get; set; }
      public string Name { get; set; }

      public Service(string name, int id=0)
      {
          Name = name;
          Id = id;
      }

      public override bool Equals(System.Object otherService)
      {
          if (!(otherService is Service))
          {
              return false;
          }
          else
          {
              Service newService = (Service) otherService;
              bool isEqual = (this.Name == newService.Name);
              return (isEqual);
          }
      }

      public void SaveService()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO services (name) VALUES (@ServiceName);";
        cmd.Parameters.AddWithValue("@ServiceName", this.Name);
        cmd.ExecuteNonQuery();
        Id = (int) cmd.LastInsertedId;
        conn.Close();
        if(conn != null)
        {
            conn.Dispose();
        }
      }

      public static Service FindService(int idToFind)
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM services WHERE id = @IdToFind;";
          cmd.Parameters.AddWithValue("@IdToFind", idToFind);
          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          int id = 0;
          string name = "";
          while (rdr.Read())
          {
              id = rdr.GetInt32(0);
              name = rdr.GetString(1);
          }
          Service searchedService = new Service(name, id);
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return searchedService;
      }

      public void AddStylist(Stylist newStylist)
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO services_stylists (service_id, stylist_id) VALUES (@ServiceId, @StylistId);";
          cmd.Parameters.AddWithValue("@ServiceId", this.Id);
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
          cmd.CommandText = @"SELECT stylists.* FROM services
                            JOIN services_stylists ON (services.id = services_stylists.service_id)
                            JOIN stylists ON (services_stylists.stylist_id = stylists.id) WHERE service_id = @ServiceId";
          cmd.Parameters.AddWithValue("@ServiceId", this.Id);
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

      public static List<Service> GetAllServices()
      {
          List<Service> allServices = new List<Service> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM services;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int id = rdr.GetInt32(0);
            string name = rdr.GetString(1);
            Service newService = new Service(name, id);
            allServices.Add(newService);
          }
          conn.Close();
          if(conn != null)
          {
              conn.Dispose();
          }
          return allServices;
      }
    }
}
