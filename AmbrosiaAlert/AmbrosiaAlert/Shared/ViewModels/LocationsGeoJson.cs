using AmbrosiaAlert.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbrosiaAlert.Shared.ViewModels
{
    public class GeoJsonLocations
    {
        public string Type => "FeatureCollection";
        public IEnumerable<GeoJsonFeature> Features { get; }

        public GeoJsonLocations(IEnumerable<Location> locations)
        {
            Features = locations.Select(a => new GeoJsonFeature(a));
        }
    }

    public class GeoJsonFeature
    {
        public string Type => "Feature";
        public GeoJsonProperties Properties { get; set; }
        public GeoJsonGeometry Geometry { get; set; }

        public GeoJsonFeature(Location location)
        {
            Properties = new GeoJsonProperties(location.Id.Value);
            Geometry = new GeoJsonGeometry(location.Latitude, location.Longitude);
        }
    }

    public class GeoJsonProperties
    {
        public Guid LocationId { get; set; }

        public GeoJsonProperties(Guid locationId)
        {
            LocationId = locationId;
        }
    }

    public class GeoJsonGeometry
    {
        public string Type => "Point";
        public IEnumerable<decimal> Coordinates { get; set; }

        public GeoJsonGeometry(decimal latitude, decimal longitude)
        {
            Coordinates = new [] { longitude, latitude };
        }
    }
}
