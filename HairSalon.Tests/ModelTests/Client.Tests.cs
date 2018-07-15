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
            Stylist.DeleteAll();
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
    }
}
