using BUS_TICKIT_BOOKING_API.Controllers;
using BUS_TICKIT_BOOKING_API.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Xunit.Assert;

namespace Bus_Test.Bus_test
{
    public class bustickitdata:BaseTest
    {
        public BusDataController controller;
        public BusDbContext db;



        public bustickitdata()
        {
            db =  new BusDbContext(configuration);
            controller = new BusDataController(db);
            creatingbusdata();
        }

        public BUS creatingbusdata()
        {
            var bus = new BUS();
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

            //Bl_BusTickitData.Insert_BusTickit_data(bus);
            return bus;

        }

        [Fact]
        public void insertbusdata()
        {
            //setup
            var data = creatingbusdata();

            //exicute
            var responce = controller.INSERT_BUSTICKIT_DATA(data);

            //assert
            NotNull(responce);
            var actualdata= db.bustickitdata.Find(x=>x.Id==responce).FirstOrDefault();
            Equal(data.P_Name, actualdata.P_Name);

            
           
        }
    }
    
}
