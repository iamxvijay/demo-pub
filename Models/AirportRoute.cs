namespace AirportRoutingAPI.Models
{
    public class Airport
    {
        public int AirportID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class AirportRoute
    {
        public int OriginID { get; set; }
        public int DestinationID { get; set; }
    }
}
