using GoogleMaps.LocationServices;

namespace Gimnasio.Data
{
    public class Geocodificacion
    {
        public double Latitude(string direccion, string localidad, string provincia)
        {
            string address = direccion + ", " + localidad + ", " + provincia;
            var Locationservice = new GoogleLocationService();
            var point = Locationservice.GetLatLongFromAddress(address);
            var latitude = point.Latitude;
            return (latitude);
        }
        public double Longitude(string direccion, string localidad, string provincia)
        {
            string address = direccion + ", " + localidad + ", " + provincia;
            var Locationservice = new GoogleLocationService();
            var point = Locationservice.GetLatLongFromAddress(address);
            var longitude = point.Longitude;
            return (longitude);
        }
    }
}
