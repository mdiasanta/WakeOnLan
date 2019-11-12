using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WakeOnLan
{
    public class WakeService
    {
        public static void WakeDevice(List<Machines> Machines)
        {
            Console.WriteLine("Available Machines to Wake");

            for (var i = 0; i < Machines.Count(); i++)
            {
                Console.WriteLine($"Option: {i}. {Machines[i].Name}");
            }

            Console.Write("\nSelect a Device to Wake:");
            var selectedIndex = Console.ReadLine();

            var selectedMachine = Machines[Convert.ToInt32(selectedIndex)];

            Console.WriteLine($"\n{selectedMachine.Name} selected!");

            var macAddress = selectedMachine.Mac;
            macAddress = Regex.Replace(macAddress.ToString(), "[-|-]", "");

            Console.WriteLine($"\nWakeing {selectedMachine.Name}...");

            WakeHelper.WakeOnLan(macAddress).Wait();

            Console.WriteLine($"\nSuccessfully Woke {selectedMachine.Name}! \nPress any key to Exit...");
            Console.ReadLine();
        }
    }
}
