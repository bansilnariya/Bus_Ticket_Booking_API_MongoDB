using Amazon.Util.Internal;
using BUS_TICKIT_BOOKING_API.Controllers;
using BUS_TICKIT_BOOKING_API.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Test.Bus_test
{
    public class RepositeryWiseMockTest
    {
        [Fact]
        public void GetBusData()
        {
            var products = new List<BUS>
            { new BUS
            {
                 P_Name = "Mr.BANSIL",
                 P_Age = 21,
                 P_Xender = "Male",
                 B_Name = "SHREEJI",
                 B_No = 5090,
                 SetNo = "L-5",
                 B_Picuppoint = "JAMNAGAR",
                 B_Dropingpoint = "RAJKOT",
                 B_Booking_DateTime = DateTime.Now.AddDays(-1),
                 Price = 1200,

            }
            };

            var mockbusdata = new Mock<BusDbContext>();
            mockbusdata.Setup(x=>x.Equals(products)).Returns(true); 
            var controller = new BusDataController(mockbusdata.Object);

            //Act 
            var result = controller.GetBusTickitData();

            //Assert
            var actionresult = Assert.IsType<OkObjectResult>(result);
            var returnedresult = Assert.IsAssignableFrom<IEnumerable<BUS>>(actionresult);
            Assert.Single(returnedresult);

            
        }
    }

}
