using BUS_TICKIT_BOOKING_API.Logics;
using BUS_TICKIT_BOOKING_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;

namespace BUS_TICKIT_BOOKING_API.Controllers
{
    [Route("BUS")]
    [ApiController]
    public class BusDataController : ControllerBase
    {
        private readonly BusDbContext db;
        public Bl_BusTickitData bl_bustickitdata;

        public BusDataController(BusDbContext context)
        {
            this.db = context;
            bl_bustickitdata = new Bl_BusTickitData(db);

        }

        //public BusDataController()
        //{
        //}

        //GET DATA
        [HttpGet]
        public List<BUS> GetBusTickitData()
        {
            using (var session = db.client2.StartSession())
            {
                try
                {
                    session.StartTransaction();
                    return bl_bustickitdata.Get_BusTickit_data();
                }
                catch (Exception)
                {
                    session.AbortTransaction();
                    throw;
                }
            }
        }

        [HttpPost]
        public string INSERT_BUSTICKIT_DATA([FromBody] BUS bus)
        {
            using (var seesion = db.client2.StartSession())
            {
                try
                {
                    if (bus == null)
                    {
                        return ErroCode.INVALID_DATA;
                    }
                    else
                    {
                        seesion.StartTransaction();
                        var res = bl_bustickitdata.Insert_BusTickit_data(bus);
                        seesion.CommitTransaction();
                        return res;
                    }
                }
                catch (Exception)
                {
                    seesion.AbortTransaction();
                    throw;
                }

            }
        }
        [HttpPut]
        public string updatebustickitdata([FromQuery] string id, [FromBody] BUS bus)
        {
            using (var session = db.client2.StartSession())
            {
                try
                {
                    if (id == null)
                        return ErroCode.INVALID_DATA;
                    var existingdata = bl_bustickitdata.GetById(id);
                    if (existingdata == null)
                        return (ErroCode.INVALID_DATA);
                    var result = bl_bustickitdata.Update_BusTickit_data(id, bus);
                    return (ErroCode.UPDATE_DATA);

                }
                catch (Exception)
                {
                    session.StartTransaction();
                    throw new InvalidDataException(ErroCode.ERROR);
                }
            }
        }

        [HttpDelete]
        public string deletebustickitdata([FromQuery] string id)
        {
            using (var session = db.client2.StartSession())
            {
                try
                {
                    var res = bl_bustickitdata.Delete_BusTickit_data(id);
                    return res;

                }
                catch (Exception)
                {
                    session.StartTransaction();
                    throw;
                }
            }
        }

    }
}
