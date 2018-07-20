using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public StylistTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root; password=root; port=8889;database=kelli_mccloskey_test;";
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfNamessAreTheSame_Stylist()
        {
            Stylist firstStylist = new Stylist("Stacy");
            Stylist secondStylist = new Stylist("Stacy");
            Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void SaveStylist_SavesToDatabase_StylistList()
        {
            Stylist testStylist = new Stylist("Elliot");
            testStylist.SaveStylist();
            List<Stylist> actual = Stylist.GetAllStylists();
            List<Stylist> expected = new List<Stylist> {testStylist};
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllStylists_DBStartsEmpty_0()
        {
            int actual = Stylist.GetAllStylists().Count;
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void FindStylist_FindsStylistInDB_Stylist()
        {
            Stylist testStylist = new Stylist("Jennifer");
            testStylist.SaveStylist();
            Stylist foundStylist = Stylist.FindStylist(testStylist.Id);
            Assert.AreEqual(testStylist, foundStylist);
        }
    }

}
