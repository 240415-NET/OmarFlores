using System;
using log4net.Config;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace log4netAdvanced
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));
        // private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            // create 2 persons
            XmlConfigurator.Configure();
            var person1 = new Person("Jonh", "Gold");
            var person2 = new Person("James", "Miller");
            // create 2 cars
            var car1 = new Car("Tesla Model S", 2020, person1);
            var car2 = new Car("Tesla Model X", 2020, person2);
            Console.WriteLine("why not writing???");
            // logging
            logger.Debug("Some debug log");
            logger.Info(String.Format("Person1: {0}", person1));
            logger.Info(String.Format("Car2: {0}", car2));
            logger.Warn(String.Format("Warning accrued at {0}", DateTime.Now));
            logger.Error(String.Format("Error accrued at {0}", DateTime.Now));
            logger.Fatal(String.Format("Serious problem with car {0} accrued at {1}", car1, DateTime.Now));
        }
    }
}