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
