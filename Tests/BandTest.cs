using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Bandtracker
{
    public class BandsTest : IDisposable
    {
        public BandsTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=bandtracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_BandsEmptyAtFirst()
        {
            //Arrange, Act
            int result = Band.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_Save()
        {
            //Arrange
            Band testBand = new Band("Linkin Park");
            testBand.Save();

            //Act
            List<Band> result = Band.GetAll();
            List<Band> testList = new List<Band>{testBand};

            //Assert
            Assert.Equal(testList, result);
        }

        public void Dispose()
        {
            Band.DeleteAll();
            Venue.DeleteAll();
        }
    }
}
