using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            "Hello World".PrintToConsole(); // it can't have any parameters passed in, but it is attached to the string so that's what's passed in

            HotelRoomModel room = new HotelRoomModel();
            // Entering the room
            room.TurnOnAir().SetTemperature(23).OpenShades(); // the extension allows us to do everything at once and chain them together since we do "return room" at the end of each

            // Exiting the room
            room.TurnOffAir().CloseShades();

            /*
            If we didn't setup the extension that returns room itself the code would need to be more complicated and messy:
                OpenShades(SetTemperature(TurnOnAir(room),23));
            */

            PersonModel person = new PersonModel();
            person.FirstName = "Neven";
            person.LastName = "Grguric";

            person.SetDefaultAge().PrintInfo();

            Console.ReadLine();
        }
    }

    public class HotelRoomModel
    {
        public int Temperature { get; set; }
        public bool IsAirRunning { get; set; }
        public bool AreShadesOpen { get; set; }
    }

    public static class ExtensionSamples // extension methods have to be static and in a static class
    {
        public static void PrintToConsole(this string message) // "this" indicates that it is an extension method (we are extending the string)
        {
            Console.WriteLine(message);
        }

        public static HotelRoomModel TurnOnAir(this HotelRoomModel room)
        {
            room.IsAirRunning = true;
            return room;
        }

        public static HotelRoomModel TurnOffAir(this HotelRoomModel room)
        {
            room.IsAirRunning = false;
            return room;
        }

        public static HotelRoomModel SetTemperature(this HotelRoomModel room, int temperature)
        {
            room.Temperature = temperature;
            return room;
        }

        public static HotelRoomModel OpenShades(this HotelRoomModel room)
        {
            room.AreShadesOpen = true;
            return room;
        }

        public static HotelRoomModel CloseShades(this HotelRoomModel room)
        {
            room.AreShadesOpen = false;
            return room;
        }
    }

    // Homework - Create the following chain using extension methods: person.SetDefaultAge().PrintInfo();

    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public static class PersonExtension
    {
        public static PersonModel SetDefaultAge(this PersonModel person)
        {
            person.Age = 23;
            return person;
        }

        public static void PrintInfo(this PersonModel person)
        {
            Console.WriteLine($"First name: {person.FirstName}");
            Console.WriteLine($"Last name: {person.LastName}");
            Console.WriteLine($"Age: {person.Age}");
        }
    }

    
}
