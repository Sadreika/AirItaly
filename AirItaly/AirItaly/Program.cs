using RestSharp;
using System;

namespace AirItaly
{
    class Program
    {
        static void Main(string[] args)
        {
            AirItaly airItalyObject = new AirItaly("MAD", "LIN", "20200926", "20200930", "false");
            airItalyObject.collectingData();
        }
    }
}
