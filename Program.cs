using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBuildExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings settings = new SettingsManager().GetSettings();
            Console.WriteLine($"Name:{settings.Name,-20}Version:{settings.Version,-15}Type:{settings.Type,-15}");


        }
    }
}