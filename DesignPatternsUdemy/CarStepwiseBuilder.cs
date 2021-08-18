using System;
namespace DesignPatternsUdemy
{
    public class CarStepwiseBuilder
    {
        public CarStepwiseBuilder()
        {
        }

        public enum CarType { Unknown, Sedan, Crossover }

        public class Car : ICar
        {
            public CarType CarType { get; set; }
            public int WheelSize { get; set; }

            public override string ToString()
            {
                return $"Car type: {CarType}, wheelsize: {WheelSize}";
            }
        }

        public interface ISpecifyCarType
        {
            ISpecifyWheelSize OfType(CarType carType);
        }

        public interface ISpecifyWheelSize
        {
            IBuildCar WithWheels(int size);
        }

        public interface IBuildCar
        {
            Car Build();
        }

        public class CarBuilder
        {
            private class Impl : IBuildCar, ISpecifyWheelSize, ISpecifyCarType
            {
                public Car _car = new Car();

                public Car Build()
                {
                    return _car;
                }

                public ISpecifyWheelSize OfType(CarType carType)
                {
                    _car.CarType = carType;
                    return this;
                }

                public IBuildCar WithWheels(int size)
                {
                    _car.WheelSize = size;
                    return this;
                }
            }

            public static ISpecifyCarType Create()
            {
                return new Impl();
            }
        }
        //public class Demo
        //{
        //    static void Main(string[] args)
        //    {
        //    }
        //}
    }
}
