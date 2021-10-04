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
            //Bridge.Exercise.Demo();
            #endregion

            #region Facade

            #endregion

            #region Flyweight
            //Flyweight.Exercise.Demo();
            #endregion

            #region Decorator
            //Decorator.Exercise.Demo();
            #endregion

            #region ChainOfResponsibility
            //ChainOfResponsibility.Exercise.Demo();
            #endregion

            #region Command
            //Command.Exercise.Demo();
            #endregion

            #region Interpretor
            //Interpreter.Exercise.Demo();
            #endregion

            #region Iterator
            //Iterator.Exercise.Demo();
            #endregion

            #region Mediator
            //Mediator.Exercise.Demo();
            #endregion

            #region Memento

            #endregion

            #region Observer
            // Events
            // Weak Event Pattern
            // Observer Interfaces
            // Bidirectional
            // Property Dependencies
            // Container Wireup
            #endregion

            #region State
            State.Exercise.Demo();
            #endregion

            #region Strategy
            //Strategy.Exercise.Demo();
            #endregion

            #region TemplateMethod
            TemplateMethod.Exercise.Demo();
            #endregion
        }
    }
}
