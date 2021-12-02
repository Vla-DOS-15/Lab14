using System;
using System.IO;
using System.Collections.Generic;

namespace Lab14
{
    class Program
    {
        static List<Car> cars;
        static void PrintCars()
        {
            foreach (Car processor in cars)
            {
                Console.WriteLine(processor.Info().Replace('і', 'i'));
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            cars = new List<Car>();
            FileStream fs = new FileStream("carsBin.towns", FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);
            try
            {
                Car car;
                Console.WriteLine("Читаємо данi з файлу...\n");
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    car = new Car();
                    for (int i = 1; i <= 8; i++)
                    {
                        switch (i)
                        {
                            case 1: car.Make = reader.ReadString(); break;
                            case 2: car.Model = reader.ReadString(); break;
                            case 3: car.Color = reader.ReadString(); break;
                            case 4: car.YearOfCreation = reader.ReadUInt32(); break;
                            case 5: car.Price = reader.ReadInt32(); break;
                            case 8: car.KeyWorkingOrder = reader.ReadBoolean(); break;
                        }
                    }
                    cars.Add(car);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталась помилка: {0}", ex.Message);
            }
            finally
            {
                reader.Close();
            }
            Console.WriteLine("Несортований перелiк автомобiлiв: {0}", cars.Count);
            PrintCars();
            cars.Sort();
            Console.WriteLine("Cортований перелiк автомобiлiв: {0}", cars.Count);
            PrintCars();
            Console.WriteLine("Додаємо новий запис: Ford");
            Car carFord = new Car("Ford", "Mustang", "Red", 2017, 50000, true);
            cars.Add(carFord);
            cars.Sort();
            Console.WriteLine(" Перелiк автомобiлiв: {0}", cars.Count);
            PrintCars();
            Console.WriteLine(" Видаляємо останнє значення");
            cars.RemoveAt(cars.Count - 1);
            Console.WriteLine(" Перелiк автомобiлiв: {0}", cars.Count);
            PrintCars();
            Console.ReadKey();
        }
    }
}
