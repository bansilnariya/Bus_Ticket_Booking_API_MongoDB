using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Net.WebSockets;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace BUS_TICKIT_BOOKING_API.Model
{
    public class BusDbContext
    {
        private readonly IMongoDatabase _database;

        public BusDbContext(IConfiguration configuration)
        {
            //=================================== old connection code =========================
            var client = new MongoClient(configuration.GetConnectionString("MDBCS"));


            _database = client.GetDatabase("BUS_TICKITBOOKING_DATABASE");
            bustickitdata = _database.GetCollection<BUS>("bus_tickit_data");
            var connectionString = "mongodb://localhost:27017,localhost:27018,localhost:27019/?replicaSet=rs0&connectTimeoutMS=60000";
            client2 = new MongoClient(connectionString);




        }

        public readonly MongoClient client2;
        public readonly IMongoCollection<BUS> bustickitdata;


        //=============================== new connection code hrms wise =========================

        //public readonly IMongoDatabase db;


        //public BusDbContext(IOptions<DatabaseSettings> options)
        //{
        //    var settings = options.Value;

        //    var credential = MongoCredential.CreateCredential(settings.DatabaseName, settings.username, settings.password);
        //    var clientSettings = MongoClientSettings.FromConnectionString(settings.ConnectionString);
        //    clientSettings.Credential = credential;
        //    clientSettings.RetryWrites = false;

        //    client2 = new MongoClient(clientSettings);
        //    db = client2.GetDatabase(settings.DatabaseName);

        //    bustickitdata = db.GetCollection<BUS>("busticitdata");
        //}
        //public readonly MongoClient client2;
        //public readonly IMongoCollection<BUS> bustickitdata;

    }
}
