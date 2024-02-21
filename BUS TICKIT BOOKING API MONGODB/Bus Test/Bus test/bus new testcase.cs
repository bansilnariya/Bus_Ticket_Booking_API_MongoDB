using BUS_TICKIT_BOOKING_API.Controllers;
using BUS_TICKIT_BOOKING_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Test.Bus_test
{
    public class bus_new_testcase
    {
        private readonly BusDataController _controller;
        private  readonly BusDbContext db;

        public bus_new_testcase()
        {
            _controller = new BusDataController(db);
            
        }
    }
}
