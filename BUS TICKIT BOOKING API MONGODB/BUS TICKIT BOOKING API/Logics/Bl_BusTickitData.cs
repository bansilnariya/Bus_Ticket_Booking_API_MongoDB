using BUS_TICKIT_BOOKING_API.Model;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BUS_TICKIT_BOOKING_API.Logics
{
    public class Bl_BusTickitData
    {
        public readonly BusDbContext db;

        public Bl_BusTickitData(BusDbContext context)
        {
            this.db = context;
        }
        
        //------------------------------- GET DATA --------------------
        public List<BUS> Get_BusTickit_data()
        {
            var data= db.bustickitdata.Find(X=>X.Id !=null).ToList();
            return data;
        }
        public BUS GetById(string  id)
        {
            var datas= db.bustickitdata.Find(x=>x.Id ==id).FirstOrDefault();
            return datas;
        }

        //======================== INSERT DATA ==========================
        public string Insert_BusTickit_data(BUS bUS)
        {
            if (bUS == null)
            {
                return ErroCode.INVALID_DATA;
            }
            else
            {
                try
                {
                    db.bustickitdata.InsertOne(bUS);
                    return ErroCode.INSERT_DATA;
                }
                catch (Exception)
                {
                    return ErroCode.ERROR;
                }
            }
        }

        //============================ UPDATE DATA ======================
        public string Update_BusTickit_data(string id,BUS bus)
        {
            if(bus == null)
            {
                return ErroCode.INVALID_DATA;
            }    
            else
            {
                try
                {
                    var updatebustickitdataa = db.bustickitdata.Find(x => x.Id == id).FirstOrDefault();
                    updatebustickitdataa.Id = id;
                    updatebustickitdataa.P_Name = bus.P_Name;
                    updatebustickitdataa.P_Age = bus.P_Age;
                    updatebustickitdataa.P_Xender = bus.P_Xender;
                    updatebustickitdataa.B_Name = bus.B_Name;
                    updatebustickitdataa.B_No = bus.B_No;
                    updatebustickitdataa.SetNo = bus.SetNo;
                    updatebustickitdataa.B_Picuppoint = bus.B_Picuppoint;
                    updatebustickitdataa.B_Dropingpoint = bus.B_Dropingpoint;
                    updatebustickitdataa.B_Booking_DateTime = bus.B_Booking_DateTime;
                    updatebustickitdataa.Price = bus.Price;
                    db.bustickitdata.ReplaceOne(x => x.Id == id,updatebustickitdataa);
                    return ErroCode.UPDATE_DATA;
                }
                catch (Exception)
                {
                    return ErroCode.ERROR;
                }
            }
        }

        //======================================== DELETE DATA ================
        public string Delete_BusTickit_data(string id)
        {
            if(id != null)
            {
                var deletingdata = db.bustickitdata.Find(x=>x.Id==id).FirstOrDefault();
                if(deletingdata != null)
                {
                    db.bustickitdata.DeleteOne(x => x.Id == deletingdata.Id);
                    return ErroCode.DELETE_DATA;
                }
            }
            return ErroCode.INVALID_DATA;
        }
    }
}
