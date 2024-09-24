using System;
namespace Drones
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Création de la flotte de drones
            List<Drone> fleet= new List<Drone>();
            List<Buliding> bulidings = new List<Buliding>();
            List<Factory> factorys = new List<Factory>();
            List<Store> stores = new List<Store>();
            Drone drone = new Drone();
            Buliding buliding = new Buliding();
            Buliding buliding2 = new Buliding();
            Factory factory = new Factory();
            Store store = new Store();
            drone.x = 100;
            drone.y = 100;
            drone.name = "ben";
            fleet.Add(drone);
            bulidings.Add(buliding);
            bulidings.Add(buliding2);
            factorys.Add(factory);
            stores.Add(store);

            buliding.x = 400;
            buliding.y = 100;
            buliding2.y = 70;
            buliding2.x = 410;
            factory.y = 150;
            factory.x = 500;
            store.y = 130;
            store.x = 490;



            try
            {
                //Drone drone= new Drone();
                //Drone.MaMethode(5);

                if (fleet.Count() < 10)
                {
                    throw new ArgumentException("La valeur de x est inférieure à 10 !");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Erreur : {e.Message}");
            }
            // Démarrage
            try
            {
                Application.Run(new AirSpace(fleet, bulidings, factorys, stores));
            }
            catch (Exception e)
            {
                throw new Exception("Il y a eu une erreur");
            }
        }
    }
}