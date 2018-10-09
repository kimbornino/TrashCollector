using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace TrashCollector.Operations
{

    public class Geocoder
    {

        public static void RunGeocoder(string address, string zip)
        {

            address = address.Trim().Replace(" ", "+");
            zip = zip.Trim();
            //city = city.Trim().Replace(" ", "+");
            //state = state.Trim();
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={address},zip={zip}&key={MapAPIKey.key}";
        }
    }
}

