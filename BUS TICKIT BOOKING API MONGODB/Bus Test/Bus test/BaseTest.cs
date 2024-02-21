using BUS_TICKIT_BOOKING_API.Controllers;
using BUS_TICKIT_BOOKING_API.Logics;
using BUS_TICKIT_BOOKING_API.Model;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Bus_Test.Bus_test
{
    public class BaseTest
    {
        //public BusDbContext db;
        //public Bl_BusTickitData Bl_BusTickitData;
        //public BusDataController controller;
        ////private BUS bus;
        //public Microsoft.Extensions.Configuration.IConfiguration configuration;
        //public DatabaseSettings DatabaseSettings { get; set; }

        //public BaseTest(BusDbContext _db)
        //{
        //   db = _db;
        //}

        ////Mock<IOptions<DatabaseSettings>> iOption = new Mock<IOptions<DatabaseSettings>>();
        ////var settings = new DatabaseSettings();
        ////settings.ConnectionString = "mongodb://localhost:27017/";
        ////settings.DatabaseName = "crmTest";
        ////settings.username = "crmTest";
        ////settings.password = "crmTest";
        ////iOption.Setup(x => x.Value).Returns(settings);
        ////db = new BusDbContext((IConfiguration)iOption.Object);
        ////ConfigMock();



        //public BaseTest(IConfiguration? configuration = null)
        //{


        //     Mock<IOptions<DatabaseSettings>> iOption = new Mock<IOptions<DatabaseSettings>>();
        //    this.configuration = configuration;
        //    DatabaseSettings = new DatabaseSettings();
        //    DatabaseSettings.ConnectionString = "mongodb://localhost:27017";
        //    DatabaseSettings.DatabaseName = "MongoTest";
        //    DatabaseSettings.username = "admin";
        //    DatabaseSettings.password = "admin";
        //    iOption.Setup(x => x.Value).Returns(DatabaseSettings);

        //    controller = new BusDataController(db);

        //    ConfigMock();

        //}

        //private void ConfigMock()
        //{
        //    var Configuration = new ConfigurationBuilder()
        //           .AddJsonFile("appsettings.json");


        //}
        //============================= This is a basetestcase =======================================================

        protected BusDbContext db;
        protected IConfiguration configuration;
        protected Bl_BusTickitData Bl_BusTickitData;
        protected BusDataController controller;

        public BaseTest()
        {
            Mock<IOptions<DatabaseSettings>> iOption = new Mock<IOptions<DatabaseSettings>>();
            var setting = new DatabaseSettings();
            // setting.ConnectionString = "mongodb://localhost:27017/?replicaSet=rs0&connectTimeoutMS=60000";
            setting.ConnectionString = "mongodb://localhost:27017";

            setting.DatabaseName = "test";
            setting.username = "admin";
            setting.password = "admin";
            iOption.Setup(x => x.Value).Returns(setting);
            db = new BusDbContext(configuration);
            Bl_BusTickitData = new Bl_BusTickitData(db);
            controller = new BusDataController(db);
            ConfigMock();


        }
        private void ConfigMock()
        {
            var Configuration = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json")
                   .Build();
            this.configuration = Configuration;
        }

        protected BUS createbusdata(string name = null)
        {
            var bus = new BUS();
            {
                bus.P_Name = "Mr.BANSIL";
                bus.P_Age = 21;
                bus.P_Xender = "Male";
                bus.B_Name = "SHREEJI";
                bus.B_No = 5090;
                bus.SetNo = "L-5";
                bus.B_Picuppoint = "JAMNAGAR";
                bus.B_Dropingpoint = "RAJKOT";
                bus.B_Booking_DateTime = DateTime.Now.AddDays(-1);
                bus.Price = 1200;
                return bus;
            };
        }

        [Fact]
        public void insertdata()
        {
            var busdata = createbusdata();

            controller.INSERT_BUSTICKIT_DATA(busdata);
            var result = Bl_BusTickitData.GetById(busdata.Id);
            Assert.NotNull(result);



        }


        //============================ This is new web api test case =======================================
        //private readonly List<BUS> _bus;

        //public BaseTest()
        //{
        //    _bus = new List<BUS>()
        //    { 
            
        //    };
            
        //}

    }
}
