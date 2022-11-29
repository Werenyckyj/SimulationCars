using System;

namespace SimulationCars
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation s = new Simulation(0, 60, 40, 40, 180, 80, 0.0002777777777);
            Console.WriteLine(s.Simulate());

            Console.ReadLine();
        }
    }
    class Simulation
    {
        public double LowDistance { get; set; }
        public double time = 0;
        public double TimeStep { get; set; }

        public double CarAPostition { get; set; }
        public double CarASpeed { get; set; }
        public double CarBPostition { get; set; }
        public double CarBSpeed { get; set; }
        public double CarCPostition { get; set; }
        public double CarCSpeed { get; set; }
        public Simulation(double carAPosition, double carASpeede, double carBPosition, double carBSpeede, double carCPosition, double carCSpeede, double timeStep)
        {
            CarAPostition = carAPosition;
            CarASpeed = carASpeede;

            CarBPostition = carBPosition;
            CarBSpeed = carBSpeede;

            CarCPostition = carCPosition;
            CarCSpeed = carCSpeede;

            TimeStep = timeStep;
        }
        public string Simulate()
        {
            LowDistance = Math.Abs(CarBPostition - CarAPostition) + Math.Abs(CarCPostition - CarBPostition) + Math.Abs(CarCPostition - CarAPostition);
            while (true)
            {
                CarAPostition += CarASpeed * TimeStep;
                CarBPostition += CarBSpeed * TimeStep;
                CarCPostition -= CarCSpeed * TimeStep;

                if (LowDistance <= Math.Abs(CarBPostition - CarAPostition) + Math.Abs(CarCPostition - CarBPostition) + Math.Abs(CarCPostition - CarAPostition))
                {
                    return LowDistance + "km v čase " + time*60 +"min \nAB:" + Math.Abs(CarBPostition - CarAPostition) + "km BC" + Math.Abs(CarCPostition - CarBPostition) + "km AC" + Math.Abs(CarCPostition - CarAPostition) + "km \nA:" + CarAPostition + "km B:" + CarBPostition + "km C:" + CarCPostition + "km";
                }
                time += TimeStep;
                LowDistance = Math.Abs(CarBPostition - CarAPostition) + Math.Abs(CarCPostition - CarBPostition) + Math.Abs(CarCPostition - CarAPostition);
            }
        }
    }
}
