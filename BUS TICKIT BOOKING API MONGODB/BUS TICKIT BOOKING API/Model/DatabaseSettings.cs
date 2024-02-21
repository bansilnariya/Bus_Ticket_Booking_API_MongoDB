namespace BUS_TICKIT_BOOKING_API.Model
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string username { get; set; }
        public string password { get; set; }

        public object Setup(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
