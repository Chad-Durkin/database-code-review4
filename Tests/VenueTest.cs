using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Bandtracker
{
    public class VenuesTest : IDisposable
    {
        public VenuesTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=bandtracker_test;Integrated Security=SSPI;";
        }
        [Fact]
        public void Test_VenuesEmptyAtFirst()
        {
            //Arrange, Act
            int result = Venue.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }
        public void Dispose()
        {
            Venue.DeleteAll();
            Venue.DeleteAll();
        }
    }
}
