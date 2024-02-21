using BUS_TICKIT_BOOKING_API.Controllers;
using BUS_TICKIT_BOOKING_API.Logics;
using BUS_TICKIT_BOOKING_API.Model;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Mongo2Go;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusTickitData_Test_Case.Bus_Tickit_Test_Case
{
    public class BusData_Testcase
    {

        //public readonly IMongoDatabase _database;
        //private readonly IMongoCollection<BUS> _collection;
        //public BusDataController Controller;

        // ======================================================== CHAT GPT   =====================================================


        //[Fact]
        //public void TestMongoDb()
        //{
        //    // Start the embedded MongoDB server
        //    using (var runner = MongoDbRunner.StartForDebugging())
        //    {
        //        // Get connection string for the embedded MongoDB server
        //        var connectionString = runner.ConnectionString;

        //        // Set up MongoDB client using the embedded server
        //        var client = new MongoClient(connectionString);

        //        // Get database and collection names
        //        var databaseName = "BusTickitBooking_DataBase";
        //        var collectionName = "busbookingdata";

        //        // Get a reference to the database
        //        var database = client.GetDatabase(databaseName);

        //        // Get a reference to the collection
        //        var collection = database.GetCollection<BUS>(collectionName);

        //        // Insert some test data


        //        var updatebustickit = new BUS()
        //        {

        //            P_Name = "Mr.BANSIL",
        //            P_Age = 21,
        //            P_Xender = "Male",
        //            B_Name = "SHREEJI",
        //            B_No = 5090,
        //            SetNo = "L-5",
        //            B_Picuppoint = "JAMNAGAR",
        //            B_Dropingpoint = "RAJKOT",
        //            B_Booking_DateTime = DateTime.Now.AddDays(-1),
        //            Price = 1200
        //        };
        //        var data = Controller.INSERT_BUSTICKIT_DATA(updatebustickit);

        //        Assert.Equal("DATA IS INSERTING SUCCESSFULLY...!!", data);







        //        //================== update ==============================
        //        //var updateFilter = Builders<BsonDocument>.Filter.Eq("P_Name", "Bansil");
        //        //var update = Builders<BsonDocument>.Update.Set("P_Age", 31);
        //        //collection.UpdateOne(updateFilter, update);

        //        //// Query the collection after update and assert the result
        //        //result = collection.Find(filter).FirstOrDefault();

        //        //Assert.NotNull(result);
        //        //Assert.Equal("Test", result["P_Name"].AsString);
        //        //Assert.Equal(30, result["P_Age"].AsInt32);

        //        //   //================== Delete =========================================
        //        //   // Delete the document
        //        //var deleteFilter = Builders<BsonDocument>.Filter.Eq("P_Name", "Test");
        //        //collection.DeleteOne(deleteFilter);

        //        ////   // Query the collection after delete and assert the result
        //        //result = collection.Find(filter).FirstOrDefault();

        //         //Assert.Null(result); // Expecting null after deletion



        //    }
        //}



        //========================================== Static Data with Insert Data and Test Case =====================================

        //[Fact]
        //public void TestMongoDb()
        //{
        //    // Start the embedded MongoDB server
        //    using (var runner = MongoDbRunner.StartForDebugging())
        //    {
        //        // Get connection string for the embedded MongoDB server
        //        var connectionString = runner.ConnectionString;

        //        // Set up MongoDB client using the embedded server
        //        var client = new MongoClient(connectionString);

        //        // Get database and collection names
        //        var databaseName = "BUS_TICKI_BOOKING_DATABASE";
        //        var collectionName = "bus_tickit_data";

        //        // Get a reference to the database
        //        var database = client.GetDatabase(databaseName);

        //        // Get a reference to the collection
        //        var collection = database.GetCollection<BsonDocument>(collectionName);

        //        // Insert some test data
        //        var document = new BsonDocument {
        //        { "P_Name", "Bansil" },
        //        { "P_Age", 30 },
        //        { "P_Xender", "Male" },
        //        { "B_Name", "Shreeji" },
        //        { "B_No", 3020 },
        //        { "SetNo", "U-5" },
        //        { "B_Picuppoint", "Jamnagar" },
        //        { "B_Dropingpoint", "Rajkot"},
        //        { "B_Booking_DateTime", DateTime.Now.AddDays(-1) },
        //        { "Price", 300 },


        //    };
        //        collection.InsertOne(document);

        //        // Query the collection and assert the result
        //        var filter = Builders<BsonDocument>.Filter.Eq("P_Name", "Bansil");
        //        var result = collection.Find(filter).FirstOrDefault();

        //        Assert.NotNull(result);
        //        Assert.Equal("Bansil", result["P_Name"].AsString);
        //        Assert.Equal(30, result["P_Age"].AsInt32);
        //    }
        //}
        //    }
        //}

        private BusDbContext db;
        public Bl_BusTickitData bl_bustikitdata;

        public IConfigurationBuilder configuration;

        public BusDbContext Db { get => db; set => db = value; }

        public BusData_Testcase()
        {
            Mock<IOptions<DatabaseSettings>> iOption = new Mock<IOptions<DatabaseSettings>>();
            var settings = new DatabaseSettings();
            settings.ConnectionString = "mongodb://localhost:27017/";
            settings.DatabaseName = "test";
            settings.username = "admin";
            settings.password = "admin";

            iOption.Setup(x => x.Value).Returns(settings);
            confingMock();
            CreateTestDB();
        }

        protected BusDbContext CreateTestDB()
        {

            var optionsBuilder = new DbContextOptionsBuilder<BusDbContext>();

            var dbContextOptions = optionsBuilder.Options;
            Db = new BusDbContext((IConfiguration)dbContextOptions);
            Db.Database.EnsureDeleted();
            Db.Database.EnsureCreated();
            return Db;
        }

        private void confingMock()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            this.configuration = configuration;
        }

        
        //public void create_bus_data()
        //{
        //    var busdata = new BUS()
        //    {
        //        P_Name = "Mr.BANSIL",
        //        P_Age = 21,
        //        P_Xender = "Male",
        //        B_Name = "SHREEJI",
        //        B_No = 5090,
        //        SetNo = "L-5",
        //        B_Picuppoint = "JAMNAGAR",
        //        B_Dropingpoint = "RAJKOT",
        //        B_Booking_DateTime = DateTime.Now.AddDays(-1),
        //        Price = 1200

        //    };


        //}

      
    }
}
