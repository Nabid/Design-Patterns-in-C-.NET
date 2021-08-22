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

            #endregion

        }
    }
}
