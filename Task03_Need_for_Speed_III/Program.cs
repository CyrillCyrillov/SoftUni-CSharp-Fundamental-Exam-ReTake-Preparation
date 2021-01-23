using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03_Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {

            int carsNumber = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();


            for (int i = 1; i <= carsNumber; i++)
            {
                string[] nextCarInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string carModel = nextCarInfo[0];
                int mileage = int.Parse(nextCarInfo[1]);
                int fuel = int.Parse(nextCarInfo[2]);

                cars.Add(carModel, new List<int> { mileage, fuel });
            }

            while (true)
            {

                string[] nextRacingInfo = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(nextRacingInfo[0].ToUpper() == "STOP")
                {
                    break;
                }

                string typeComand = nextRacingInfo[0];
                string car = nextRacingInfo[1];

                switch (typeComand.ToUpper())
                {
                    case "DRIVE":

                        int distance = int.Parse(nextRacingInfo[2]);
                        int neededFuel = int.Parse(nextRacingInfo[3]);
                        if(cars[car][1] >= neededFuel)
                        {
                            cars[car][0] += distance;
                            cars[car][1] -= neededFuel;

                            Console.WriteLine($"{car} driven for {distance} kilometers. {neededFuel} liters of fuel consumed.");

                            if (cars[car][0] >= 100000)
                            {
                                cars.Remove(car);
                                Console.WriteLine($"Time to sell the {car}!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }

                        break;

                    case "REFUEL":

                        int addedFuel = int.Parse(nextRacingInfo[2]);

                        if(addedFuel + cars[car][1] > 75)
                        {
                            addedFuel = 75 - cars[car][1];
                        }

                        cars[car][1] += addedFuel;

                        Console.WriteLine($"{car} refueled with {addedFuel} liters");

                        break;

                    case "REVERT":

                        int revertDistance = int.Parse(nextRacingInfo[2]);

                        cars[car][0] -= revertDistance;
                        Console.WriteLine($"{car} mileage decreased by {revertDistance} kilometers");

                        if(cars[car][0] < 10000)
                        {
                            cars[car][0] = 10000;
                        }

                        break;


                    default:
                        break;
                }

            }

            foreach (var item in cars.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value[0]} kms, Fuel in the tank: {item.Value[1]} lt.");
            }
        }
    }
}

