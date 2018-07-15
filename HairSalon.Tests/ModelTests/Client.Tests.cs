using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTest : IDisposable
    {
        public void Dispose()
        {
            Client.DeleteAll();
        }

        public ClientTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root; password=root; port=8889;database=kelli_mccloskey_test;";
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamessAreTheSame_Client()
        {
            Client firstClient = new Client("Stacy", 2);
            Client secondClient = new Client("Stacy", 2);
            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void SaveClient_SavesToDatabase_ClientList()
        {
            Client testClient = new Client("Elliot", 1);
            testClient.SaveClient();
            List<Client> actual = Client.GetAllClients();
            List<Client> expected = new List<Client> {testClient};
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllClients_DBStartsEmpty_0()
        {
            int actual = Client.GetAllClients().Count;
            Assert.AreEqual(0, actual);
        }
    }
}
