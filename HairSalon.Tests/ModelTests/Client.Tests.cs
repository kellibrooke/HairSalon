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
            Stylist.DeleteAll();
        }

        public ClientTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root; password=root; port=8889;database=kelli_mccloskey_test;";
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamessAreTheSame_Client()
        {
            Client firstClient = new Client("Stacy");
            Client secondClient = new Client("Stacy");
            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void SaveClient_SavesToDatabase_ClientList()
        {
            Client testClient = new Client("Elliot");
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

        [TestMethod]
        public void FindClient_FindsClientInDB_Client()
        {
            Client testClient = new Client("Jennifer");
            testClient.SaveClient();
            Client foundClient = Client.FindClient(testClient.Id);
            Assert.AreEqual(testClient, foundClient);
        }

        [TestMethod]
        public void AddStylist_AddsStylistToClient_StylistList()
        {
            Client testClient = new Client("Jenny");
            testClient.SaveClient();
            Stylist testStylist = new Stylist("Stacy");
            testStylist.SaveStylist();
            testClient.AddStylist(testStylist);
            List<Stylist> actual = testClient.GetStylistList();
            List<Stylist> expected = new List<Stylist> {testStylist};
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetStylistList_ReturnsAllClientStylists_StylistList()
        {
            Client testClient = new Client("John");
            testClient.SaveClient();
            Stylist testStylist1 = new Stylist("Stacy");
            testStylist1.SaveStylist();
            testClient.AddStylist(testStylist1);
            List<Stylist> actual = testClient.GetStylistList();
            List<Stylist> expected = new List<Stylist> {testStylist1};
            CollectionAssert.AreEqual(expected, actual);
        }


    }
}
