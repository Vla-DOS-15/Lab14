using System;

namespace Lab14
{
    public class Car : IComparable <Car>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public uint YearOfCreation { get; set; }
        public int Price { get; set; }
        public bool KeyWorkingOrder { get; set; }

        public Car() { }

        public Car(string _make, string _model, string color, uint yearOfCreation, int price, bool keyWorkingOrder)
        {
            Make = _make;
            Model = _model;
            Color = color;
            YearOfCreation = yearOfCreation;
            Price = price;
            KeyWorkingOrder = keyWorkingOrder;
        }
        public string Info() => Make + ", " + Model + ", " + Color + ", " + YearOfCreation + ", " + Price + ", " + KeyWorkingOrder;

        public int CompareTo(Car car) => YearOfCreation.CompareTo(car.YearOfCreation);
    }
}
