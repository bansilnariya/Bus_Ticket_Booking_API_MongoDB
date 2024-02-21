using BUS_TICKIT_BOOKING_API.Controllers;
using BUS_TICKIT_BOOKING_API.Logics;
using BUS_TICKIT_BOOKING_API.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTickitData_Test_Case.Bus_Tickit_Test_Case
{
    public class Bus_TestCase : BusData_Testcase
    {
        
        public BusDataController controller;

        public Bus_TestCase(Bl_BusTickitData bl_BusTickitData)
        {
            controller = new BusDataController();
            controller.bl_bustickitdata = bl_BusTickitData;
            
        }


    }
    //    [Fact]
    //    public void AddBusData()
    //    {
    //        var bus = this.
    //    }
}
