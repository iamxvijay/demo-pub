using AirportRoutingAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace AirportRoutingAPI.Data
{
    public static class AirportData
    {
        // In-memory list of Airports
        public static readonly List<Airport> Airports = new()
        {
            new Airport { AirportID = 1, Code = "NYC", Name = "New York City" },
            new Airport { AirportID = 2, Code = "LAX", Name = "Los Angeles" },
            new Airport { AirportID = 3, Code = "LON", Name = "London" },
            new Airport { AirportID = 4, Code = "PAR", Name = "Paris" },
            new Airport { AirportID = 5, Code = "TOK", Name = "Tokyo" },
            new Airport { AirportID = 6, Code = "ROM", Name = "Rome" }
        };

        // In-memory list of Routes
        public static readonly List<AirportRoute> Routes = new()
        {
            new AirportRoute { OriginID = 1, DestinationID = 3 }, // NYC → LON
            new AirportRoute { OriginID = 1, DestinationID = 4 }, // NYC → PAR
            new AirportRoute { OriginID = 1, DestinationID = 2 }, // NYC → LAX
            new AirportRoute { OriginID = 1, DestinationID = 6 }, // NYC → ROM
            new AirportRoute { OriginID = 2, DestinationID = 1 }, // LAX → NYC
            new AirportRoute { OriginID = 2, DestinationID = 5 }, // LAX → TOK
            new AirportRoute { OriginID = 3, DestinationID = 1 }, // LON → NYC
            new AirportRoute { OriginID = 3, DestinationID = 4 }, // LON → PAR
            new AirportRoute { OriginID = 3, DestinationID = 6 }  // LON → ROM
        };

        public static List<Airport> GetDestinations(string originCode)
        {
            var originAirport = Airports.FirstOrDefault(a => a.Code.ToUpper() == originCode.ToUpper());
            if (originAirport == null)
            {
                return new List<Airport>(); // No matching origin
            }

            var destinationIDs = Routes
                .Where(route => route.OriginID == originAirport.AirportID)
                .Select(route => route.DestinationID);

            return Airports
                .Where(airport => destinationIDs.Contains(airport.AirportID))
                .ToList();
        }
    }
}
