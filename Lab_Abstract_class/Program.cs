using System.Reflection;

namespace Lab_Abstract_class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car()
            {
                TankSize = 10,
                CurrentOil = 10,
                HorsePower = 10,
                DoorCount = 12,
                DrivePath = 2,
                DriveTime = 10,
                WinCode = 123,
                FuelType = "sad",
                TransmissionKind = "d",
                WheelThickness = 3
            };
            Console.WriteLine("avg speed : " + car.AvgarageSpeed());
            foreach (PropertyInfo item in car.GetType().GetProperties())
            {
                Console.WriteLine(item.Name + " : " + item.GetValue(car));
            }
        }
    }

    public abstract class Vehicile
    {
        public int DriveTime { get; set; }
        public int DrivePath { get; set; }
        public int HorsePower { get; set; }
        public int TankSize { get; set; }
        public int CurrentOil { get; set; }
        public string FuelType { get; set; }
        public int WheelThickness { get; set; }

        public double AvgarageSpeed()
        {
            return DriveTime / DrivePath;
        }
    }
    public interface IEngine
    {
        public int HorsePower { get; set; }
        public int TankSize { get; set; }
        public int CurrentOil { get; set; }
        public string FuelType { get; set; }
        public int RemainOilAmount()
        {
            return 1;
        }
    }
    public interface IWheel
    {
        public int WheelThickness { get; set; }
    }
    public interface ITransmission
    {
        public string TransmissionKind { get; set; }
    }
    public class Car : Vehicile, IEngine, IWheel, ITransmission
    {
        public int DoorCount { get; set; }
        public int WinCode { get; set; }
        public string TransmissionKind { get; set; }
    }
    public class Byscle : IWheel
    {
        public string PedalKind { get; set; }
        public int WheelThickness { get ; set ; }
    }
    public class Plane : IEngine
    {
        public int WinLenght { get; set; }
        public int HorsePower { get ; set ; }
        public int TankSize { get ; set ; }
        public int CurrentOil { get ; set ; }
        public string FuelType { get ; set ; }
    }
}