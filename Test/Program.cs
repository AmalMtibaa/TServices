using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                string address = "Tunis";
                string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));
                Console.WriteLine(requestUri);
                WebRequest request = WebRequest.Create(requestUri);
                WebResponse response = request.GetResponse();
                XDocument xdoc = XDocument.Load(response.GetResponseStream());
                Console.WriteLine(xdoc.Element("GeocodeResponse").Element("status").Value);

                XElement res = xdoc.Element("GeocodeResponse").Element("result");
                XElement locationElement = res.Element("geometry");
                XElement test = locationElement.Element("location");
                String lat = test.Element("lat").Value;
                String lng = test.Element("lng").Value;
                Console.WriteLine(lat + " " + lng);

            }
        }
    }

