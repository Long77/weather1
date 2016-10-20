using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

public class MainClass
{
    public static void Main()
    {
        Console.WriteLine("Weather Forcast: Brought to you by DarkSky! Enter your Zip Code to Get Started: ");

        string zip = Console.ReadLine();

        var url = String.Format("https://maps.googleapis.com/maps/api/geocode/json?address="+ zip);

        var net = new WebClient(); 

        string reply = net.DownloadString(url);

        Console.WriteLine(reply);
        Console.WriteLine("Your location coordinates: " );
        //Console.ReadLine();

        GeoCoding m = JsonConvert.DeserializeObject<GeoCoding>(reply);

        Console.WriteLine("{0},{1}", m.results[0].geometry.location.lat, m.results[0].geometry.location.lng);

        Console.WriteLine("Now Press Enter for the Weather!");
        Console.ReadLine();

        var url2 = String.Format("https://api.darksky.net/forecast/99365e9edb960a6f4591753f0e054c8e/" + m.results[0].geometry.location.lat + "," + m.results[0].geometry.location.lng);

        var net2 = new WebClient();

        string reply2 = net2.DownloadString(url2);

        Console.WriteLine(reply2);
        
        RootObject r = JsonConvert.DeserializeObject<RootObject>(reply2);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("...Whoops, that's not right, is it? Let's try again. Hit Enter Again!");

        Console.ReadLine();

        
       }
}



public class Location
{
    public double lat { get; set; }
    public double lng { get; set; }
}




public class Geometry
{
    public Location location { get; set; }
    public string location_type { get; set; }
    //public Viewport viewport { get; set; }
}

public class Result
{
   // public List<AddressComponent> address_components { get; set; }
    public string formatted_address { get; set; }
    public Geometry geometry { get; set; }
    public string place_id { get; set; }
    public List<string> types { get; set; }
}

public class GeoCoding
{
    public List<Result> results { get; set; }
    public string status { get; set; }
}

public class RootObject
{
    public double latitude { get; set; }
    public double longitude { get; set; }
    public string timezone { get; set; }
    public int offset { get; set; }

}
public class Currently
{
    public int time { get; set; }
    public string summary { get; set; }
    public string icon { get; set; }
    public int nearestStormDistance { get; set; }
    public int nearestStormBearing { get; set; }
    public int precipIntensity { get; set; }
    public int precipProbability { get; set; }
    public double temperature { get; set; }
    public double apparentTemperature { get; set; }
    public double dewPoint { get; set; }
    public double humidity { get; set; }
    public double windSpeed { get; set; }
    public int windBearing { get; set; }
    public int visibility { get; set; }
    public double cloudCover { get; set; }
    public double pressure { get; set; }
    public double ozone { get; set; }
}

public class Datum
{
    public int time { get; set; }
    public int precipIntensity { get; set; }
    public int precipProbability { get; set; }
}

public class Minutely
{
    public string summary { get; set; }
    public string icon { get; set; }
    public List<Datum> data { get; set; }
}

public class Datum2
{
    public int time { get; set; }
    public string summary { get; set; }
    public string icon { get; set; }
    public int precipIntensity { get; set; }
    public int precipProbability { get; set; }
    public double temperature { get; set; }
    public double apparentTemperature { get; set; }
    public double dewPoint { get; set; }
    public double humidity { get; set; }
    public double windSpeed { get; set; }
    public int windBearing { get; set; }
    public double visibility { get; set; }
    public double cloudCover { get; set; }
    public double pressure { get; set; }
    public double ozone { get; set; }
}

public class Hourly
{
    public string summary { get; set; }
    public string icon { get; set; }
    public List<Datum2> data { get; set; }
}

public class Datum3
{
    public int time { get; set; }
    public string summary { get; set; }
    public string icon { get; set; }
    public int sunriseTime { get; set; }
    public int sunsetTime { get; set; }
    public double moonPhase { get; set; }
    public double precipIntensity { get; set; }
    public double precipIntensityMax { get; set; }
    public double precipProbability { get; set; }
    public double temperatureMin { get; set; }
    public int temperatureMinTime { get; set; }
    public double temperatureMax { get; set; }
    public int temperatureMaxTime { get; set; }
    public double apparentTemperatureMin { get; set; }
    public int apparentTemperatureMinTime { get; set; }
    public double apparentTemperatureMax { get; set; }
    public int apparentTemperatureMaxTime { get; set; }
    public double dewPoint { get; set; }
    public double humidity { get; set; }
    public double windSpeed { get; set; }
    public int windBearing { get; set; }
    public double visibility { get; set; }
    public double cloudCover { get; set; }
    public double pressure { get; set; }
    public double ozone { get; set; }
    public int? precipIntensityMaxTime { get; set; }
    public string precipType { get; set; }
}

public class Daily
{
    public string summary { get; set; }
    public string icon { get; set; }
    public List<Datum3> data { get; set; }
}


