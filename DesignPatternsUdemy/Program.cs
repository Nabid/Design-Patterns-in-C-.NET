using System;

namespace DesignPatternsUdemy
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            #region Builder
            /// Fluent builder - inheritance through recursive generics
            /// -------------------------------------------------------
            //var me = Person.New
            //    .Called("dimitri")
            //    .WorksAs("police")
            //    .Build();

            //Console.WriteLine(me);

            /// Stepwise builder
            /// ----------------
            //var car = CarStepwiseBuilder.CarBuilder.Create()
            //    .OfType(CarStepwiseBuilder.CarType.Sedan)
            //    .WithWheels(5)
            //    .Build();

            //Console.WriteLine(car);

            ///Builder exercise
            ///----------------
            //new BuilderExercise();
            #endregion

            #region Factory
            //Factory.FactoryDemo.FactoryMethod();
            //Factory.AbstractFactoryDemo.Demo();

            //var personFactory = new Factory.PersonFactory();
            //personFactory.CreatePerson("Andy");
            //personFactory.CreatePerson("Biden");
            //personFactory.CreatePerson("Clara");
            //personFactory.PrintFactory();
            #endregion

            #region Prototype
            //Prototype.ExplicitDeepCopy.Demo();
            //Prototype.PrototypeInheritance.Demo();
            //Prototype.CopySerialization.Demo();
            #endregion

            #region Singleton

            #endregion

            #region Adapter

            #endregion

            #region Bridge
            Bridge.Exercise.Demo();
            #endregion
        }
    }
}
