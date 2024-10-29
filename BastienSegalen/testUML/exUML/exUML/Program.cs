namespace exUML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class Car
    {
        public int speed;
        private string _color;
        private string _modele;
        private List<Passenger> passengers = new List<Passenger>();
        public Car(string color, string modele)
        {
            _color = color;
            _modele = modele;
        }
        public void AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
        }
        public void start()
        {

        }
        public void stop()
        {

        }

    }
    public class Passenger
    {
        private string _name;
    }
}
