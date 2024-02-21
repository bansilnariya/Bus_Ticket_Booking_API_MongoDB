using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BUS_TICKIT_BOOKING_API.Model
{
    public class BUS
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
       public string ? Id { get; set; } =null;

        public string P_Name { get; set; }

        public int P_Age { get; set; }

        public string P_Xender { get; set; }    

        public string B_Name { get; set; }
        public int B_No  { get; set;}
        public string SetNo { get; set; }
        public string B_Picuppoint { get; set; }
        public string B_Dropingpoint { get;set; }    
        public DateTime B_Booking_DateTime { get; set; }

        public int Price { get; set; }  

    }
}
